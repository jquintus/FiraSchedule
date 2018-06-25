module TableHeaderGenerator

open Models
open Utils

let tableHeader = """
    <table cellspacing="0" cellpadding="0">
        <thead>
            <th class="placeholder"></th>
"""
let tableFooter = "        </thead>"

let generateThead model =

    let th date = 
        let mth = getShortMonth date
        sprintf "<th> %i-%s </th>" date.Day mth

    let tableBody startDate endDate = 
        weeks startDate endDate
        |> Seq.map th
        |> Seq.map (sprintf "            %s\n")
        |> concatStrings

    let body = tableBody model.startDate model.endDate

    sprintf "%s %s %s" tableHeader body tableFooter