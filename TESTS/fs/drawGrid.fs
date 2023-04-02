\ *********************************************************************
\ draw grid in canvas array
\    Filename:      drawGrid.fs
\    Date:          02 apr 2023
\    Updated:       02 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************



 20 value GRID_STEP

web
: drawGrid ( -- )
    \ draw vertical lines
    ctxWidth 0 do
        beginPath
        i 0 moveTo
        i ctxWidth lineTo
        stroke
    GRID_STEP +loop
    \ draw horizontal lines
    ctxHeight 0 do
        beginPath
        0 i moveTo
        ctxWidth i lineTo
        stroke
    GRID_STEP +loop
  ;

