\ *********************************************************************
\ stats frequency for LOTTO numbers
\    Filename:      numbersFrequency.fs
\    Date:          28 feb 2023
\    Updated:       28 feb 2023
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
.frequency
