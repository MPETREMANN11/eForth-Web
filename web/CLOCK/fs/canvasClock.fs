\ *********************************************************************
\ CLOCK in canvas for eFORTH web
\    Filename:      canvasClock.fs
\    Date:          16 mar 2023
\    Updated:       01 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


\ initialize canvas
web
: initCanvas ( -- )
    resetTransform
    radius radius translate  
    -90 360 rotate
  ;

: drawFace ( -- )
    faceColor color!
    beginPath
    face_width lineWidth
    0 0 clockRadius clockRadius 0 360 ellipse
    stroke
  ;

: drawHrMin { size }
    beginPath
    clockRadius size 100 */ 0 moveTo
    clockRadius 0 lineTo
    stroke
  ;

\ draw hours
: drawHours ( --)
    initCanvas
    clockHourColor color!
    face_width 3 5 */ lineWidth
    12 0 do
        1 12 rotate
        85 drawHrMin
    loop
  ;
  
\ draw minutes  
: drawMinutes ( -- )
    face_width 2 12 */ lineWidth
    clockMinColor color!
    61 0 do
        1 60 rotate
        90 drawHrMin
    loop
  ;
  
0 value currentHour
0 value currentMinute
0 value currentSecond

: setCurrentTime ( -- )
    time@
    to currentSecond
    to currentMinute
    12 mod to currentHour
  ;
  
: dispHour ( -- )
    initCanvas
    clockHourColor color!
    currentHour 30 *   currentMinute 6 12 */ + 
    360 rotate
    face_width 3 5 */ lineWidth
    beginPath
    clockRadius 5 / negate 0 moveTo
    clockRadius clockRadius 4 / - 0 lineTo
    stroke
  ;

: dispMinute ( -- )
    initCanvas
    clockMinColor color!
    currentMinute 6 *  currentSecond 10 / +  360 rotate
    face_width 2 5 */ lineWidth
    beginPath
    clockRadius 6 / negate 0 moveTo
    clockRadius clockRadius 5 / - 0 lineTo
    stroke
  ;

: dispSecond ( -- )
    clockSecColor color!
    currentSecond 6 * 
    360 rotate
    1 lineWidth
    beginPath
    clockRadius 6 / negate 0 moveTo
    clockRadius clockRadius 5 / - 0 lineTo
    stroke
  ;
  
: deleteHrMinSec ( -- )
    initCanvas
    $ffffff random color!
    clockRadius 4 5 */ >r
    0 0 r@ r@ -90 360 ellipse rdrop
    fill
  ;

\ draw clock in canvas
: drawClock ( -- )
    gr
    ctxWidth ctxHeight window
    begin
        resetTransform
        0 0 ctxWidth ctxHeight clearRect
        setCurrentTime
        initCanvas
        drawMinutes
        drawHours
        drawFace
        dispHour
        dispMinute
        dispSecond
        1000 ms
        key? if exit then
    again
  ;

