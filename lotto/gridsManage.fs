\ *********************************************************************
\ Manage content of LOTTO grids
\    Filename:      gridsManage.fs
\    Date:          28 feb 2023
\    Updated:       28 feb 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

: grid@ ( n -- c1 .. cx )
    0 do 
        i .
    loop
  ;
