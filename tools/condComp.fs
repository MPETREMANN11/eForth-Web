\ *********************************************************************
\ conditionnal compilation
\    Filename:      condComp.fs
\    Date:          01 mar 2023
\    Updated:       01 mar 2023
\    File Version:  1.0
\    Forth:         eFORTH
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

: ?\  ( fl --- )
    0=
    if
        postpone \
    then
; immediate

\ define language constants
 0 value FRENCH     immediate
-1 value ENGLISH    immediate


\ if the value used before ?\ is not nul,
\ the code following ?\ is compiled
\ otherwise the code will be ignored

\ Example usage:
\ : menuTitle
\     FRENCH  ?\ ." -- MENU GENERAL --"
\     ENGLISH ?\ ." -- GENERAL MENU --"
\     cr
\   ;


