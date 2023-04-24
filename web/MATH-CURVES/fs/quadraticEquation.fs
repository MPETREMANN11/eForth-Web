\ *********************************************************************
\ definition of quadratic equation
\    Filename:      quadraticEquation.fs
\    Date:          22 apr 2023
\    Updated:       23 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

fvariable a
fvariable b
fvariable c
fvariable d

\ quadratic equation with real values
: ax2+bx+c ( x -- y )
    >r
    r@ s>f                  \ convert x in float value
    2e F** a SF@ F*         \ calc: ax2
    r@ s>f
    b SF@  F*  F+           \ calc: +bx
    c SF@  F+               \ calc: +c
    f>s
    rdrop
  ;
        
: quad.equat1 ( -- )
      0.2e Fscale* a SF!
      -4e Fscale* b SF!
      0e Fscale* c SF!
  ;

: ax3+bx2+cx+d ( x -- y )
    >r
    r@ s>f
    3e f** a SF@ F*         \ calc: ax3
    r@ s>f
    2e F** b SF@ F* F+      \ calc: +bx2
    r@ s>f
    c SF@ F*  F+            \ calc: +cx
    d SF@ F+                \ calc: +d
    f>s
    rdrop
  ;

: quad.equat2 ( -- )
      -0.05e    Fscale* a SF!
      0.4e      Fscale* b SF!
      3e        Fscale* c SF!
      0e        Fscale* d SF!
  ;

