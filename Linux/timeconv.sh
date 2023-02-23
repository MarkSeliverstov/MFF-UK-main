#!/bin/bash

set -ueo pipefail

sed "$( for i in 1 2 3 4 5 6 7 8 9; do
	echo "s:\(0$i\:\)\([0-9][0-9]\)\(PM\):$(( i+12 ))\:\2:g";done )" |
      	sed "$( for i in 10 11; do
		echo "s:\($i\:\)\([0-9][0-9]\)\(PM\):$(( i+12 ))\:\2:g";done )" |
	sed "s:\(12\)\(\:[0-9][0-9]\)\(AM\):00\2:g" |
        sed "s:\(12\)\(\:[0-9][0-9]\)\(PM\):\1\2:g" |
        sed "$( for j in 1 2 3 4 5 6 7 8 9; do
                echo "s:\(0$j\:[0-9][0-9]\)\(AM\):\1:g"; done )" |
	sed "$( for j in 10 11 12; do
                echo "s:\($j\:[0-9][0-9]\)\(AM\):\1:g"; done )"
