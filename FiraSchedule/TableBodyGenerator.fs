module TableBodyGenerator

type Person = { name: string; statuses: string list }

let concatStrings data =
    data
    |> List.fold (+) System.String.Empty

let allData = 
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

let td =
    sprintf "            <td class=\"%s\"></td>\n"

let tr person =
    person.statuses
    |> List.map td
    |> concatStrings
    |> sprintf 
        """
            <td>%s</td>
%s
    <tr>
    """
        person.name

let body data = 
    data 
    |> List.map tr
    |> concatStrings


let tableBody = body allData
