\ *********************************************************************
\ Graphics extensions for windows
\    Filename:      graphicsExtensions.fs
\    Date:          09 mar 2023
\    Updated:       09 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


\ online doc: https://learn.microsoft.com/fr-fr/windows/win32/api/_gdi/

\ in windows vocabulary, use: Gdi32

graphics definitions  windows also

\ La fonction LineTo dessine une ligne de la position actuelle jusqu’à, mais pas y compris, le point spécifié.
z" LineTo"      3 Gdi32 LineTo      \ hdc x y

z" Rectangle"   5 gdi32 Rectangle   \ hdc left top right bottom

z" Ellipse"     5 gdi32 Ellipse     \ hdc left top right bottom

\ La fonction CloseFigure ferme une figure ouverte dans un chemin d’accès.
z" CloseFigure" 1 gdi32 CloseFigure

\ The GetPixel function retrieves the red, green, blue (RGB) color value 
\ of the pixel at the specified coordinates.
z" GetPixel"    3 gdi32 GetPixel    \ hdc x y 




only forth definitions



