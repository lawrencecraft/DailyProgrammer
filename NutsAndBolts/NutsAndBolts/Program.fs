let parseLine (line:System.String) = 
    let parsedString = line.Split(' ')
    ( parsedString.[0], int (parsedString.[1]) )

let printLine = function
    | (product, price) when price > 0 -> System.Console.WriteLine(product + " +" + string price)
    | (product, price) when price < 0 -> System.Console.WriteLine(product + " " + string price)
    | _ -> ()

[<EntryPoint>]
let main argv = 
    let number = int (System.Console.ReadLine())
    let getLines count = 
        [for n in [1..count] -> System.Console.ReadLine()] 
            |> List.map parseLine 
    let priceMap = getLines number |> List.fold (fun acc (product, price) -> Map.add product price acc) Map.empty
    getLines number
        |> List.map (fun (product, price) -> (product, price - Map.find product priceMap))
        |> List.filter (fun (product, price) -> price <> 0)
        |> List.iter printLine
    0
