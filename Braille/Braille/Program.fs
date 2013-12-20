let brailleMap = 
    let brailleList = ["O.....";"O.O...";"OO....";"OO.O..";"O..O..";
                        "OOO...";"OOOO..";"O.OO..";".OO..."; ".OOO..";"O...O.";"O.O.O.";
                        "OO..O.";"OO.OO.";"O..OO.";"OOO.O.";"OOOOO."; "O.OOO.";".OO.O."; 
                        ".OOOO.";"O...OO";"O.O.OO";".OOO.O";"OO..OO";"OO.OOO";"O..OOO"]
    let alphabetList = List.ofSeq "abcdefghijklmnopqrstuvwxyz"
    Map.ofList (List.zip brailleList alphabetList)

let rec transpose  = function
    | (_::_)::_ as list -> List.map List.head list :: transpose (List.map List.tail list)
    | _ -> []

let join str = String.concat "" str

let parseBrailleLines (firstLine : string) (secondLine : string) (thirdLine : string) =
    let rows = [firstLine; secondLine; thirdLine]
    let charList = 
        rows 
        |> List.map (fun x -> x.Split(' '))
        |> List.map Array.toList
        |> transpose
        |> List.map join
        |> List.map (fun x -> Map.find x brailleMap)
    System.String.Concat(Array.ofList(charList))

[<EntryPoint>]
let main argv = 
    printfn "%s" (parseBrailleLines (System.Console.ReadLine())  (System.Console.ReadLine()) (System.Console.ReadLine()))
    0
