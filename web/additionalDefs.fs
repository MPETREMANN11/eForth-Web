\ *********************************************************************
\ additional definitions for eFORTH web
\    Filename:      additionalDefs.fs
\    Date:          14 mar 2023
\    Updated:       14 mar 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************



web definitions

\ write text in graphic mode
JSWORD: fillText { a n x y }
  context.ctx.fillText(GetString(a, n), x, y);
~
\ usage
\ $ff0000 color!
\ s" test" 20 30 fillText




forth definitions
