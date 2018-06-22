open System
open TableHeaderGenerator
open Io

// Output
let htmlOut = "C:\\test\\schedule.html"
let cssOut = "c:\\test\\styles.css"

// Input
let startDate = new DateTime (2018, 4, 25)
let endDate = new DateTime (2018, 9, 3)

[<EntryPoint>]
let main argv =

    let htmlSaver = write htmlOut
    let cssSaver = write cssOut

    sbCreate
    |> append Html.header
    |> append (generateThead startDate endDate)
    |> append TableBodyGenerator.tableBody
    |> append TableBodyGenerator.bodyFooter
    |> append Html.footer        
    |> sbToString
    |> htmlSaver

    Css.all |> cssSaver

    0