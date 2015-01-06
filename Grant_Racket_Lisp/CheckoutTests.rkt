#lang racket/base

(require rackunit
         "Checkout.rkt")

(check-equal? (calc-total '("A" "B" "C")) 0 "Dummy test")

"**********************"
"*** Tests Complete ***"
"**********************"