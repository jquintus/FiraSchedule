module TableBodyGenerator

open Models
open Utils

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
    let td (schedule:ScheduleItem )=
        let statusClass = 
            match schedule.status with
            | Complete     -> "complete"
            | In_Progress  -> "in_progress"
            | To_Do        -> "todo"
            | Testing      -> "testing"
            | OOF          -> "oof"
            | Placeholder  -> "placeholder"

        sprintf "            <td class=\"%s\" title=\"%s\"></td>\n" statusClass schedule.key

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