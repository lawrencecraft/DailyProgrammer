
let split  (target : string) (str : string) = str.Split([|target|], System.StringSplitOptions.None)  // We really need a functional string handler in F#
let trim (str:string) = str.Trim()

let parseLine (line : string) = 
    let splitList = line |> split "=>"
    let parsedSplitList = 
        splitList
            |> Array.map trim
            |> Array.map (split " ")
            |> Array.map (fun x -> x |> Array.map int)
            |> Array.map List.ofArray
    (parsedSplitList.[0], parsedSplitList.[1])

   
let getNodeList line map =
    let sourceList, destList = parseLine line
    let rec addAll map value = function
        | head :: tail -> addAll (Map.add head value map) value tail
        | [] -> map
    [for source in sourceList do
        for dest in destList do
            yield (source, dest)] |> addAll map 1

let buildNodes connections =
    let rec buildNodesInt connections map =
        match connections with
        | n when n > 0 -> 
            let newMap = getNodeList (System.Console.ReadLine()) map
            buildNodesInt (connections - 1) newMap
        | _ -> map
    buildNodesInt connections Map.empty

let lookup item map = 
    match Map.tryFind item map with 
    | Some (_) -> "1"
    | None -> "0"

[<EntryPoint>]
let main argv = 
    let splitString = System.Console.ReadLine() |> split " "
    let sides, connections = int splitString.[0], int splitString.[1]
    let map = buildNodes connections
    for row = 0 to sides - 1 do
       let column = [0..sides - 1] |> List.map (fun x -> lookup (row, x) map) |> String.concat ""
       printfn "%s" column
    0 // return an integer exit code
