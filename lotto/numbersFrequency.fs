\ *********************************************************************
\ stats frequency for LOTTO numbers
\    Filename:      numbersFrequency.fs
\    Date:          28 feb 2023
\    Updated:       03 mar 2023
\    File Version:  1.0
\    MCU:           eFORTH
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ *********************************************************************

\ 
create frequencyTable
    NR_RANGE cell * allot

\ get addr from frequency position
: getFreqAddr { position -- addr }     \ range of position: 0..NR_RANGE-1
    position NR_RANGE 1- >
    if
        FRENCH  ?\ position ." position " . ." hors limite pour frequencyTable"
        ENGLISH ?\ position ." position " . ." out of range for frequencyTable"
        cr exit
    then
    position cell * frequencyTable +
  ;

\ increment contenu of frequency number
: FreqAddr++ ( position -- )            \ range of position: 0..NR_RANGE-1
    getFreqAddr 1 swap +!
   ;

\ reset content of frequencyTable
: initFrequency ( -- )
    NR_RANGE for
        aft
            0  i 1- getFreqAddr !
        then
    next
  ;

\ count apparition of each number in LOTTOdatas table
: analyzeFrequency ( -- )
    initFrequency
    nbsPerGrid@ nbgrids@ *
    for
        aft
            i getLOTTOdatasAddr + c@
            1- FreqAddr++
        then
    next
  ;

\ display frequency of numbers distribution
: .frequency ( -- )
    analyzeFrequency
    NR_RANGE for
        aft
            NR_RANGE i - dup ## type ."  :"
            1- getFreqAddr @ 5 .r 6 spaces
            i 5 mod 0= if cr then
        then
    next
  ;

0 value LOW_NUM
0 value HIGH_NUM

: searchHighLowFrequency ( -- )
           1 { lowest_num  }
 1 32 lshift { lowest_val  }
    NR_RANGE { highest_num }
           0 { highest_val }
    NR_RANGE for
        aft
            \ searches for the most frequently dialed number
            i getFreqAddr @ dup highest_val >
            if
                to highest_val
                i 1+ to highest_num
            else
                drop
            then
            \ searches for the number issued the least often
            i getFreqAddr @ dup lowest_val <
            if
                to lowest_val
                i 1+ to lowest_num
            else
                drop
            then
        then
    next
    highest_num to HIGH_NUM
     lowest_num to LOW_NUM
  ;

: .frequHighLow ( -- )
    searchHighLowFrequency
    cr
    FRENCH  ?\ ." numéro sorti le plus souvent....: " 
    ENGLISH ?\ ." number issued most often........: " 
    HIGH_NUM ## type ."  ("
    HIGH_NUM 1- getFreqAddr @ . ."  x)"
    cr
    FRENCH  ?\ ." numéro sorti le moins souvent...: " 
    ENGLISH ?\ ." number issued least often.......: " 
    LOW_NUM ## type ."  ("
    LOW_NUM 1- getFreqAddr @ . ."  x)"
  ;



