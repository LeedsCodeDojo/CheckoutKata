#lang racket/base

(define (calc-total items prices)
  (* (length items) prices))

(provide calc-total)