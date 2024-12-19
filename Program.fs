// Lister
// Created by Ash Olorenshaw
// find it on Github here: 

module lister

open System.IO

let listFiles(path : string) = 
    Directory.GetFiles(path)
    |> Array.map Path.GetFileName
    |> Array.iter (printfn "%s")


let listDirs(path : string) = 
    Directory.GetDirectories(path)
    |> Array.map Path.GetFileName
    |> Array.iter (printfn "%s")


[<EntryPoint>]
let main(args) = 
    if Array.contains "-h" args || Array.contains "--help" args then
        printfn "\n\tLister\n\"Everybody's a textfile, Dave\"\n\n[lister.dll] REQUIRED: [<filepath>] OPTIONAL: [-d/--directories] [-f/--files] [-h/--help]"
    if args.Length > 0 then
        if Array.contains "-d" args || Array.contains "--directories" args then
            listDirs args[0]


        if Array.contains "-f" args || Array.contains "--files" args then
            listFiles args[0]

        else if not <| Array.contains "-d" args && Array.contains "--directories" args then
            listDirs args[0]
            listFiles args[0]


    else
        printfn "Error - no filepath specified.\n\nMake sure you're using the right syntax:\n[lister.dll] REQUIRED: [<filepath>] OPTIONAL: [-d/--directories] [-f/--files] [-h/--help]"

    0

