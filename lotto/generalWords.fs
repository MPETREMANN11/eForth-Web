\ *********************************************************************
\ general words for LOTTO program
\    Filename:      generalWords.fs
\    Date:          02 mar 2023
\    Updated:       02 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

\ display n in width field
: .r ( n width -- )
    >r str
    r> over - 0 max spaces
    type
  ;

\ n in form 00..99
: ## ( n -- addr len )
    base @ >r decimal
    <# # # #>
    r> base !
  ;


\ The LOTTOdatas vector makes it possible to manage any type 
\ of grid, for example 5x50 or 6x49 or other...
defer LOTTOdatas

\ defines the number of possible numbers, range 01..50 by default
50 value NR_RANGE

structures
struct LOTTO
    ptr field ->nbsPerGrid       \ quantity of numbers per grid
    ptr field ->nbgrids          \ number of grids stored
    ptr field ->datas            \ datas in array
forth

\ fetch the number of numbers in a grid
: nbsPerGrid@ ( -- n )
    LOTTOdatas ->nbsPerGrid @
  ;

\ fetch the number of grids
: nbgrids@ ( -- n )
    LOTTOdatas ->nbgrids @
  ;

\ get address datas
: getLOTTOdatasAddr ( -- addr )
    LOTTOdatas ->datas
  ;
