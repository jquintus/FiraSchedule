module Input

open FSharp.Data
open Models

type Jira = CsvProvider<"C:\\code\\FiraSchedule\\SampleData\\Jira.csv">


let generateData (path: string) = 
    let tickets = Jira.Load(path)

    [ for row in tickets.Rows do
        
        yield {
            assignee = row.Assignee
            startDate = row.``Custom field (Start date)``
            endDate = row.``Custom field (End date)``
        }
    ]


