#lang racket

(define (calc-total items prices)
  (* (length items) prices))

(define (lookup-price item prices)
  (hash-ref prices item))

(define (sum-items items prices)
  (if (null? items)
     0
     (+ (lookup-price (first items) prices) (sum-items (rest items) prices))
   )
  )

(define (calc-total2 items prices)
  (cond
    [(= (length items) 0) 
     0]
    [else 
     (sum-items items prices)
     ;(* (length items) (hash-ref prices (list-ref items 0)))
     ]
    ))

(provide calc-total calc-total2)