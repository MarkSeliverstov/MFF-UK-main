#!/bin/bash

set -ueo pipefail

column=""
if [ $# -gt 0 ]; then
        while [ $# -gt 0 ]; do
		if [ -e "$1" ]; then
                	if [ -d "$1" ]; then
                        	column="$column$1 <dir>\n "
                	elif [ -f "$1" ]; then
                        	column="$column$1 $(stat -c%s $1)\n"
                	else
                        	column="$column$1 <special>\n"
                	fi
		else
			echo "$1: no such file or directory." >&2
		fi
		shift
        done
	echo -e "$column" | column --table --table-noheadings --table-columns FILENAME,SIZE --table-right SIZE
else
	for i in $(ls); do
		if [ -d "$i" ]; then
        	        column="$column$i <dir>\n "
             	elif [ -f "$i" ]; then
                        column="$column$i $(stat -c%s $i)\n"
                else
                        column="$column$i <special>\n"
                fi
	done
	echo -e "$column" | column --table --table-noheadings --table-columns FILENAME,SIZE --table-right SIZE
fi
