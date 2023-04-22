\ *********************************************************************
\ draw equation
\    Filename:      drawEquation.fs
\    Date:          21 apr 2023
\    Updated:       21 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

defer equation

: Fscale ( f -- f' )
    EQUATION_SCALE S>F F*
  ;

: Nscale ( n -- n' )
    EQUATION_SCALE *
  ;

web

: initialPosition ( -- )
    CANVAS_X_MIDDLE negate 
    dup Nscale swap 
    equation moveTo
  ;


: drawEquation ( -- )
    beginPath
    initialPosition
    CANVAS_X_MIDDLE CANVAS_X_MIDDLE negate do
        i dup Nscale swap equation lineTo
        stroke
    EQUATION_SCALE +loop
    closePath
  ;

forth

