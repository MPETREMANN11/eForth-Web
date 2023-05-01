\ *********************************************************************
\ Heads or Tails stats draw
\    Filename:      headsorTails.fs
\    Date:          30 apr 2023
\    Updated:       01 may 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

$8080ff constant COLOR_INITIAL_PLOT

$90 constant LINES_DRAWS_NUMBER


0 value PIXEL_COLOR
0 value Y_PIXEL_POSITION

$202000 constant COLOR_STEP_DECAY


web 

\ change pixel color at x y position from lighter blue to 
\ darker blue.
: getAndChangePixelColor ( x y -- )
    getPixelColor >r
    r@ $0000ff and $ff = if   \ test if pixel color is in blue color range
        r@ COLOR_STEP_DECAY -  to PIXEL_COLOR
\         r@ .
    else
        COLOR_INITIAL_PLOT to PIXEL_COLOR
    then
    rdrop
  ;


\ display 1 pixel at X Y with color defined by PIXEL_COLOR
: plot ( x y -- )
    PIXEL_COLOR color!
    1 1 box
  ;


1 constant SORT_HEAD
2 constant SORT_TAIL

100 constant SORT_AMPLITUDE

\ sort randomly HEAD or TAIL
: sortHeadTail ( -- sortVal )
    SORT_AMPLITUDE random
    SORT_AMPLITUDE 2/ > if
        SORT_HEAD
    else
        SORT_TAIL
    then
  ;

\ set new Y position randomly
: randomYpositionMove ( -- )
    sortHeadTail SORT_HEAD = if
         1 +to Y_PIXEL_POSITION
    else
        -1 +to Y_PIXEL_POSITION
    then
  ;


: drawHeadTailsSort ( -- )
    CANVAS_Y_MIDDLE to Y_PIXEL_POSITION
    ctxWidth 0 do
        i Y_PIXEL_POSITION getAndChangePixelColor
        i Y_PIXEL_POSITION plot
        randomYpositionMove
    loop
  ;

: drawHeadTailsStats ( -- )
    COLOR_INITIAL_PLOT color!
    16 0 do
        drawHeadTailsSort
    loop
  ;

