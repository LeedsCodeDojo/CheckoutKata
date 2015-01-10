module Tests

open Xunit
open FsUnit.Xunit

[<Fact>]
let canBuyASingleApple() =
    let total = Dojo.checkout ["Apple"]

    total |> should equal 0.3

[<Fact>]
let canBuyTwoApples() =
    let total = Dojo.checkout ["Apple"; "Apple"]

    total |> should equal 0.6

[<Fact>]
let canBuyASingleBean() =
    let total = Dojo.checkout ["Bean"]

    total |> should equal 0.5

[<Fact>]
let canBuyASingleCoke() =
    let total = Dojo.checkout ["Coke"]

    total |> should equal 1.8

[<Fact>]
let canBuyAFourApples() =
    let total = Dojo.checkout ["Apple";"Apple";"Apple";"Apple"]

    total |> should equal 1.

[<Fact>]
let canBuyTwoDeodorants() =
    let total = Dojo.checkout ["Deodorant"; "Deodorant"]

    total |> should equal 4.5

[<Fact>]
let canBuySingleDeodorant() =
    let total = Dojo.checkout ["Deodorant"]

    total |> should equal 2.5

[<Fact>]
let canBuy5Apples2Beans2Cokes3Deodorants() =
    let total = Dojo.checkout ["Apple"; "Apple"; "Apple"; "Apple"; "Apple"; "Bean"; "Bean"; "Coke"; "Coke"; "Deodorant"; "Deodorant"; "Deodorant"]

    total |> should equal 12.9
