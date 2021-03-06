﻿#r "CommandLine.dll"

open System
open CommandLine

type options() =
    let mutable stringValue = ""
    let mutable intSequence = Seq.empty<int>
    let mutable boolValue = false
    let mutable longValue = 0L

    [<Option(HelpText = "Define a string value here.")>]
    member this.StringValue with get() = stringValue and set(value) = stringValue <- value

    [<Option('i', Min = 3, Max = 4, HelpText = "Define a int sequence here.")>]
    member this.IntSequence with get() = intSequence and set(value) = intSequence <- value

    [<Option('x', HelpText = "Define a boolean or switch value here.")>]
    member this.BoolValue with get() = boolValue and set(value) = boolValue <- value

    [<Value(0)>]
    member this.LongValue with get() = longValue and set(value) = longValue <- value

let reportInput (o : options)  =
    sprintf "--stringvalue: %s\n -i: %A\n -x: %b\n value: %u\n" o.StringValue (Array.ofSeq o.IntSequence) o.BoolValue o.LongValue

let args = Array.ofSeq(Seq.skip 1 (Seq.ofArray fsi.CommandLineArgs))
let parsed = Parser.Default.ParseArguments<options>(args)

if Seq.isEmpty parsed.Errors 
then Console.WriteLine(reportInput parsed.Value)
else printf "Invalid: %A\n" args
