#!/bin/bash

set -ueo pipefail

if [ -z "$COLUMNS" ]; then
        COLUM="80"
else
        COLUM=$COLUMNS
fi

if [ "$(cat $1 )" ]; then
max_cislo="$(sort -n $1 | tail -n 1 | cut -d " " -f 1)"
max_sloveso="$(cat  $1 | wc -L )"
step="$(echo "($max_cislo / ($COLUM - 5 - $max_sloveso))/1" | bc -l)"
temp="0"
graph=""
repeat_string(){
	local i
	for i in $( seq $1); do
		echo -n "$2"
	done
}
	while read score team; do
		printf "$team ($score) $( repeat_string "$(($max_sloveso - $(echo "$team $score" | wc -L)))" " ")| $( repeat_string "$(echo "scale=0; $score/$step" | bc -l)" "#") \n" 
	done < $1
	echo "$(echo -e "$graph" | column -t -c 10)"
fi
