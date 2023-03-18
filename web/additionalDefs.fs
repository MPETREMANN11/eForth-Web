\ *********************************************************************
\ additional definitions for eFORTH web
\    Filename:      additionalDefs.fs
\    Date:          14 mar 2023
\    Updated:       18 mar 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

\ doc: https://developer.mozilla.org/fr/docs/Web/API/Canvas_API/Tutorial/Applying_styles_and_colors

web definitions

\ *** DATE and TIME words ******************************************************

\ push current year month and day on stack
JSWORD: date@ { -- y m d }
    let date = new Date();
    return [date.getFullYear(), date.getMonth()+1, date.getUTCDate()];
~

\ push current hour minutes and seconds on stack
JSWORD: time@ { -- h m s }
    let date = new Date();
    return [date.getHours(), date.getMinutes(), date.getSeconds()];
~


\ *** GRAPHIC extensions words *************************************************

\ draw ellipse
\ draw ellipse
JSWORD: ellipse { x y rx ry angle div }
  context.ctx.ellipse(x, y, rx, ry, Math.PI * 2 * angle / div, 0, 2 * Math.PI);
~
\ usage, draw ellipse with red border
\ $ff0000 color!
\ 100 100 75 30 0 360 ellipse stroke


\ write text in graphic mode
JSWORD: fillText { a n x y -- }
  context.ctx.fillText(GetString(a, n), x, y);
~
\ usage
\ $ff0000 color!
\ s" test" 20 30 fillText



\ @TODO: Autres fonctions à creuser:
\ fillStyle
\ rect
\ strokeRect
\     ctx.strokeStyle = "green";
\     ctx.strokeRect(20, 10, 160, 100);



forth definitions
