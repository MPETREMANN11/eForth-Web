\ *********************************************************************
\ BRICKS game in eFORTH web
\    Filename:      bricks.fs
\    Date:          13 apr 2023
\    Updated:       14 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


web

\ ***  BALL MANAGEMENT  ********************************************************

\ X and Y ball position
ctxWidth  2/    value varXposBall
ctxHeight 30 -  value varYposBall

\ X & Y offset ball move
 2 value dxPosBall
-2 value dyposBall

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
ctxWidth  BALL_SIZE - constant BALL_LIMIT_RIGHT
          BALL_SIZE   constant BALL_LIMIT_LEFT
          BALL_SIZE   constant BALL_LIMIT_TOP
ctxHeight BALL_SIZE - constant BALL_LIMIT_BOTTOM

: ball.direction.change ( -- )
    \ test if ball hits right edge
    varXposBall BALL_LIMIT_RIGHT >= if
        ball.move.left  exit
    then
    \ test if ball reaches left edge
    varXposBall BALL_LIMIT_LEFT  <= if
        ball.move.right exit
    then
    \ test if ball reaches top edge
    varYposBall BALL_LIMIT_TOP  <= if
        ball.move.down  exit
    then
    \ test if ball reaches bottom edge
    varYposBall BALL_LIMIT_BOTTOM  >= if
        ball.move.up    exit
    then
  ;


\ ***  RACQUET MANAGEMENT  *****************************************************

\ RACQUET parameters
\ $0075BD constant RACQUET_COLOR
\      50 constant RACQUET_WIDTH
\      10 constant RACQUET_HEIGHT

\ X and Y racquet position
ctxWidth  2/    RACQUET_WIDTH 2/  -     value varXposRacquet
ctxHeight RACQUET_HEIGHT -              value varYposRacquet

\ X & Y offset racquet move
               10 constant offsetPosRacquet
 offsetPosRacquet value    dxPosRacquet

\ get X position from middle of racquet
: racquetMedianPos@ ( -- xPos )
    varXposRacquet RACQUET_HALF_WIDTH +
  ;

\ draw racquet
: racquet.draw ( -- )
    RACQUET_COLOR color!
    varXposRacquet varYposRacquet RACQUET_WIDTH RACQUET_HEIGHT
    fillRect
  ;

\ erase racquet
: racquet.erase ( -- )
    varXposRacquet varYposRacquet RACQUET_WIDTH RACQUET_HEIGHT
    clearRect
  ;

\ move racquet
: racquet.move ( -- )
    racquet.erase
    dxPosRacquet +to varXposRacquet
    racquet.draw
  ;

\ : racquet.move.left ( -- )
\     dxPosRacquet abs negate to dxPosRacquet
\   ;
\ 
\ : racquet.move.right ( -- )
\     dxPosBall abs           to dxPosBall
\   ;


: racquet.direction.change ( -- )
    mouse drop  { mouseXpos }            \ get mouse x position
    varXposRacquet RACQUET_HALF_WIDTH + { midRaqPos }
    
  ;


\ ***  BRICKS MANAGEMENT  ******************************************************

: bricks.initial.draw ( -- )
    BRICKS_COLOR color!

    BRICKS_LINES BRICKS_VERTICAL_INTERVAL * 0 do
        ctxWidth 0 do
            i 1+ j BRICKS_WIDTH BRICKS_HEIGHT fillRect
        BRICKS_HORIZONTAL_INTERVAL +loop
    BRICKS_VERTICAL_INTERVAL +loop

  ;



\ ***  MAIN GAME  **************************************************************
 
: GAME ( -- )
    bricks.initial.draw
    begin
        ball.direction.change
        ball.move
        10 ms
    key? until
  ;






