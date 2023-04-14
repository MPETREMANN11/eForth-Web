\ *********************************************************************
\ BRICKS game parameters
\    Filename:      config.fs
\    Date:          13 apr 2023
\    Updated:       14 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH web
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


\ *** define canvas size  ******************************************************
600 value ctxWidth
300 value ctxHeight


\ **  BALL parameters  *********************************************************

$0095DD constant BALL_COLOR
     10 constant BALL_SIZE


\ ***  RACQUET parameters  *****************************************************

$0075BD constant RACQUET_COLOR
     50 constant RACQUET_WIDTH
     10 constant RACQUET_HEIGHT
RACQUET_WIDTH 2/ constant RACQUET_HALF_WIDTH

\ set limit of racquet move
ctxWidth  RACQUET_HALF_WIDTH - constant RACQUET_LIMIT_RIGHT
       0  RACQUET_HALF_WIDTH + constant RACQUET_LIMIT_LEFT


\ ***  BRICKS parameters  ******************************************************

     20 constant BRICKS_PER_LINE
      6 constant BRICKS_LINES

ctxWidth BRICKS_PER_LINE /
        constant BRICKS_HORIZONTAL_INTERVAL

BRICKS_HORIZONTAL_INTERVAL 2 -
        constant BRICKS_WIDTH
      8 constant BRICKS_HEIGHT

BRICKS_HEIGHT 2 +
        constant BRICKS_VERTICAL_INTERVAL

$B22222         constant COLOR_FireBrick
COLOR_FireBrick constant BRICKS_COLOR


