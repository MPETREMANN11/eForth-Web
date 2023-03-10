\ *********************************************************************
\ Graphics tests for windows
\    Filename:      graphicsTests.fs
\    Date:          09 mar 2023
\    Updated:       09 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


graphics

\ -1 -1 window
640 480 window


$ff0000 constant red
$ffff00 constant yellow
$000000 constant black

: draw
\     black to color  
\     20 20 LineTo
;

: run
    begin
        poll
        IDLE event =  if draw then
        event FINISHED = 
    until
\     bye
;
run


