\ *********************************************************************
\ LOTTO game main file
\    Filename:      main.fs
\    Date:          27 feb 2023
\    Updated:       02 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

DEFINED? --loto [if] forget --loto  [then]
create --loto

\ load general words
s" generalWords.fs" included

\ load and link lotto data
s" euroMillionFR.fs" included

\ update ->nbgrids field
here getLOTTOdatasAddr -
nbsPerGrid@ /
LOTTOdatas ->nbgrids !

\ load Manage content of LOTTO grids
s" gridsManage.fs" included

\ load stats frequency for LOTTO numbers
s" numbersFrequency.fs" included


\ create myNumbers
\     10 c,   13 c,   24 c,   41 c,   44 c,


