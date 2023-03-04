\ *********************************************************************
\ Heads and tails trace
\    Filename:      HTtrace.fs
\    Date:          03 mar 2023
\    Updated:       03 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

\ set size of work area
180 value X_SIZE
 50 value Y_SIZE

\ values for display position
0 value _DX
0 value _DY

\ increment _DX
: dx++ ( -- )
    1 +to _DX
  ;

\ increment _DY
: dy++ ( -- )
    1 +to _DY
  ;

\ decrement _DY
: dy-- ( -- )
    -1 +to _DY
  ;

char * value CHAR_TO_DISPLAY

: displayCharAtXY ( -- )
    _DX _DY at-xy 
    CHAR_TO_DISPLAY emit
  ;

15 constant COLOR_WHITE
 0 constant COLOR_BLACK

\ memorisation of randomly selected foreground color
0 value DISPLAY_COLOR


\ set color randomly
: setColorRandomly ( -- )
    240 random 16 + to DISPLAY_COLOR
  ;

5 value TRACE_DELAY

\ set trace start point
: setStartPoint ( -- )
    0 to _DX            \ allways 0 for left start point
    Y_SIZE 2/ to _DY    \ 
  ;

: setNextPoint ( -- )
    dx++
    100 random 50 > if
        dy++
    else
        dy--
    then
  ;


: traceLoop ( -- )
    setStartPoint
    setColorRandomly
    DISPLAY_COLOR fg
    X_SIZE for
        aft
            displayCharAtXY
            TRACE_DELAY ms  \ delay before next char display
            setNextPoint
        then
    next
    COLOR_WHITE fg
  ;

: initColors
    COLOR_BLACK bg
    COLOR_WHITE fg
  ;
    

: multiTrace ( n -- )
    initColors
    page
    for
        traceLoop
    next
    initColors
  ;




