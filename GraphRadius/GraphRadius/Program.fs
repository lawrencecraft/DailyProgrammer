type InfiniteInt =
    | Real of int
    | Infinity
    with
        member this.toString = 
            match this with
            | Real(n) -> n.ToString()
            | Infinity -> "Infinity"

let inline (+) (x : InfiniteInt) (y : InfiniteInt) = 
    match (x, y) with
    | (Infinity, _) -> Infinity
    | (_, Infinity) -> Infinity
    | (Real(n), Real(m)) -> Real(n + m)

let inline (>) (x : InfiniteInt) (y : InfiniteInt) = 
    match (x, y) with
    | (Infinity, Real(_)) -> true
    | (Infinity, Infinity) -> false
    | (Real(_), Infinity) -> false
    | (Real(n), Real(m)) -> n > m

let split (c : char) (n : System.String) = n.Split(c)

[<EntryPoint>]
let main argv = 
    let vertexes = int (System.Console.ReadLine())
    let adjMatrix = Array2D.init<InfiniteInt> vertexes vertexes (fun _ __ -> Infinity)
    for x in [0..(vertexes - 1)] do
        adjMatrix.[x, x] <- Real(0)
        let line = System.Console.ReadLine() |> split ' '
        for y in [0 .. (Array.length line) - 1] do if line.[y] = "1" then adjMatrix.[x,y] <- Real(1) 
    for x in [0..(vertexes - 1)] do
        for y in [0..(vertexes - 1)] do
            for z in [0..(vertexes - 1)] do
                let sum = adjMatrix.[y,x] + adjMatrix.[x, z]
                if adjMatrix.[y, z] > sum then adjMatrix.[y, z] <- sum
    let radius =
        let maxRadiuses = 
            [for x in [0..(vertexes - 1)] 
                ->
                    [for y in [0..(vertexes - 1)] -> adjMatrix.[x, y]] |> List.max
            ]
        maxRadiuses |> List.min
    printfn "%s" radius.toString
    0 