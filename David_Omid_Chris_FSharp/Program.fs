// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.


module Dojo

//type NormalItem = { 
//        Price : float
//    }
//
//type DiscountedItem = { 
//        Price : float
//        PriceBreak : int
//        DiscountedPrice : float
//    }

type ShoppingItem =
    | DiscountedItem of productCode : string * price : float * priceBreak : int * discountPrice : float
    | NormalItem of productCode : string * price : float

let calculatePriceWithDiscounts numberOfItems basePrice priceBreak discountedPrice =
    (float(numberOfItems / priceBreak) * discountedPrice) + (float(numberOfItems % priceBreak) * basePrice)

let calculatePriceNoDiscount numberOfItems basePrice = 
    float(numberOfItems) * basePrice

let price item count =
    match item with
        | DiscountedItem(c, p, b, d) -> calculatePriceWithDiscounts count p b d
        | NormalItem(c, p) -> calculatePriceNoDiscount count p

let productCode item =
    match item with
        | DiscountedItem(c, _, _, _) -> c
        | NormalItem(c, _) -> c

let checkout list =

    [DiscountedItem("Apple", 0.3, 4, 1.0);
    DiscountedItem("Deodorant", 2.5, 2, 4.5);
    NormalItem("Coke", 1.8);
    NormalItem("Bean", 0.5)] 
    |> List.sumBy (fun item -> 
                                let numberOfItems = list |> List.filter(fun i -> i = productCode item) |> List.length
                                price item numberOfItems)

//    let apples = list |> List.filter(fun i -> i = "Apple") |> List.length
//    let beans = list |> List.filter(fun i -> i = "Bean")  |> List.length
//    let coke = list |> List.filter(fun i -> i = "Coke")  |> List.length
//    let deodorant = list |> List.filter(fun i -> i = "Deodorant")  |> List.length
    


//    (price applePrice apples) +
//    (price deodorantPrice deodorant) +
//    (price cokePrice coke) +
//    (price beanPrice beans)
//    (calculatePrice apples 0.3 4 1.0) +
//    (calculatePrice deodorant 2.5 2 4.5) +
//    (calculatePrice beans 0.5 1 0.5) +
//    (calculatePrice coke 1.8 1 1.8) 
