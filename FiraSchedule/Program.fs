open TableHeaderGenerator
open Io
open ModelProcessor

// Output
let htmlOut = "C:\\test\\schedule.html"
let cssOut = "c:\\test\\styles.css"

// Input

let getInputPath argv = 
    if (argv |> Array.length > 0) then 
        argv.[0]
    else
        @"C:\\test\\jira.csv"

[<EntryPoint>]
let main argv =

    let htmlSaver = write htmlOut
    let cssSaver = write cssOut
    let csvFile = getInputPath argv

    let model = 
        Input.generateData csvFile
        |> ticketsToModel

    createStringBuilder
    |> appendText Html.header
    |> appendFunc generateThead model
    |> appendFunc TableBodyGenerator.generateTableBody model
    |> appendText TableBodyGenerator.bodyFooter
    |> appendText Html.footer        
    |> sbToString
    |> htmlSaver

    Html.css |> cssSaver

    0