﻿module Html

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

let css = """
td.complete { background: #E2EFDA; }
td.in_progress { background: #FFF2CC; }
td.todo { background: #D9E1F2; }
td.oof { background: #F4B084; }
td.testing { background: #FFC7CE; }

table{
    border: none;
}

th, td {
    width: 75px
}

tr.emptyLine { height: 15px }

"""