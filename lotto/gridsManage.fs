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

: getGridAddr ( n -- addr n )
    nbsPerGrid@ dup >r *
    getLOTTOdatasAddr + r>
  ;

: getNumber ( addr -- addr+1 n )
    dup 1+ swap c@
  ;

\ search n in grid
: inGrid? { n gridPos -- fl }
    0 { fl } 
    gridPos getGridAddr
    for
        aft 
            getNumber n =
            if
                -1 to fl
            then
        then
    next
    drop 
    fl
  ;

: ## ( n -- addr len )
    base @ >r decimal
    <# # # #>
    r> base !
  ;

 0 constant BLACK
 1 constant RED
11 constant YELLOW
15 constant WHITE

: .nWitheBlack
 ( n -- )
    WHITE fg  BLACK bg
    ## type
    space
  ;

: .nYellowRed ( n -- )
    YELLOW fg  RED bg
    ## type
    WHITE fg  BLACK bg
    space
  ;

: .grid { gridPos -- }
    gridPos 1- nbgrids@ >=
    if
        FRENCH  ?\ gridPos . ." hors limite"
        ENGLISH ?\ gridPos . ." out of range"
        exit
    then
    cr
    NR_RANGE 0 do
        i 1+ gridPos inGrid?
        if
            i 1+ .nYellowRed
        else
            i 1+ .nWitheBlack
        then
        space
        i 1+ nbsPerGrid@ mod 0=
        if
            cr
        then
    loop
  ;



