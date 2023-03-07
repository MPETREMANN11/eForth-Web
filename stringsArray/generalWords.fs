\ *********************************************************************
\ general words for STRINGS ARRAY program
\    Filename:      generalWords.fs
\    Date:          04 mar 2023
\    Updated:       07 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

\ if lowercase char pressed, convert to UPPERcase
: Xkey ( key -- KEY )
    key dup [CHAR] Z >
    if   32 -  then
  ;

structures
struct STR-ARRAY
    ptr field ->nbStrings       \ quantity of strings in array
    ptr field ->optionChoice    \ selected option choice
    ptr field ->strDatas        \ strings datas in array
forth

\ pointer for string storing
0 value STR_INDEX

\ define a string array
: strArray:  ( comp: n -- | exec: -- addr )
    create
        dup ,               \ compile nbStrings
        0 ,                 \ compile option choice, 0 by default
        here to STR_INDEX
        cell * allot
    does>
  ;

\ store z-string in string array defined by strArray
: zStr! ( addr -- )
    STR_INDEX !
    cell +to STR_INDEX
  ;

\ test if index n is out of range
: indexOutRangeTest ( n addr -- )
    2dup
    ->nbStrings @ >
    if
        FRENCH  ?\ abort" index hors limite! "
        ENGLISH ?\ abort" index out of range! "
    then
  ;

\ get addr for zString in position n
: zStr@ ( n addr -- zStrAddr )
    indexOutRangeTest
    ->strDatas swap
    cell * + @
  ;

\ display zString in position n
: zStrType ( n addr -- )
    zStr@ z>s type
  ;

\ display all options in a zStr list
: dispZstrList { addr -- }
    0 { nbItems }
    addr ->nbStrings @ to nbItems
    nbItems 1- for
        nbItems 1- i - addr zStrType  cr
    next
  ;




