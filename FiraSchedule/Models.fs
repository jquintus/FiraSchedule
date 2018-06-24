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

let hardCodedPeople = 
    [
        { name = "Aliena";
          statuses = ["complete"; "complete"; "complete"; "complete"; "complete"; "complete"; "complete"; "complete"; "in_progress"; "todo"; "todo"; "todo"; "todo"; "todo"; "todo"; "todo"; "placeholder"; "testing"; "testing"; "testing";]
        };

        { name = "Charles";
          statuses = ["placeholder"; "placeholder"; "complete"; "placeholder"; "in_progress"; "in_progress"; "in_progress"; "in_progress"; "in_progress"; "todo"; "oof"; "todo"; "todo"; "todo"; "todo"; "todo"; "todo"; "testing"; "testing"; "testing";]
        };

        { name = "Duke Signor";
          statuses = ["placeholder"; "placeholder"; "placeholder"; "placeholder"; "complete"; "complete"; "complete"; "in_progress"; "in_progress"; "todo"; "todo"; "todo"; "todo"; "todo"; "todo"; "oof"; "todo"; "oof"; "oof"; "testing";]
        };

        { name = "Jacques";
          statuses = ["oof"; "oof"; "oof"; "oof"; "oof"; "oof"; "oof"; "oof"; "oof"; "oof"; "placeholder"; "placeholder"; "placeholder"; "placeholder"; "placeholder"; "placeholder"; "placeholder"; "testing"; "testing"; "testing";]
        };

        { name = "Orlando";
          statuses = ["placeholder"; "placeholder"; "complete"; "complete"; "complete"; "in_progress"; "in_progress"; "in_progress"; "in_progress"; "todo"; "todo"; "todo"; "todo"; "todo"; "todo"; "todo"; "todo"; "testing"; "testing"; "testing";]
        };

        { name = "Rosalind";
          statuses = ["placeholder"; "placeholder"; "placeholder"; "placeholder"; "complete"; "complete"; "complete"; "placeholder"; "in_progress"; "in_progress"; "oof"; "todo"; "todo"; "todo"; "todo"; "todo"; "todo"; "testing"; "testing"; "testing";]
        };

        { name = "Touchstone";
          statuses = ["placeholder"; "placeholder"; "complete"; "complete"; "complete"; "complete"; "complete"; "oof"; "in_progress"; "todo"; "todo"; "todo"; "todo"; "todo"; "todo"; "placeholder"; "placeholder"; "testing"; "testing"; "testing";]
        };

        { name = "Olivia";
          statuses = ["placeholder"; "placeholder"; "complete"; "complete"; "complete"; "complete"; "complete"; "complete"; "in_progress"; "in_progress"; "in_progress"; "in_progress"; "in_progress"; "in_progress"; "placeholder"; "placeholder"; "placeholder"; "testing"; "testing"; "testing";]
        };
    ]


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
        people = hardCodedPeople
     }