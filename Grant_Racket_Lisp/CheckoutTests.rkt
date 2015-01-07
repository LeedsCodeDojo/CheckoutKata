#lang racket

; Apple $0.3 or 4 for $1
; Banana $0.5
; Coke $1.80
; Deodorant $2.50 or 2 for $4.50

(require rackunit
         "Checkout.rkt")

(define prices 
  (hash
   null '0.0
   "Apple" '0.2
   "Banana" '0.4))

(check-equal? (calc-total2 '() prices) 0 "Empty list gives zero")

(check-equal? (calc-total2 '("Apple") prices) 0.2 "Single apple gives total")

(check-equal? (calc-total2 '("Apple" "Apple") prices) 0.4 "Multiple apple gives total")

(check-equal? (calc-total2 '("Banana") prices) 0.4 "Single banana gives total")

"**********************"
"*** Tests Complete ***"
"**********************"