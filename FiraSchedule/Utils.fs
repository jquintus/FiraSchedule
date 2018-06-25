﻿module Utils

open System
open System.Globalization

// Strings
let concatStrings data =
    data
    |> Seq.fold (+) System.String.Empty

let titleCase str = 
    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str)

let (|InvariantEqual|_|) (str:string) arg = 
    if String.Compare(str, arg, StringComparison.OrdinalIgnoreCase) = 0
    then Some() else None

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
    
    seq { 
        for weekId in 0 .. (numOfWeeks - 1) do 
            yield addWeeks firstMonday weekId 
        }
