\ *********************************************************************
\ additional definitions for eFORTH web
\    Filename:      additionalDefs.fs
\    Date:          14 mar 2023
\    Updated:       08 apr 2023
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


\ *** GRAPHIC extensions words ***  GET RELATIVE MOUSE POSITION FROM CANVAS  ***

\ The word mouse delivers the position of the mouse pointer from the origin x y (0, 0) 
\ of the HTML page and not from the origin of the canvas.
\ The word getMousePosition retrieves and recalculates the relative position of the 
\ mouse pointer from the origin of the canvas.
JSWORD: getMousePosition { -- mousex mousey }
    var offset = {x: 0, y: 0};
    var node = context.ctx.canvas;
    while (node) {
        offset.x += node.offsetLeft;
        offset.y += node.offsetTop;
        node = node.offsetParent;
    }
    return [context.mouse_x-offset.x, context.mouse_y-offset.y];
~



\ *** GRAPHIC extensions words ***  DRAW RECTANGLES   **************************

\ clear rectangle
JSWORD: clearRect { x y width height }
    context.ctx.clearRect(x, y, width, height);
~

\ fill rectangle
JSWORD: fillRect { x y width height }
    context.ctx.fillRect(x, y, width, height);
~

\ stroke rectangle
JSWORD: strokeRect { x y width height }
    context.ctx.strokeRect(x, y, width, height);
~



\ *** GRAPHIC extensions words ***  PATHS  *************************************

\ end a drawing path 
JSWORD: closePath {  }
  context.ctx.closePath();
~


\ draw ellipse
JSWORD: ellipse { x y rx ry angle div }
  context.ctx.ellipse(x, y, rx, ry, Math.PI * 2 * angle / div, 0, 2 * Math.PI);
~
\ usage, draw ellipse with red border
\ $ff0000 color!
\ 100 100 75 30 0 360 ellipse stroke


\ draw arc
JSWORD: arc { x y r a0 ax div }
  context.ctx.arc(x, y, r, (Math.PI * 2 * a0) / div, (Math.PI * 2 * ax) / div);
~
\ usage:
\ beginPath  100 100 60   0  90 360 arc stroke


\ draw circle
: circle { x y r }
    x y r 0 360 360 arc
  ;


\ join two lines with arc
JSWORD: arcTo { x1 y1 x2 y2 radius -- }
  context.ctx.arcTo(x1, y1, x2, y2, radius);
~


\ clip path 
JSWORD: clip { }
    context.ctx.clip();
~


\ print dashed lines
JSWORD: setLineDash  { n0 n1 }
  context.ctx.setLineDash([n0, n1]);
~
\ Usage:
\   10 10 setLineDash ( draw dashed line )
\    0  0 setLineDash ( draw full line )


\ set dash offset for dashed lines
JSWORD: lineDashOffset  { n }
  context.ctx.lineDashOffset = n;
~
\ Usage:
\   5 lineDashOffset


\ *** GRAPHIC extensions words ***  IMAGES  ************************************

\ draw image from file
JSWORD: drawImage { a n x y }
    let img = new Image();
    img.addEventListener('load', function() {
        context.ctx.drawImage(img, x, y);
    }, false);
    img.src = GetString(a, n);
~
\ usage:
\   s" ccar.jpg" drawImage


\ get pixel color at x y
JSWORD: getPixelColor { x y -- c }
    var pixel = context.ctx.getImageData(x, y, 1, 1);
    console.info(pixel);
    return pixel.data[0]*256*256 + pixel.data[1]*256 + pixel.data[2];
~

\ get size of loaded image
JSWORD: imageSize { a n -- w h }
    let img = new Image();
    img.src = GetString(a, n);
    if(img.complete){
        return [img.naturalWidth, img.naturalHeight];
    }  
~
\ usage:
\   s" ccar.jpg" imageSize


JSWORD: getImageData { addr len x y w h }
    var myString = GetString(addr, len);
    const imageData = context.ctx.getImageData(x, y, w, h);
    Object.assign(context.ctx, {[myString]:imageData});
~
\ usage:
\   s" motorhome" 20 30 100 200 getImageData
\   create copie from canvas content, named "motorhome"


JSWORD: putImageData { addr len x y }
    var myString = "context.ctx." + GetString(addr, len);
    const imageData = eval(myString);
    console.info(imageData);
    context.ctx.putImageData(imageData, x, y);
~
\ usage:
\   s" motorhome" 300 30 putImageData



\ *** GRAPHIC extensions words ***  SHADOWS  ***********************************

\ shadow Blur - default: 0
JSWORD: shadowBlur { n }
    context.ctx.shadowBlur = n;
~

\ shadow Color
JSWORD: shadowColor { c }
    function HexDig(n) { 
        return ('0' + n.toString(16)).slice(-2); 
    } 
    context.ctx.shadowColor = '#' + HexDig((c >> 16) & 0xff) + 
        HexDig((c >> 8) & 0xff) + HexDig(c & 0xff);
~

\ shadow Offset X
JSWORD: shadowOffsetX { n }
    context.ctx.shadowOffsetX = n;
~

\ shadow offset Y
JSWORD: shadowOffsetY { n }
    context.ctx.shadowOffsetY = n;
~

: setShadow ( ofssetX offsetY blur color -- )
    shadowColor
    shadowBlur
    shadowOffsetY
    shadowOffsetX
  ;





JSWORD: globalAlpha! { val div }
    context.ctx.globalAlpha = val/div;
~
\ usage, draw semi transparent rect:
\ 7 10 globalAlpha!
\ $ffffff color!
\ 10 10 100 20 rect fill


\ define text write direction
\ values: ltr rtl inherit ; inherit by default
JSWORD: direction { a n -- }
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

\ filter

\ isPointInStroke(x, y)

\ putImageData(imageData, dx, dy)

\ quadraticCurveTo(cpx, cpy, x, y)


\ ****  @TODO: à tester  *******************************************************

\ direction
\ possible values: 
\    ltr        text direction is left-to-right.
\    rtl        text direction is right-to-left.
\    inherit    text direction inherited from <canvas> element. Default value
JSWORD: direction { a n -- } 
  context.ctx.direction = GetString(a, n); 
~ 
\ usage:
\ s" rtl" direction   ( write text from right to left)



\ reset resets the rendering context to its default state, allowing it to be reused
\ for drawing something else without having to explicitly reset all the properties.
\ Resetting clears the backing buffer, drawing state stack, any defined paths, and styles. 
\ This includes the current transformation matrix, compositing properties, clipping region, 
\ dash list, line styles, text styles, shadows, image smoothing, filters, and so on. 
\ reset()
JSWORD: reset { x y -- f }
  context.ctx.reset();
~





\ only seems to work with the last path drawn
JSWORD: isPointInPath { x y -- f }
  return context.ctx.isPointInPath(x, y);
~

\ Path2D()
\ JSWORD: Path2D { -- obj }
\   return new Path2D();
\ ~


\ Doc online: https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D
\             https://github.com/mdn/content/tree/main/files/en-us/web/api

\ Shadows **************
\ 
\ CanvasRenderingContext2D.shadowBlur
\ 
\     Specifies the blurring effect. Default: 0.
\ CanvasRenderingContext2D.shadowColor
\ 
\     Color of the shadow. Default: fully-transparent black.
\ CanvasRenderingContext2D.shadowOffsetX
\ 
\     Horizontal distance the shadow will be offset. Default: 0.
\ CanvasRenderingContext2D.shadowOffsetY
\ 
\     Vertical distance the shadow will be offset. Default: 0.








forth definitions
