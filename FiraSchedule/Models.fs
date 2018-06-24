module Models

open System

type TicketStatus =
    | Backlog
    | Done
    | InProgress
    | Other

type Ticket = { 
    assignee: string 
    startDate: DateTime
    endDate: DateTime
    status: TicketStatus
}

type ScheduleStatus =
    | Complete
    | In_Progress
    | To_Do
    | Testing
    | OOF
    | Placeholder

type Person = { 
    name: string
    statuses: ScheduleStatus list 
}

type Schedule = {
    people: Person list
    startDate: DateTime
    endDate: DateTime
}
