module Models

open System

type Ticket = { 
    assignee: string 
    startDate: DateTime
    endDate: DateTime
}

type Person = { 
    name: string
    statuses: string list 
}

type Model = {
    people: Person list
    startDate: DateTime
    endDate: DateTime
}

let ticketsToModel (tickets: Ticket list) = 
    let startDate = 
        tickets
        |> List.map (fun t -> t.startDate)
        |> List.min
    let endDate = 
        tickets
        |> List.map (fun t -> t.endDate)
        |> List.max
    {
        startDate = startDate
        endDate = endDate
        people = []
     }