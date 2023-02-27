\ *********************************************************************
\ LOTO game main file
\    Filename:      main.fs
\    Date:          27 feb 2023
\    Updated:       27 feb 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

: LOTO
    s" loto/main.fs" included ;

DEFINED? --loto [if] forget --loto  [then]
create --loto



structures
struct LOTO
     i8 field >nbsPerGrid       \ quantity of numbers per grid
    i16 field >nbgrids          \ number of grids stored
    i16 field >datas            \ datas in array

: nbsPerGrid@ ( addr -- n )
    >nbsPerGrid c@
  ;

: nbgrids@ ( addr -- n )
    >nbgrids uw@
  ;

s" winingNumbers.fs" included


\ create myNumbers
\     10 c,   13 c,   24 c,   41 c,   44 c,


