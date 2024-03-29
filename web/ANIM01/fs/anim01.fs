\ *********************************************************************
\ main script for anim01
\    Filename:      config.fs
\    Date:          01 apr 2023
\    Updated:       01 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH all versions 7.x++
\    Copyright:     Eric Fð
\    Author:        Eric Fð
\    Adaptation:    Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


web

\ clear all canvas
: cls ( -- )
    0 0 ctxWidth ctxHeight clearRect
;


: setButtonColor ( -- )
    BUTTON_COLOR color! 
  ;

\ draw colored box in relative position
: myButton { -- }
    setButtonColor
    0 0 BUTTON_WIDTH BUTTON_HEIGHT box
  ;

\ draw button at xy position in canvas
: myButtonAtXY ( x y -- )
    gpush
    translate
    myButton
    gpop
  ;

: myButton01  50 ctxHeight 30 - myButtonAtXY ;
: myButton02 250 ctxHeight 30 - myButtonAtXY ;
: myButton03 450 ctxHeight 30 - myButtonAtXY ;

defer run2
defer run3

\ draw all buttons
: drawAllButtons
    setButtonColor
    myButton01
    myButton02
    myButton03
;

\ init canvas
: canvasInit 
    gr ctxWidth ctxHeight window
;

variable mousex 
variable mousey

232 mousex !
49 mousey !


variable click 

: garvalf 
    COLOR_BLACK color!
    313 267 380 200 line
    380 200 343 136 line

    \ 343 136 331 61 line
    \ 331 61 270 90 line

    \ 270 90 232 49 line
    \ 232 49 223 89 line

    343 136 331 232 - mousex @ + 61 49 - mousey @ + line
    331 232 - mousex @ + 61 49 - mousey @ + 270 90 line

    270 90 mousex @ mousey @ line
    mousex @ mousey @ 223 89 line

    223 89 301 105 line
    301 105 223 89 line
    223 89 200 93 line
    200 93 193 99 line
    \ 223 89 mousex @ mousey @ line
    \ mousex @ mousey @ 193 99 line
    193 99 249 106 line
    249 106 301 105 line
    \ 193 99 mousex @ mousey @ line
    \ mousex @ mousey @ 228 122 line
    \ mousex @ mousey @ 138 117 line
    193 99 187 113 line
    187 113 228 122 line
    187 113 138 117 line
    138 117 228 122 line 
    138 117 128 147 line 
    ( mousex @ mousey @ 228 122 line )
    ( mousex @ mousey @ 128 147 line )
    128 147 210 198 line
    128 147 175 188 line
    175 188 138 192 line
    175 188 210 198 line  ( mouth )
    138 192 210 198 line 
    138 192 133 199 line
    133 199 145 216 line
    145 216 215 220 line
    215 220 237 249 line
    237 249 313 267 line
    215 220 267 225 line
    267 225 313 267 line
  ;


: testMyButton0 button 1 = if  run2 then ; 

: testMyButton
    button 1 = if 
        myButton01 2drop drop mouse drop < if  \ test  within button (x)
         \ run2
            myButton01 
            drop swap drop  
            over +
            mouse drop > if 
                \ test  within y
                myButton01 2drop  
                mouse swap drop < if 
                    ." clic " 
            then
            then 
        then 
        
        myButton02 2drop drop mouse drop < if  \ test  within button (x)
         \ run2
            myButton02 
            drop swap drop  
            over +
            mouse drop > if 
                \ test  within y
                myButton02 2drop  
                mouse swap drop < if 
                    run2 
    then then then
    
        myButton03 2drop drop mouse drop < if  \ test  within button (x)
         \ run2
            myButton03 
            drop swap drop  
            over +
            mouse drop > if 
                \ test  within y
                myButton03 2drop  
                mouse swap drop < if 
                    run3 
    then then then
    
    then
;

: loopy1
begin
testMyButton
\ resetTransform
 50 ms
 key? if exit then
again
;

: run
    cls
    canvasInit drawAllButtons
    232 mousex ! 49 mousey !
    garvalf
    \ myButton
    loopy1
;

: decale 
 20 0 do cr loop
;


: loopy2
    begin
    cls
    \ testMyButton
    mouse
    mousey ! mousex !     
    \ mousex @ . mousey @ . cr
    
    garvalf
        50 ms
        key? if exit then
    again
  ;

: loopy3
    begin
    cls
    \ testMyButton  \ with crash
    232 49  mousey ! mousex !     
    
    garvalf  400 ms
    
    cls
    \ 10 360 rotate 
    \ 10 10 15 scale 
    
    267 55 mousey ! mousex ! 
    
    garvalf 400 ms
    
        key? if exit then
    again
  ;


: run2b
    canvasInit  drawAllButtons
    cls
    232 mousex ! 49 mousey !
    loopy2
  ;
' run2b is run2

: run3b
    canvasInit drawAllButtons
    cls
    232 mousex ! 49 mousey !
    loopy3
  ;
' run3b is run3


." Click one of the black button " CR ." Reload the page if necessary, or type 'run' "

\ canvasInit drawAllButtons


