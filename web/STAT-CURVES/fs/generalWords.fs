\ *********************************************************************
\ general words
\    Filename:      generalWords.fs
\    Date:          30 apr 2023
\    Updated:       30 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


\ align loop in multiple of GRID_STEP
: alignIndex ( n -- n' )
    GRID_STEP / GRID_STEP *
  ;

\ change equation draw scale
: changeScale ( scale -- )
    EQUATION_SCALE !
  ;

