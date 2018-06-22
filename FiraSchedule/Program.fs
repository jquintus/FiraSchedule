open System
open HeaderGenerator
open Io

// Output
let output = "C:\\test\\schedule.html"

// Input
let startDate = new DateTime (2018, 4, 25)
let endDate = new DateTime (2018, 9, 3)

[<EntryPoint>]
let main argv =

    let saveToDisk = write output

    sbCreate
    |> append Html.header
    |> append (generateThead startDate endDate)
    |> append Html.footer        
    |> sbToString
    |> saveToDisk

    0