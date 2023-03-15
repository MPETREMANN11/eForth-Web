\ *********************************************************************
\ additional definitions for eFORTH web
\    Filename:      additionalDefs.fs
\    Date:          14 mar 2023
\    Updated:       15 mar 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************



web definitions

\ draw ellipse
JSWORD: ellipse { x y rx ry rot }
  context.ctx.ellipse(x, y, rx, ry, rot * Math.PI/180, 0, 2 * Math.PI);
  context.ctx.stroke();
~
\ usage, draw a red ellipse
\ $ff0000 color!
\ 100 100 75 30 0 ellipse


\ write text in graphic mode
JSWORD: fillText { a n x y -- }
  context.ctx.fillText(GetString(a, n), x, y);
~
\ usage
\ $ff0000 color!
\ s" test" 20 30 fillText



\ @TODO: Autres fonctions à creuser:
\ rotate
\ fillStyle
\ fill
\ rect
\ strokeRect
\     ctx.strokeStyle = "green";
\     ctx.strokeRect(20, 10, 160, 100);



forth definitions
