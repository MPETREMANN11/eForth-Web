\ *********************************************************************
\ text interface for LOTTO program
\    Filename:      interface.fs
\    Date:          02 mar 2023
\    Updated:       03 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************


\ interface title
: interfaceTitle ( x y -- )
    to _DY   to _DX
    _DX _DY at-xy  ." +-----------------------------+" 1 _DY+
    _DX _DY at-xy
    FRENCH  ?\ ." | ANALYSE CHIFFRES DU LOTO    |"
    ENGLISH ?\ ." | LOTTO NUMBERS ANALYSIS      |"
    1 _DY+
    _DX _DY at-xy  ." +-----------------------------+"
  ;

\ display options
: interfaceOptions ( x y -- )
    to _DY   to _DX
    _DX _DY  at-xy
    FRENCH  ?\ ." D .. affiche la distribution des numeros du LOTO"
    ENGLISH ?\ ." D .. display frequency of LOTTO numbers distribution" 
    1 _DY+
    _DX _DY at-xy
    FRENCH  ?\ ." Q .. quitter"
    ENGLISH ?\ ." Q .. quit" 
    2 _DY+
    5 _DX+
    _DX _DY at-xy
    FRENCH  ?\ ." Appui touche: "
    ENGLISH ?\ ." Press key: " 
  ;

\ execute options
: interfaceActions ( key -- )
    2 _DY+   0 to _DX
    _DX _DY  at-xy
    case
        [char] D  of
            .frequency  cr
            .frequHighLow
        endof
    endcase
  ;

\ main interface
: interface ( -- )
    page
    begin
        8 2 interfaceTitle
        2 6 interfaceOptions
        Xkey
        dup [char] Q =
        if  
            drop exit 
        else
            interfaceActions
        then
    again
  ;





