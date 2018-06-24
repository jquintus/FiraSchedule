module Input

open FSharp.Data
open Models
open System

type Jira = CsvProvider<"C:\\code\\FiraSchedule\\SampleData\\Jira.csv">


let generateData (path: string) = 
    let (|InvariantEqual|_|) (str:string) arg = 
      if String.Compare(str, arg, StringComparison.OrdinalIgnoreCase) = 0
        then Some() else None

    let strToStatus str =
        match str with 
        | InvariantEqual "backlog"     -> Backlog
        | InvariantEqual "in progress" -> InProgress
        | InvariantEqual "done"        -> Done
        | InvariantEqual "in qa"       -> Done
        | InvariantEqual "in review"   -> Done
        | _                            -> Other

    let tickets = Jira.Load(path)
    [ for row in tickets.Rows do
        
        yield {
            assignee = row.Assignee
            startDate = row.``Custom field (Start date)``
            endDate = row.``Custom field (End date)``
            status = strToStatus row.Status
        }
    ]


