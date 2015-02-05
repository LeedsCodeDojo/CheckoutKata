#lang racket

; calculates total by taking discount from prices
(define (calculate-total items prices discounts)
  (- (calculate-undiscounted-price items prices)
     (calculate-discount items discounts)))

; adds all of the prices up
(define (calculate-undiscounted-price items prices)
  (cond 
    ((null? items) 0)
    (else (+ (lookup-price (first items) prices) 
             (calculate-undiscounted-price (rest items) prices)))))

; adds all of the discounts up
(define (calculate-discount items discounts)
  (cond
    ((null? discounts) 0)
    (else (+ (discount-for items (car discounts))
             (calculate-discount items (cdr discounts))))))

; gets the discount value for an individual discount
(define (discount-for items discount)
  (cond
    ((eq? (count-item-occurances (discount-item discount) items)
          (item-count discount))
     (discount-value discount))
    (else 0)))

; helpers
(define (lookup-price item prices)
  (hash-ref prices item))

(define (discount-item discount)
  (car discount))

(define (item-count discount)
  (caadr discount))

(define (discount-value discount)
  (car (cdr (car (cdr discount)))))

(define (count-item-occurances item items)
  (cond
    ((null? items) 0)
    ((eq? (car items) item) (+ 1 (count-item-occurances item (cdr items))))
    (else (count-item-occurances item (cdr items)))))
  
(provide calculate-total)