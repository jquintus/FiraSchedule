// Learn more about F# at http://fsharp.org

open System
open System.IO
open System.Text
open HeaderGenerator

let header = """
<html>
    <head>
        <link rel="stylesheet" href="styles.css"/>
    </head>
<body>
"""

let footer = """
    </table>
<body>
<html>
"""

let output = "C:\\test\\schedule.html"

let append text (sb:StringBuilder) =
    sb.AppendLine(text) 

let sbToString (sb:StringBuilder) =
    sb.ToString()

let sbCreate =
    new StringBuilder()

let startDate = new DateTime (2018, 4, 25)
let endDate = new DateTime (2018, 9, 3)

[<EntryPoint>]
let main argv =

    let text = 
        sbCreate        
        |> append header
        |> append (generateThead startDate endDate)
        |> append footer        
        |> sbToString

    File.WriteAllText(output, text)

    0

