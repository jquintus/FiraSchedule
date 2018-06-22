module Models

open System

type Ticket = { 
    assignee: string 
    startDate: DateTime
    endDate: DateTime
}

type Person = { 
    name: string
    statuses: string list 
}
