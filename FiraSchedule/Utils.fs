module Utils

open System

// Strings
let concatStrings data =
    data
    |> Seq.fold (+) System.String.Empty

// Dates
let numberOfWeeks (startDate:DateTime) (endDate:DateTime) =
    let days = endDate - startDate
    System.Math.Round (float days.Days / 7.0) |> int

let addWeeks (date:DateTime) weekCount =
    let daysToAdd = (weekCount * 7) |> float
    date.AddDays(daysToAdd)

let getMonday (dt:DateTime) =
    let delta = 
        DayOfWeek.Monday - dt.DayOfWeek 
        |> float
    dt.AddDays(delta)

let getShortMonth (date:DateTime) = 
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

let weeks startDate endDate =
    let numOfWeeks = numberOfWeeks startDate endDate
    let firstMonday = getMonday startDate
    let addWeeks' = addWeeks firstMonday
    
    seq { 
        for weekId in 0 .. (numOfWeeks - 1) do 
            yield addWeeks' weekId 
        }
