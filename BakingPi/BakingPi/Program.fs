// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

let delimitedInput (c:char) = 
    System.Console.ReadLine().Split(c)

let rec runoffRound candidates votes =
    Map.map 

[<EntryPoint>]
let main argv = 
    let numVotes = int (delimitedInput ' ').[0]
    let candidates = delimitedInput ' '
    let votes = [ for _ in [1..numVotes] -> (delimitedInput ' ') |> Array.map int ]
    0 // return an integer exit code
