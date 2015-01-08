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
   "Apple" '0.3
   "Banana" '0.5
   "Coke" '1.8
   "Deodorant" '2.5
   ))

(check-equal? (calc-total '() prices) 0 "Empty list gives zero")

(check-equal? (calc-total '("Apple") prices) 0.3 "Single apple gives total")

(check-equal? (calc-total '("Apple" "Apple") prices) 0.6 "Multiple apple gives total")

(check-equal? (calc-total '("Banana") prices) 0.5 "Single banana gives total")

(check-equal? (calc-total '("Apple" "Banana" "Coke" "Deodorant") prices) (+ 0.3 0.5 1.8 2.5) "All single prices work")

(check-equal? (calc-total '("Deodorant" "Deodorant") prices) 4.5 "Single discount works")

"**********************"
"*** Tests Complete ***"
"**********************"