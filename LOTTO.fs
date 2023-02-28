\ define language constants
 0 value FRENCH     immediate
-1 value ENGLISH    immediate

: ?\  ( fl --- )
    0=
    if
        postpone \
    then
; immediate

\ load LOTTO in /lotto/main.fs
s" tools/dumpTool.fs" included? invert 
[IF] s" tools/dumpTool.fs" included [THEN]
s" lotto/main.fs" included
