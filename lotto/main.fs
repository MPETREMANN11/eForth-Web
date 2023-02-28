\ *********************************************************************
\ LOTTO game main file
\    Filename:      main.fs
\    Date:          27 feb 2023
\    Updated:       28 feb 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

DEFINED? --loto [if] forget --loto  [then]
create --loto

\ The LOTTOdatas vector makes it possible to manage any type 
\ of grid, for example 5x50 or 6x49 or other...
defer LOTTOdatas

\ defines the number of possible numbers, range 01..50 by default
50 value NR_RANGE

structures
struct LOTTO
    ptr field >nbsPerGrid       \ quantity of numbers per grid
    ptr field >nbgrids          \ number of grids stored
    ptr field >datas            \ datas in array
forth

\ fetch the number of numbers in a grid
: nbsPerGrid@ ( -- n )
    LOTTOdatas >nbsPerGrid @
  ;

\ fetch the number of grids
: nbgrids@ ( -- n )
    LOTTOdatas >nbgrids @
  ;

\ get address datas
: getLOTTOdatasAddr ( -- addr )
    LOTTOdatas >datas
  ;


\ load and link lotto data
s" euroMillionFR.fs" included

\ update >nbgrids field
here getLOTTOdatasAddr -
nbsPerGrid@ /
LOTTOdatas >nbgrids !

\ load Manage content of LOTTO grids
s" gridsManage.fs" included



\ create myNumbers
\     10 c,   13 c,   24 c,   41 c,   44 c,


