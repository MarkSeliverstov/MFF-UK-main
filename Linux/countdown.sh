#!/bin/bash

set -ueo pipefail

time=$1

on_exit() {
	echo ""
	echo "Aborted"
	trap - TERM
	exit 17
}

trap "on_exit" TERM INT

while [ "$time" -ne 0 ]
do
	echo "$time"
	time=$(( time-1 ));
	sleep 1
done
