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
        sprintf "<th> %s-%i </th>" mth date.Day

    let tableBody startDate endDate = 
        let mutable body = ""
        let firstMonday = getMonday startDate
        let weekCount = numberOfWeeks startDate endDate
        for weekId in 1 .. weekCount do
            let currentWeek = addWeeks firstMonday weekId
            let currentTh = th currentWeek
            body <- sprintf "%s            %s\n" body currentTh
        body

    let body = tableBody model.startDate model.endDate

    sprintf "%s %s %s" tableHeader body tableFooter