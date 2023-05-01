\ *********************************************************************
\ draw grid in canvas array
\    Filename:      drawStatGridAndAxes.fs
\    Date:          30 apr 2023
\    Updated:       01 may 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************



web

\ set X Y grid origin in upper left corner of canvas
: initStatGrid ( -- )
  ;

\ draw vertical lines
: drawVerticalLinesOfGrid ( -- )
    ctxWidth 0 do
        beginPath
        i 0 moveTo
        i ctxHeight lineTo
        stroke
        closePath
    GRID_STEP +loop
  ;

\ draw horizontal lines
: drawHorizontalLinesOfGrid ( -- )
    ctxHeight 0 do
        beginPath
        0 i moveTo
        ctxWidth i lineTo
        stroke
        closePath
    GRID_STEP +loop
  ;

\ draw grid in ultra light grey
: drawStatXYgrid ( -- )
    COLOR_Gainsboro color!
    drawVerticalLinesOfGrid
    drawHorizontalLinesOfGrid
  ;

\ draw X axis
: drawHorizontalAxis ( -- )
    beginPath
    0 CANVAS_Y_MIDDLE moveTo
    ctxWidth CANVAS_Y_MIDDLE lineto stroke
    closePath
  ;

\ draw Y axis
: drawVerticalAxis ( -- )
    beginPath
    0 0 moveTo
    0 ctxHeight lineto stroke
    closePath
  ;

GRID_STEP 5 / 2* 
constant GRADUATION_SIZE

\ draw vertical graduations
: drawVerticalGraduations ( -- )
    ctxWidth alignIndex 0 do
        beginPath
        i CANVAS_Y_MIDDLE GRADUATION_SIZE - moveTo  
        i CANVAS_Y_MIDDLE GRADUATION_SIZE + lineTo  stroke
        closePath
    GRID_STEP +loop
  ;

\ draw horizontal graduations
: drawHorizontalGraduations ( -- )
    ctxHeight 0 do
        beginPath
        GRADUATION_SIZE negate i moveTo  GRADUATION_SIZE i lineTo  stroke
        closePath
    GRID_STEP +loop
  ;

\ draw STAT grid, axes and graduations
: drawStatGrid ( -- )
    initStatGrid
    drawStatXYgrid
    COLOR_Gray color!
    drawVerticalGraduations
    drawHorizontalGraduations
    COLOR_BLACK color!
    drawHorizontalAxis
    drawVerticalAxis
  ;

forth
