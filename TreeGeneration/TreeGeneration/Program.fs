[<EntryPoint>]
let main argv =
    let split (c:char) (s:string) = s.Split(c)
    let input = System.Console.ReadLine() |> split ' '
    let baselength, tree, trunk = (int input.[0], Seq.head input.[1], Seq.head input.[2])
    let treeHeight = (baselength + 1) / 2
    for linenum in [1..treeHeight] do
        let currentLength = 2 * linenum - 1
        printfn "%s%s" (" " |> String.replicate ((baselength - currentLength) / 2)) (string tree |> String.replicate currentLength)
    let min =
        match baselength with
        | n when n > 3 -> (n - 3) / 2 
        | _ -> 0
    printfn "%s%s" (String.replicate min " ") (string trunk |> String.replicate 3)
    0