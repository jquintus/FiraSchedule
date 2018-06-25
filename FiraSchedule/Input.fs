module Input

open FSharp.Data
open Models
open Utils

type Jira = CsvProvider<"C:\\code\\FiraSchedule\\SampleData\\Jira.csv">

let generateData (path: string) = 
    let strToStatus str =
        match str with 
        | InvariantEqual "Backlog"     -> Backlog
        | InvariantEqual "In Progress" -> InProgress
        | InvariantEqual "Done"        -> Done
        | InvariantEqual "In QA"       -> Done
        | InvariantEqual "In Review"   -> Done
        | _                            -> Other
    
    let cleanName str = 
        if (str = "") then
            " Not Assigned"
        else
            Utils.titleCase str

    let tickets = Jira.Load(path)
    [ for row in tickets.Rows do
        
        yield {
            assignee = cleanName row.Assignee
            startDate = row.``Custom field (Start date)``
            endDate = row.``Custom field (End date)``
            status = strToStatus row.Status
        }
    ]


