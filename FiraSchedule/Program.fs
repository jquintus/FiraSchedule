open System
open TableHeaderGenerator
open Io
open Models

// Output
let htmlOut = "C:\\test\\schedule.html"
let cssOut = "c:\\test\\styles.css"

// Input
let csvFile = @"C:\\test\\jira.csv"

[<EntryPoint>]
let main argv =

    let htmlSaver = write htmlOut
    let cssSaver = write cssOut

    let model = 
        Input.generateData csvFile
        |> ticketsToModel

    sbCreate
    |> append Html.header
    |> append (generateThead model)
    |> append TableBodyGenerator.tableBody
    |> append TableBodyGenerator.bodyFooter
    |> append Html.footer        
    |> sbToString
    |> htmlSaver

    Css.all |> cssSaver

    0