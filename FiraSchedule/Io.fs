module Io

open System.IO
open System.Text

let createStringBuilder =
    new StringBuilder()

let appendText text (sb:StringBuilder) =
    sb.AppendLine(text) 

let appendFunc f x sb =
    let text = f x
    appendText text sb

let sbToString (sb:StringBuilder) =
    sb.ToString()

let write path content =
    File.WriteAllText(path, content)
