\ *********************************************************************
\ configuration for canvas Clock
\    Filename:      config.fs
\    Date:          01 apr 2023
\    Updated:       01 apr 2023
\    File Version:  1.0
\    Forth:         eFORTH all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


web viewport@ nip value viewMaxHeight
viewMaxHeight constant ctxWidth
viewMaxHeight constant ctxHeight

$7f7fff constant faceColor
$3fcfcc constant clockHourColor
$0f9f9c constant clockMinColor
$ff0000 constant clockSecColor


ctxHeight 2 / 
    value radius

radius 10 /   
    value face_width

radius 90 100 */ 
    value clockRadius

