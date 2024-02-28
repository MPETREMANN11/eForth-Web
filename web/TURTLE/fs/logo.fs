\ --------------------------------------------
\                                           :;
\         F:O:R:T:H:T:O:I:S:E               :;
\                                           :; 
\     Turtle logo graphics for ueforth      :;
\                                           :;
\ https://gitlab.com/garvalf/forth-is-fun   :;
\                                           :; 
\ --------------------------------------------
\
\ using code by Robert Coffey and Remko Tronçon 
\ see   https://github.com/foggynight/gforth-turtle
\  and  https://github.com/remko/waforth
\ 
\ Copyright (C) Éric Forgeot
\ Released under the MIT license.

\ ueforth and additional code by:
\ Copyright 2022 Bradley D. Nelson
\ https://eforth.appspot.com/

\ dirty implementation, needs cleaning...

forth definitions


only web also forth

variable ctxHeightTemp

750 constant ctxWidth 

: calculateCtxHeight
    ctxWidth s>f 1.618e f/ f>s 
    ctxHeightTemp !
;

\ calculateCtxHeight
\ ctxHeightTemp @ constant ctxHeight

 463 constant ctxHeight 
\ ctxHeightTemp @ constant ctxHeight 

\ web viewport@ nip value viewMaxHeight

\ viewMaxHeight constant ctxWidth
\ viewMaxHeight constant ctxHeight


\ ctxWidth constant WWIDTH 
\ ctxHeight constant WHEIGHT 


: mouse getMousePosition ; 
: mouse2 mouse ; 

: section-or ( n -- ) 
s>f 1.618e f/ f>s 
;

\ clear all canvas
: cls
    \ 0 0 ctxWidth ctxHeight clearRect
    0 0 ctxWidth ctxWidth section-or clearRect
;

: black $000000 color! ;

: myButton01 50 ctxHeight 30 - 80 20 ;
: myButton02 250 ctxHeight 30 - 80 20 ;
: myButton03 450 ctxHeight 30 - 80 20 ;



variable sprX
variable sprY

250 sprX !
ctxHeight 60 - sprY !

: myButton04 sprX @ sprY @ 80 20 ;



\ web

: init 
    gr ctxWidth ctxHeight window
    \ buttons
;

: f@ sf@ ;
: f! sf! ;


\ Variables

variable penstatus   \ 1 = pen down / 0 = pen up
1 penstatus !

variable turtlestatus   \ 1 = turtle shown / 0 = turtle hidden
1 turtlestatus !

variable roundstatus   \ 1 = correct rounding angles / 0 = no correction
0 roundstatus !

variable slowmo   \ 1 = enable step by step / 0 = render all at once
1 slowmo !

variable waittime   \ time of delay for slow motion mode
60 waittime !

variable hexx0
variable hexy0
variable p1x  \ top of hexagon x
variable p1y  \ top of hexagon y
variable p2x  \ bottom of hexagon x
variable p2y  \ bottom of hexagon y
variable w
variable h



variable r1
variable r2
variable r3
variable r4

variable fgColor

variable rand
here rand !
variable randx

variable lastX
variable lastY


\ float variables
fvariable angle
\ 100e angle f!
fvariable length
\ 100e length f!

variable replay  \ how many time do we replay the main scene
1 replay !

\ extra variable for examples

VARIABLE n1
VARIABLE n2
VARIABLE size
VARIABLE density
VARIABLE nb
variable mycolor
1 mycolor !


: draw-line ( x0 y0 x1 y1 -- ) penstatus @ 1 = if line else drop drop drop drop then ;

\ : draw-line line ;

\ Random numbers

: random rand @ 31421 * 6927 + dup rand ! ;

: rnd100 ( u1 -- u2 ) 
    random random - random * abs 100 /mod + random + random * here + abs 100 /mod - abs 100 mod 1+ ;

: rnd255 ( u1 -- u2 ) 
    random random - random * abs 255 /mod + random + random * here + abs 255 /mod - abs 255 mod 1+ ;

: rnd40 ( u1 -- u2 ) 
    random random - random * abs 40 /mod + random + random * here + abs 40 /mod - abs 40 mod 1+ ;
: rnd10 ( u1 -- u2 ) 
    random random - random * abs 10 /mod + random + random * here + abs 10 /mod - abs 10 mod 1+ ;

\ : rndX randx ! random random um* NIP randx @ mod 1+ ;

: randomcolor  
    random random - random * abs 10 /mod + random + random * here + abs 16777215 /mod - abs 16777215 mod  1+ ;




: fdeg>rad ( f: x -- f: x )  
    pi f* 180e f/ 
;




: wait  ( t -- ) 
   ms 
;

\ Turtle LOGO


: checkround   \ round toward nearest
    roundstatus @ 1 = if
        100e f* f>s 100 /mod swap 50 < if else 1 + then   \ correction
    else
        f>s                                             \ no correction
    then
;

: FORWARD ( n -- )  \ Move forward by n.
    s>f \ length f!
    lastX @ lastY @ angle f@ fdeg>rad fcos fswap ( length -- ) fdup frot f* checkround lastX @ + dup lastX !
    angle f@ fdeg>rad fsin fswap ( length -- ) f* checkround lastY @ + dup lastY ! 
    \ .s cr  \ debug
    draw-line 
    \ idle finished event .s drop drop drop cr \ debug
    slowmo @ 1 = if waittime @ wait else then
;



: BACKWARD ( n -- )   \  Move backward by n. 
    negate FORWARD
;

: RIGHT ( n -- )     \  Turn right by n degrees angle.
    s>f angle f@ f+ ( fabs ) angle f!
;


: LEFT ( n -- )   \  Turn left by n degrees angle.
    negate right
;


: 2swap rot >r rot r> ;


\ TODO: check 
: SETXY ( n1 n2 -- )   \ Move to position n1,n2.
    lastX @ lastY @ 2dup 2swap draw-line lastY ! lastX ! ; 

: SETHEADING  ( n -- )  \ Set heading n degrees clockwise from Y axis.
    s>f angle f!
;

: PENUP 0 penstatus ! ; 
: PENDOWN 1 penstatus ! ; 
: HIDETURTLE 0 turtlestatus ! ;   \ 
: SHOWTURTLE 1 turtlestatus ! ;
: SETPENCOLOR ( RGB -- )  \ Set the color of the drawed strokes to RGB value n in hexadecimal (default: 0)
    color!
; 


\ TODO 
: SETPENSIZE ;  


\ Synonyms


: heading SETHEADING ;  \ ( n -- ): Set heading n degrees clockwise from Y axis.
: hidepen HIDETURTLE ;
: showpen SHOWTURTLE ;

: lt LEFT ;
: rt RIGHT ;
: fw FORWARD ;
: bk BACKWARD ; 
: color SETPENCOLOR ;

\ French translation

: avance FORWARD ;      \ ( n -- ): Move forward by n.
: recule BACKWARD ;     \ ( n -- ): Move backward by n.
: gauche LEFT ;         \ ( n -- ): Turn left by n degrees.
: droite RIGHT ;        \ ( n -- ): Turn right by n degrees.
: aller SETXY ;         \ ( n1 n2 -- ): Move to position n1,n2.
: oriente SETHEADING ;  \ ( n -- ): Set heading n degrees clockwise from Y axis.
: lève    PENUP ;       \ ( -- ): Disable drawing while moving.
: pose    PENDOWN ;     \ ( -- ): Enable drawing while moving.
: crayon  ;
: taille SETPENSIZE ;   \ ( n -- ): Set the width of the drawed strokes to n (default: 5).
: cache HIDETURTLE ;    \ ( -- ): Hide the turtle.
: montre SHOWTURTLE ;   \ ( -- ): Show the turtle.
: tortue  ;



\ tests and samples

: enneagram ( size -- ) \ 9 angles star
n1 !
\ 270 oriente
9 0 DO
n1 @ avance
65 gauche
n1 @ avance
145 droite
LOOP
;



: turtle-logo
cr cr
."   _____     ____   " cr
."  /      \  |  o |  " cr 
." |        |/ ___\|   " cr
." |_________/        " cr
." |_|_| |_|_|          " cr 
cr ." ~ FORTHTOISE 🐢 ~" cr cr
cr ."  " cr cr 
;


: turtle-icon-simple
    $00DD00 SETPENCOLOR
    PENUP 0 RIGHT 8 FORWARD  PENDOWN 90 LEFT 
    9 FORWARD 120 RIGHT 20 FORWARD 120 RIGHT 20 FORWARD 120 RIGHT 9 FORWARD 180 RIGHT
    90 LEFT 1 FORWARD 90 LEFT 5 FORWARD 10 BACKWARD 5 FORWARD 90 LEFT 5 FORWARD

;




: turtle-icon

$00DD00 SETPENCOLOR

90 LEFT
PENUP 4 FORWARD 90 RIGHT 4 FORWARD PENDOWN 
90 RIGHT

\ BODY:
2 0 DO 
 10 FORWARD 45 LEFT 8 FORWARD 45 LEFT  17 FORWARD  45 LEFT 8 FORWARD 45 LEFT
LOOP


\ HEAD: 
PENUP 2 FORWARD 90 RIGHT 27 BACKWARD 90 LEFT 6 FORWARD 90 RIGHT PENDOWN

195 RIGHT

2 0 DO
 7 FORWARD 60 LEFT 7 FORWARD 90 LEFT
LOOP

\ TAIL :
PENUP 105 RIGHT 28 FORWARD PENDOWN

270 LEFT
3 0 DO  
 120 LEFT 5 FORWARD
LOOP

\ PAWS:

PENUP 1 FORWARD 90 RIGHT 3 FORWARD PENDOWN
120 LEFT 5 FORWARD 85 RIGHT 4 FORWARD 85 RIGHT 3 FORWARD
PENUP 60 LEFT 20 FORWARD 120 RIGHT 2 BACKWARD PENDOWN
120 LEFT 3 FORWARD 120 RIGHT 6 FORWARD 20 LEFT 0 FORWARD
PENUP 17 FORWARD PENDOWN
0 FORWARD 20 LEFT 6 FORWARD 120 RIGHT 3 FORWARD 120 LEFT
PENUP 124 RIGHT 21 FORWARD PENDOWN
70 LEFT 3 FORWARD 85 RIGHT 4 FORWARD 85 RIGHT 3 FORWARD

;



: testconsole
page
 \ 1 console? !
 10 lastX !
 100 lastY !
 0 oriente
 10 avance
 $44FF00 SETPENCOLOR
 3 0 do lève 10 avance pose 10 avance loop
 45 droite 15 avance
 45 droite 20 avance 
 85 gauche 25 avance
 42 gauche 20 avance
 18 enneagram
 $224490 SETPENCOLOR
;

defer turtle_sketch
  

: (main)
  \ begin
  ( replay -- ) 0 do
    
    \ init screen 
     
    \ call your word from here: 

      \ demo01
      \ demo02
  \     turtle_sketch
   
   \ display turtle or not
   
   
   turtlestatus @ 1 = IF  turtle-icon-simple
    \  turtle-icon
      ELSE THEN
   
  loop
;
  


:NONAME ( turtle_sketch )
  32 0 do 
  45 left
  \ i 8 * 255 i 5 * -  100 color
  60 enneagram 
  4 +loop
; is turtle_sketch


: draw
 250 lastX !
 200 lastY !
1 mycolor !
\ idle finished event .s drop drop drop cr 
0 oriente
2 mycolor !
\ 120 enneagram 
  turtle_sketch
 lève 200 avance
 pose 
 1 mycolor !
 10 avance  45 droite 100 avance
 3 mycolor !
  20 gauche
 40 enneagram
\ flip
;

: run

   bye
;


: hints
."  FORWARD ( n -- ): Move forward by n. " cr
."  BACKWARD ( n -- ): Move backward by n. " cr
."  LEFT ( n -- ): Turn left by n degrees. " cr
."  RIGHT ( n -- ): Turn right by n degrees. " cr
."  SETXY ( n1 n2 -- ): Move to position n1,n2. " cr
."  SETHEADING ( n -- ): Set heading n degrees clockwise from Y axis. " cr
."  PENUP ( -- ): Disable drawing while moving. " cr
."  PENDOWN ( -- ): Enable drawing while moving. " cr
."  SETPENSIZE ( n -- ): Set the width of the drawed strokes to n (default: 1). (NOTE: you can't change it yet) " cr
."  SETPENCOLOR ( $RRGGBB -- ): Set the color of the drawed strokes to RGB value n in hex (default: $000000). " cr
."  HIDETURTLE ( -- ): Hide the turtle. " cr
."  SHOWTURTLE ( -- ): Show the turtle. " cr
;

: testtortue
cls
init
testconsole
 60 enneagram
 
 10 lastX !
 300 lastY !
 0 oriente
 ." type 'cls' and start a new drawing, 'page' cleans the command line " cr cr
 ." type 'hints' for some commands " cr cr
 50 avance  turtlestatus @ 1 = IF  turtle-icon-simple ELSE THEN 
 $224490 SETPENCOLOR
 0 oriente
 penup 30 avance pose 
 ;

0 slowmo !
testtortue

turtle-logo

