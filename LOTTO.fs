\ define language constants
0 value FRENCH
0 value ENGLISH

: inFrench ( -- )
    -1 to FRENCH
     0 to ENGLISH
  ;

: inEnglish ( -- )
     0 to FRENCH
    -1 to ENGLISH
  ;

inEnglish

\ load LOTTO in /lotto/main.fs
s" tools/dumpTool.fs" included? invert 
[IF] s" tools/dumpTool.fs" included [THEN]
s" lotto/main.fs" included
