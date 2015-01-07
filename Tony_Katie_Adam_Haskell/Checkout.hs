module Main where

import System.Environment (getArgs)
import Test.QuickCheck
import Test.Hspec

import Data.List (sort, group)

--checkout argument = case length argument of 1 -> 0.30
--                                            2 -> 0.80 
--                                            4 -> 1.00

--value :: [Char] -> Integer -> Float
--value "Apple" count = 1.0 * (floor (count / 4)) + 0.3 * (count `mod` 4)
--value "Deodorant" count = 4.5 * (floor (count / 2)) + 2.5 * (count `mod` 2)
--value "Beans" count = 0.5 * count
--value "Coke" count = 1.8 * count


count :: [a] -> (Int, a)
count things = (length things, head things)

productCount products = map count (group $ sort products)

value :: (Int, [Char]) -> Float
value (count, "Apple")     = 1.0 * fromIntegral (count `div` 4) + 0.3 * fromIntegral (count `mod` 4) 
value (count, "Deodorant") = 4.5 * fromIntegral (count `div` 2) + 2.5 * fromIntegral (count `mod` 2) 
value (count, "Beans")     = fromIntegral count * 0.5
value (count, "Coke")      = fromIntegral count * 1.8

checkout products = sum $ map value (productCount products)

spec = hspec $ do
    describe "checkout" $ do
        it "charges £0.30 for an apple" $ do
            checkout ["Apple"] `shouldBe` 0.30
        it "charges £0.80 for an apple and beans" $ do
            checkout ["Apple", "Beans"] `shouldBe` 0.80
        it "charges £1.00 for 4 apples" $ do
            checkout ["Apple", "Apple", "Apple", "Apple"] `shouldBe` 1.00
        it "charges £0.60 for two apples" $ do
            checkout ["Apple", "Apple"] `shouldBe` 0.60
    describe "productCount" $ do
        it "counts the correct number of a single product" $ do
            productCount ["Apple", "Apple"] `shouldBe` [(2, "Apple")]
        it "counts the correct number of multiple products" $ do
            productCount ["Apple", "Beans", "Apple"] `shouldBe` [(2, "Apple"), (1, "Beans")]

main = spec
