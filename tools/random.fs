\ *********************************************************************
\ simple random generator
\    Filename:      random.fs
\    Date:          03 mar 2023
\    Updated:       03 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Brad NELSON
\    Author:        Brad NELSON
\    GNU General Public License
\ *********************************************************************

1 31 lshift 1- constant max-random
0 value seed
: random ( n -- )
  seed max-random */
  seed 7127 + 7919 * max-random mod to seed
;

