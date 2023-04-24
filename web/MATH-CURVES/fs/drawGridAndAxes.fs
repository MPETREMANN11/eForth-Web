\ *********************************************************************
\ draw grid in canvas array
\    Filename:      drawGridAndAxes.fs
\    Date:          21 apr 2023
\    Updated:       23 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************




\ align loop in multiple of GRID_STEP
: alignIndex ( n -- n' )
    GRID_STEP / GRID_STEP *
  ;

\ change equation draw scale
: changeScale ( scale -- )
    EQUATION_SCALE !
  ;

web

\ set grid origin in middle X and Y of canvas
: initGrid ( -- )
    CANVAS_X_MIDDLE  CANVAS_Y_MIDDLE  translate
    100 -100 100 scale
  ;

\ draw grid in ultra light grey
: drawXYgrid ( -- )
    COLOR_Gainsboro color!
    \ draw vertical lines
    CANVAS_X_MIDDLE alignIndex dup negate do
        beginPath
        i CANVAS_Y_MIDDLE negate moveTo
        i CANVAS_Y_MIDDLE lineTo
        stroke
        closePath
    GRID_STEP +loop
    \ draw horizontal lines
    CANVAS_Y_MIDDLE alignIndex dup negate do
        beginPath
        CANVAS_X_MIDDLE negate i moveTo
        CANVAS_X_MIDDLE i lineTo
        stroke
        closePath
    GRID_STEP +loop
  ;

\ draw X and Y axes
: drawAxes ( -- )
    COLOR_BLACK color!
    \ draw X axe
    beginPath
    CANVAS_X_MIDDLE negate 0 moveTo
    CANVAS_X_MIDDLE 0 lineto stroke
    closePath
    \ draw Y axe
    beginPath
    0 CANVAS_Y_MIDDLE negate moveTo
    0 CANVAS_Y_MIDDLE lineto stroke
    closePath
  ;

GRID_STEP 5 / 2* 
constant GRADUATION_SIZE

\ draw main graduations 
: drawMainGraduations ( -- )
    COLOR_Gray color!
    \ draw vertical graduations
    CANVAS_X_MIDDLE alignIndex dup negate do
        beginPath
        i GRADUATION_SIZE negate moveTo  i GRADUATION_SIZE lineTo  stroke
        closePath
    GRID_STEP +loop
    \ draw horizontal graduations
    CANVAS_Y_MIDDLE alignIndex dup negate do
        beginPath
        GRADUATION_SIZE negate i moveTo  GRADUATION_SIZE i lineTo  stroke
        closePath
    GRID_STEP +loop
  ;

\ draw grid, axes and graduations
: drawMathGrid ( -- )
    initGrid
    drawXYgrid
    drawAxes
    drawMainGraduations
  ;

forth
