// Lister
// Created by Ash Olorenshaw
// find it on Github here: https://github.com/Ash-Olorenshaw/Lister

module lister

open System.IO

let explanation = "[Lister.dll] REQUIRED: [<filepath>] OPTIONAL: [-d/--directories] [-f/--files] [-c/--coloured/--colored] [-i/--ignore] [-h/--help]"

let listFiles (path : string) (ignore : bool) = 
    Directory.GetFiles(path)
    |> Array.map Path.GetFileName
    |> Array.choose (fun file ->
        if not <| ignore then
            if not (file[0] = '.') then
                Some(file)
            else
                None
        else
            Some(file)
        )
    |> Array.iter (printfn "%s")

let colourFile (file : string) (dir : bool) = 
    if dir then
        $"\u001B[36m{file}\u001B[0m"
    else
        file

let listDirs(path : string) (colourDir : bool) (ignore : bool) = 
    Directory.GetDirectories(path)
    |> Array.map Path.GetFileName
    |> Array.choose (fun dir ->
        if not <| ignore then
            if not (dir[0] = '.') then
                Some(dir)
            else
                None
        else
            Some(dir)
    )
    |> Array.map (fun dir -> 
        if colourDir then
            colourFile dir true
        else 
            dir
    )
    |> Array.iter (printfn "%s")

let arrayContainsFlags (flag : string, altFlag : string) (targetArray : array<string>) = 
    if Array.contains flag targetArray || Array.contains altFlag targetArray then
        true
    else
        false

[<EntryPoint>]
let main(args) = 
    if arrayContainsFlags ("-h", "--help") args then
        printfn $"\n\tLister\n\"Everybody's a textfile, Dave\"\n\n{explanation}"

    if args.Length > 0 then
        let colouredOut = arrayContainsFlags ("-c", "--coloured") args || Array.contains "--colored" args
        let ignoreHidden = not <| arrayContainsFlags ("-i", "--ignore") args

        if arrayContainsFlags ("-d", "--directories") args then
            listDirs args[0] colouredOut ignoreHidden

        if arrayContainsFlags ("-f", "--files") args then
            listFiles args[0] ignoreHidden

        else if not <| arrayContainsFlags ("-d", "--directories") args then
            listDirs args[0] colouredOut ignoreHidden
            listFiles args[0] ignoreHidden

    else
        printfn $"Error - no filepath specified.\n\nMake sure you're using the right syntax:\n{explanation}"

    0

