\ *********************************************************************
\ choice a string in a list
\    Filename:      stringsChoice.fs
\    Date:          07 mar 2023
\    Updated:       07 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************




\ display a list with n choices; first item is title of choices
: dispOptionList { addr -- }
    0 { nbItems }
    0 { index }
    addr ->nbStrings @ to nbItems
    0 addr zStrType  cr     \ display item 0
    nbItems 2 - for
        nbItems i - 1- to index
        2 spaces 
        index [char] @ + emit ." .."
        index addr zStrType cr
    next
  ;


\ options list example
6 strArray: configSelect
  FRENCH [IF]
        z" Sélection de votre configuration:"       zStr!
    [ELSE]
        z" Select your configuration:"               zStr!
    [THEN]
    z" Windows 10"      zStr!
    z" Windows 11"      zStr!
    z" Linux Ubuntu "   zStr!
    z" Mac OS"          zStr!
    z" Other"           zStr!

configSelect dispOptionList

