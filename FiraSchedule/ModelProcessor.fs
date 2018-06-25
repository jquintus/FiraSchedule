module ModelProcessor

open Models
open System
open Utils

let ticketsToModel (tickets: Ticket seq) = 

    let startDate = 
        tickets
        |> Seq.map (fun t -> t.startDate)
        |> Seq.min

    let endDate = 
        tickets
        |> Seq.map (fun t -> t.endDate)
        |> Seq.max
    
    let ticketsToStatuses (tickets:Ticket seq) =

        let (|LabelsContain|_|) str ticket =
            if ticket.labels |> List.contains str
            then Some() else None
        let isVacation ticket =
            match ticket with 
            | LabelsContain "Vacation" -> 0
            | _ -> 1

        let getTicketForWeek (thisWeek:DateTime) =
            let nextWeek = addWeeks thisWeek 1
            let filteredTickets = 
                tickets
                |> Seq.filter (fun t -> (t.startDate < nextWeek && t.endDate > thisWeek))
            
            if Seq.isEmpty filteredTickets then
                None
            else
                filteredTickets
                |> Seq.sortBy(fun t -> (isVacation t, t.endDate))
                |> Seq.head
                |> Some

        let statusForWeek (date:DateTime) =
            let maybeTicket = getTicketForWeek date
            let key = match maybeTicket with
                      | Some t -> t.key
                      | None -> ""
            let status = match maybeTicket with
                         | None -> Placeholder
                         | Some ticket -> 
                             match ticket with
                             | LabelsContain "Vacation" -> OOF
                             | LabelsContain "Testing" -> Testing
                             | {status = Backlog } -> To_Do
                             | {status = Done } -> Complete
                             | {status = InProgress } -> In_Progress
                             | _ -> Placeholder
            { key = key; status = status }

        Utils.weeks startDate endDate
        |> Seq.map statusForWeek
        |> Seq.toList
        
    let ticketGroupToPerson (name, tickets) =
        { 
            name = name
            statuses = ticketsToStatuses tickets
        }

    let people = 
        tickets
        |> Seq.groupBy (fun t -> t.assignee)
        |> Seq.map ticketGroupToPerson
        |> Seq.sortBy (fun s -> s.name)
    {
        startDate = startDate
        endDate = endDate
        people = people |> Seq.toList
     }