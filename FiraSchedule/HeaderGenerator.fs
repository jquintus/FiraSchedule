module HeaderGenerator

open System

let tableHeader = """
    <table cellspacing="0" cellpadding="0">
        <thead>
            <th class="placeholder"></th>
"""
let tableFooter = "        </thead>"

let getMonday (dt:DateTime) =
    let delta = 
        DayOfWeek.Monday - dt.DayOfWeek 
        |> float
    dt.AddDays(delta)

let weeks (startDate:DateTime) (endDate:DateTime) =
    let days = endDate - startDate
    System.Math.Round (float days.Days / 7.0) |> int

let month (date:DateTime) = 
    match date.Month with
    |  1 -> "Jan"
    |  2 -> "Feb"
    |  3 -> "Mar"
    |  4 -> "Apr"
    |  5 -> "May"
    |  6 -> "Jun"
    |  7 -> "Jul"
    |  8 -> "Aug"
    |  9 -> "Sep"
    | 10 -> "Oct"
    | 11 -> "Nov"
    | 12 -> "Dec"
    |  _ -> "???"

let th (date:DateTime) = 
    let mth = month date
    sprintf "<th> %s-%i </th>" mth date.Day

let addWeeks (date:DateTime) weekCount =
    let daysToAdd = (weekCount * 7) |> float
    date.AddDays(daysToAdd)

let tableBody startDate endDate = 
    let mutable body = ""
    let firstMonday = getMonday startDate
    let weekCount = weeks startDate endDate
    for weekId in 1 .. weekCount do
        let currentWeek = addWeeks firstMonday weekId
        let currentTh = th currentWeek
        body <- sprintf "%s            %s\n" body currentTh
    body

let generateThead startDate endDate =
    let body = tableBody startDate endDate
    sprintf "%s %s %s" tableHeader body tableFooter