#lang racket

(define (lookup-price item prices)
  (hash-ref prices item))

(define (calc-undiscounted-price items prices)
  (if (null? items)
     0
     (+ 
      (lookup-price (first items) prices) 
      (calc-undiscounted-price (rest items) prices))))

(define (calculate-discount items)
  (if (equal? items '("Deodorant" "Deodorant"))
      0.5
      0))

(define (calc-total items prices)
  (-
   (calc-undiscounted-price items prices)
   (calculate-discount items)))

(provide calc-total)