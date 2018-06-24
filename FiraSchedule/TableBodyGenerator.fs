module TableBodyGenerator

open Models

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

let bodyFooter = 
    """
        <tr class="emptyLine"></tr>
        <tr>
            <td class="placeholder"></td>

            <td class="complete">Complete</td>
            <td class="in_progress">In Progress</td>
            <td class="todo">To Do</td>
            <td class="testing">Testing</td>
            <td class="oof">OOF</td>
        </tr>
    """

let generateTableBody model = 
    body allData
