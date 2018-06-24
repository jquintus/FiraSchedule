module ModelProcessor

open Models

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
        tickets 
        |> Seq.sortBy (fun t -> t.startDate)
        |> Seq.map (fun t -> t.assignee)
        |> ignore

        [
            ScheduleStatus.Placeholder
            ScheduleStatus.Complete
            ScheduleStatus.To_Do
            ScheduleStatus.OOF
            ScheduleStatus.In_Progress
            ScheduleStatus.Testing
        ]

    let ticketGroupToPerson (name, tickets) =
        { 
            name = name
            statuses = ticketsToStatuses tickets
        }

    let people = 
        tickets
        |> Seq.groupBy (fun t -> t.assignee)
        |> Seq.map ticketGroupToPerson
    {
        startDate = startDate
        endDate = endDate
        people = people |> Seq.toList
     }