#lang racket/base

; "Apple" $0.2
; Banana" $0.4 or 3 for $1

(require rackunit
         "Checkout.rkt")

(check-equal? (calc-total '() 0.2) 0 "Empty list gives zero")

(check-equal? (calc-total '("Apple") 0.2) 0.2 "Single apple gives total")

(check-equal? (calc-total '("Apple" "Apple") 0.2) 0.4 "Multiple apple gives total")

(check-equal? (calc-total '("Banana") '(0.2 0.4)) 0.4 "Single banana gives total")

"**********************"
"*** Tests Complete ***"
"**********************"