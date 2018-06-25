﻿module Models

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
    labels: string list
    key: string
}

type ScheduleStatus =
    | Complete
    | In_Progress
    | To_Do
    | Testing
    | OOF
    | Placeholder

type ScheduleItem = {
    status: ScheduleStatus
    key: string
}

type Person = { 
    name: string
    statuses: ScheduleItem list 
}

type Schedule = {
    people: Person list
    startDate: DateTime
    endDate: DateTime
}
