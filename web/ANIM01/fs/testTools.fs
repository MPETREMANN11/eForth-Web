\ *********************************************************************
\ test tools for anim01.fs
\    Filename:      testTools.fs
\    Date:          01 apr 2023
\    Updated:       01 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

\ display mouse position
: mouseTest ( -- )
    begin
        key
        mouse swap
        cr ." Mouse position, x: " . ."   y: " . 4 spaces
        \ key tested here, exit if <RET> pressed
    13 = until
  ;

