module Input

open FSharp.Data
open Models
open Utils
open System

type Jira = CsvProvider<"C:\\code\\FiraSchedule\\SampleData\\Jira.csv", AssumeMissingValues = true>

let generateData (path: string) = 
    let strToStatus str =
        match str with 
        | InvariantEqual "Backlog"     -> Backlog
        | InvariantEqual "In Progress" -> InProgress
        | InvariantEqual "Done"        -> Done
        | InvariantEqual "In QA"       -> Done
        | InvariantEqual "In Review"   -> Done
        | InvariantEqual "In Master"   -> Done
        | _                            -> Other
    
    let cleanName str = 
        if (str = "") then
            " Not Assigned"
        else
            Utils.titleCase str

    let cleanList lst =
        lst
        |> List.where (fun item -> item <> "")
    
    let cleanDate date= 
        match date with
        | Some d -> d
        | None -> DateTime.MinValue

    let tickets = Jira.Load(path)
    [ for row in tickets.Rows do
        
        yield {
            assignee = cleanName row.Assignee
            startDate = cleanDate row.``Custom field (Start date)``
            endDate = cleanDate row.``Custom field (End date)``
            status = strToStatus row.Status
            key = row.``Issue key``
            labels = cleanList [
                                 row.Labels
                                 row.Labels2
                                 row.Labels3
                                 row.Labels4
                               ]
        }
    ]


