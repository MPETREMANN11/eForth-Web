\ *********************************************************************
\ days of week example
\    Filename:      weekDaysExample.fs
\    Date:          05 mar 2023
\    Updated:       07 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


7 strArray: days
  FRENCH [IF]
    z" Lundi"       zStr!
    z" Mardi"       zStr!
    z" Mercredi"    zStr!
    z" Jeudi"       zStr!
    z" Vendredi"    zStr!
    z" Samedi"      zStr!
    z" Dimanche"    zStr!
  [ELSE]
    z" Monday"      zStr!
    z" Tuesday"     zStr!
    z" Wednesday"   zStr!
    z" Thursday "   zStr!
    z" Friday"      zStr!
    z" Saturday"    zStr!
    z" Sunday"      zStr!
  [THEN]

\ use example: 
0 days zStrType cr
3 days zStrType cr

