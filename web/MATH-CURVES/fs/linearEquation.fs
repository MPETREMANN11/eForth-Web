\ *********************************************************************
\ definition of linear equation
\    Filename:      linearEquation.fs
\    Date:          21 apr 2023
\    Updated:       21 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

fvariable a
fvariable b

\ linear equation
: ax+b { x -- y }
    x s>f                   \ convert x in float value
    a SF@  F*   b SF@  F+   \ calc: ax+b
    f>s
  ;
    
: line.equat1 ( -- )
    0.5e Fscale a SF!
      2e Fscale b SF!
  ;

: line.equat2 ( -- )
     -1e Fscale a SF!
      5e Fscale b SF!
  ;

