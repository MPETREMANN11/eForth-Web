\ *********************************************************************
\ BRICKS game in eFORTH web
\    Filename:      bricks.fs
\    Date:          13 apr 2023
\    Updated:       13 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

\ X and Y ball position
ctxWidth  2/    value varXposBall
ctxHeight 30 -  value varYposBall

\ X & Y offset ball move
 2 value dxPosBall
-2 value dyposBall

web
: ball.draw ( -- )
    beginPath
    BALL_COLOR color!
    varXposBall varYposBall BALL_SIZE circle
    fill
    closePath
  ;

: ball.erase ( -- )
    varXposBall BALL_SIZE - 
    varYposBall BALL_SIZE - 
    BALL_SIZE 2* dup clearRect
  ;

: ball.move ( -- )
    ball.erase
    dxPosBall +to varXposBall
    dyposBall +to varYposBall
    ball.draw
  ;

: ball.move.left ( -- )
    dxPosBall abs negate to dxPosBall
  ;

: ball.move.right ( -- )
    dxPosBall abs        to dxPosBall
  ;

: ball.move.down ( -- )
    dyPosBall abs        to dyPosBall
  ;

: ball.move.up   ( -- )
    dyPosBall abs negate to dyPosBall
  ;

\ set limit of ball move
ctxWidth  BALL_SIZE - constant LIMIT_RIGHT
          BALL_SIZE   constant LIMIT_LEFT
          BALL_SIZE   constant LIMIT_TOP
ctxHeight BALL_SIZE - constant LIMIT_BOTTOM

: ball.direction.change ( -- )
    \ test if ball hits right edge
    varXposBall LIMIT_RIGHT >= if
        ball.move.left  exit
    then
    \ test if ball reaches left edge
    varXposBall LIMIT_LEFT  <= if
        ball.move.right exit
    then
    \ test if ball reaches top edge
    varYposBall LIMIT_TOP  <= if
        ball.move.down  exit
    then
    \ test if ball reaches bottom edge
    varYposBall LIMIT_BOTTOM  >= if
        ball.move.up    exit
    then
  ;


: GAME ( -- )
    begin
        ball.direction.change
        ball.move
        10 ms
    key? until
  ;






