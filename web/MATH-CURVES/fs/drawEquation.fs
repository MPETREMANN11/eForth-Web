\ *********************************************************************
\ draw equation
\    Filename:      drawEquation.fs
\    Date:          21 apr 2023
\    Updated:       23 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


: Fscale* ( f -- f' )
   EQUATION_SCALE @ S>F F*
  ;

: Nscale* ( n -- n' )
   EQUATION_SCALE @ *
  ;

: Nscale/ ( n -- n' )
   EQUATION_SCALE @ /
  ;


defer equation

web

: initialPosition ( -- )
    CANVAS_X_MIDDLE negate 
    dup Nscale* swap 
    equation moveTo
  ;


: trace
    2dup
    ."  : " . . 
    key drop
  ;

: isIndexInCanvas? ( i -- fl )
    Nscale* >r
    r@ CANVAS_X_MIDDLE negate >=
    r@ CANVAS_X_MIDDLE <= and
    rdrop
  ;

: drawEquation ( -- )
    beginPath
    initialPosition
    CANVAS_X_MIDDLE 1+ CANVAS_X_MIDDLE negate do
        i isIndexInCanvas? if
            i dup Nscale* swap equation 
\             trace
            lineTo
            stroke
        then
    loop
    closePath
  ;

forth

