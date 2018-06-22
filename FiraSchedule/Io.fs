module Io

open System.IO
open System.Text

let append text (sb:StringBuilder) =
    sb.AppendLine(text) 

let sbToString (sb:StringBuilder) =
    sb.ToString()

let sbCreate =
    new StringBuilder()

let write path content =
    File.WriteAllText(path, content)
