\ *********************************************************************
\ Graphics tests for windows
\    Filename:      graphicsTests.fs
\    Date:          09 mar 2023
\    Updated:       10 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


graphics

-1 -1 window


$ff0000 constant red
$ffff00 constant yellow
$000000 constant black

graphics internals

: drawLines 
    20 20 LineTo  
    50 20 LineTo 
    50 50 LineTo 
    20 50 LineTo 
    45 45 LineTo 
;

: run
  begin
    poll
    IDLE event = if
        black to color 
        drawLines
\         0 0 width height box
\       g{
\         vertical-flip
\         640 480 viewport
\         gray to color
\         0 0 640 480 box
\         dark-gray to color
\         0 0 400 300 box
\         g{
\           mouse-x mouse-y screen>g translate
\           LEFT-BUTTON pressed? if
\             g{ -100 -100 translate  red to color     -50 -50 100 100 box }g
\             g{ 100 -100 translate   yellow to color  -50 -50 100 100 box }g
\             g{ -100 100 translate   green to color   -50 -50 100 100 box }g
\             g{ 100 100 translate    blue to color    -50 -50 100 100 box }g
\           then
\           g{ white to color   -50 -50 100 100 box }g
\         }g
\       }g
        flip
    then
    event FINISHED = until
    key drop
\   bye
;
\ run




