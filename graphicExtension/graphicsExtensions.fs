\ *********************************************************************
\ Graphics extensions for windows
\    Filename:      graphicsExtensions.fs
\    Date:          09 mar 2023
\    Updated:       10 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


\ online doc: https://learn.microsoft.com/fr-fr/windows/win32/api/_gdi/


graphics internals definitions
windows also

\ La fonction LineTo dessine une ligne de la position actuelle jusqu’à, 
\ mais pas y compris, le point spécifié.
z" LineTo"      3 Gdi32 Gdi.LineTo ( hdc x y -- fl )

z" Rectangle"   5 gdi32 Gdi.Rectangle   \ hdc left top right bottom

z" Ellipse"     5 gdi32 Gdi.Ellipse     \ hdc left top right bottom

\ La fonction CloseFigure ferme une figure ouverte dans un chemin d’accès.
z" CloseFigure" 1 gdi32 Gdi.CloseFigure ( hdc --  fl )

\ The GetPixel function retrieves the red, green, blue (RGB) color value 
\ of the pixel at the specified coordinates.
z" GetPixel"    3 gdi32 Gdi.GetPixel ( hdc x y -- color )

\ The SetPixel function sets the pixel at the specified coordinates 
\ to the specified color.
z" SetPixel"    4 gdi32 Gdi.SetPixel ( hdc x y colorref -- colorref )

only forth 
graphics definitions internals

: lineTo ( x y -- )
    hdc -rot Gdi.LineTo drop ;
: rectangle ( left top right bottom -- )
    >r >r >r >r hdc r> r> r> r> Gdi.Rectangle drop ;
: closeFigure ( -- )
    hdc Gdi.CloseFigure drop ;
: getPixel ( x y -- colorref )
    hdc -rot Gdi.GetPixel ;
: setPixel ( x y color -- )
    hdc -rot Gdi.GetPixel ;

