#!/bin/bash

set -ueo pipefail

my_temp="$(mktemp -d tempXXX)"
cd $my_temp
while read team score; do
	if [ $team ]; then
	if [ -f  $team* ]; then
		echo "$(($(cat $team*)+$score))" > $team*
	else
		my_team="$(mktemp "$team"XXX.txt)"
		echo "$score" > $team*
	fi
	fi
done
for i in $(ls); do
	echo "$(echo "$i" | rev | cut -b 8- | rev):$(cat $i)"
done
rm -rf ../$my_temp
