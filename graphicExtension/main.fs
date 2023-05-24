\ *********************************************************************
\ Graphics extensions main file
\    Filename:      main.fs
\    Date:          09 mar 2023
\    Updated:       24 may 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

DEFINED? --grExt [if] forget --grExt  [then]
create --grExt

\ load graphics extensions
s" graphicsExtensions.fs" included

\ load graphics tests
s" config.fs" included

\ load graphics tests
s" graphicsTests.fs" included
