module TableBodyGenerator

open Models
open Io

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
    let td status =
        let statusClass = match status with
            | Complete     -> "complete"
            | In_Progress  -> "in_progress"
            | To_Do        -> "todo"
            | Testing      -> "testing"
            | OOF          -> "oof"
            | Placeholder  -> "placeholder"

        sprintf "            <td class=\"%s\"></td>\n" statusClass

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

    model.people
    |> List.map tr
    |> concatStrings