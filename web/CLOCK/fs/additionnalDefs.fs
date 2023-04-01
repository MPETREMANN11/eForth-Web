\ *********************************************************************
\ additional definitions for eFORTH web
\    Filename:      additionalDefs.fs
\    Date:          14 mar 2023
\    Updated:       31 mar 2023
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

JSWORD: arc { x y r a0 ax div }
  context.ctx.arc(x, y, r, (Math.PI * 2 * a0) / div, (Math.PI * 2 * ax) / div);
~
\ usage:
\ beginPath  100 100 60   0  90 360 arc stroke

: circle { x y r }
    x y r 0 360 360 arc
  ;


\ clip path 
JSWORD: clip { }
    context.ctx.clip();
~


\ clear rectangle
JSWORD: clearRect { x y width height }
    context.ctx.clearRect(x, y, width, height);
~


JSWORD: drawImage { a n x y }
    let img = new Image();
    img.src = GetString(a, n);
    if(img.complete){
        context.ctx.drawImage(img, x, y);
    }
~


\ get image datas
JSWORD: getImageData { x y width height }
    context.ctx.getImageData(x, y, width, height);
~


JSWORD: imageSize { a n -- w h }
    let img = new Image();
    img.src = GetString(a, n);
    if(img.complete){
        return [img.naturalWidth, img.naturalHeight];
    }  
~


\ draw ellipse
JSWORD: ellipse { x y rx ry angle div }
  context.ctx.ellipse(x, y, rx, ry, Math.PI * 2 * angle / div, 0, 2 * Math.PI);
~
\ usage, draw ellipse with red border
\ $ff0000 color!
\ 100 100 75 30 0 360 ellipse stroke


JSWORD: globalAlpha! { val div }
    context.ctx.globalAlpha = val/div;
~
\ usage, draw semi transparent rect:
\ 7 10 globalAlpha!
\ $ffffff color!
\ 10 10 100 20 rect fill


\ define text write direction
\ values: ltr rtl inherit ; inherit by default
JSWORD: direction { a n x y -- }
  context.ctx.direction = GetString(a, n);
~


\ write text in graphic mode
JSWORD: strokeText { a n x y -- }
  context.ctx.strokeText(GetString(a, n), x, y);
~
\ usage
\ $ff0000 color!
\ s" test" 20 30 strokeText


\ possible values: start end left right or center; default: start
JSWORD: textAlign { a n -- } 
  context.ctx.textAlign = GetString(a, n); 
~ 
\ usage:
\ s" center" textAlign



\ draw rectangle
JSWORD: rect { x y width height }
    context.ctx.rect(x, y, width, height);
~
\ usage:
\ $0000ff color!
\ 10 10 100 20 rect stroke


\ reset translate and rotate
JSWORD: resetTransform { }
  context.ctx.resetTransform();
~


\ @TODO: à creuser

\ createConicGradient(startAngle, x, y)

\ createLinearGradient(x0, y0, x1, y1)

\ createRadialGradient(x0, y0, r0, x1, y1, r1)

\ direction

\ filter

\ isPointInPath(x, y)

\ isPointInStroke(x, y)

\ putImageData(imageData, dx, dy)

\ quadraticCurveTo(cpx, cpy, x, y)

\ reset()

forth definitions
