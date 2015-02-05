#lang racket

; Apple $0.3 or 4 for $1
; Banana $0.5
; Coke $1.80
; Deodorant $2.50 or 2 for $4.50

(require rackunit
         "Checkout.rkt")

(define prices 
  (hash
   null 0.0
   "Apple" 30
   "Banana" 50
   "Coke" 180
   "Deodorant" 250))

(define discounts
  '(("Apple" (4 20))
    ("Deodorant" (2 50))))

(define (priceof item)
  (hash-ref prices item))

(check-equal? (calculate-total '() prices discounts) 
              0 
              "Empty list gives zero")

(check-equal? (calculate-total '("Apple") prices discounts) 
              (priceof "Apple") 
              "Single apple gives total")

(check-equal? (calculate-total '("Apple" "Apple") prices discounts) 
              (* 2 (priceof "Apple")) 
              "Multiple apple gives total")

(check-equal? (calculate-total '("Banana") prices discounts) 
              (priceof "Banana") 
              "Single banana gives total")

(check-equal? (calculate-total '("Apple" "Banana" "Coke" "Deodorant") prices discounts) 
              (+ (priceof "Apple") (priceof "Banana") (priceof "Coke") (priceof "Deodorant")) 
              "All single prices work")

(check-equal? (calculate-total '("Apple" "Apple" "Apple" "Apple") prices discounts) 
              100 
              "Apple discount works")

(check-equal? (calculate-total '("Deodorant" "Deodorant") prices discounts) 
              450 
              "Deodorant discount works")

(check-equal? (calculate-total '("Apple" "Apple" "Deodorant" "Apple" "Deodorant" "Apple" ) prices discounts) 
              550 
              "Multiple discounts work for unordered items")

; next: same discount multiple times

"**********************"
"*** Tests Complete ***"
"**********************"