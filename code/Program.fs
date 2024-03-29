﻿open Evaluator
open System
open Parser

[<EntryPoint>]
let main args =
    try
        let file = args[0]
        let text = IO.File.ReadAllText file
        match parse text with
        | Some ast ->
            let svg = startEval ast
            printfn "%s" svg
            0
        | None ->
            printfn "Usage: dotnet run big-example.ss > result.html. Make sure syntax is correct. Example: date 04112023 up 0700 h2o 37 sleep 2330"
            1
    with
    | _ -> printfn "Usage: dotnet run big-example.ss > result.html"; 1;