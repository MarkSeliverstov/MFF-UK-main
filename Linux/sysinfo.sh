#!/bin/bash

set -ueo pipefail

load=""
kernel=""
cpus=""
skript=""

if [ $# -gt 0 ]; then
	while [ $# -gt 0 ]; do
		if [ $skript ]; then
			case "$1" in
                        -l|--load)
                                load="load=$(cut -d " " -f 1 /proc/loadavg)"
				echo "$load"
                                ;;
                        -k|--kernel)
                                kernel="kernel=$(uname -r)"
				echo "$kernel"
                                ;;
                        -c|--cpus)
                                cpus="cpus=$(nproc)"
				echo "$cpus"
                                ;;
			esac
		else
    			case "$1" in
				-l|--load)
					load="load=$(cut -d " " -f 1 /proc/loadavg) "
					;;
				-k|--kernel)
					kernel="kernel=$(uname -r) "
					;;
				-c|--cpus)
					cpus="cpus=$(nproc) "
					;;
				-s|--script)
					skript="1"
					;;	
        			-h|--help)
            				echo "Usage: sysinfo [options]"
					echo " -c   --cpu     Print number of CPUs."
					echo " -l   --load    Print current load."
					echo " -k   --kernel  Print kernel version."
					echo " -s   --script  Each value on separate line."
					echo
					echo "Without arguments behave as with -c -l -k."
					echo 
					echo "Copyright NSWI177 2022"
            				;;
    			esac
		fi
    		shift
	done
else
	load="load=0.05 "
	kernel="kernel=5.15.fc34.x86_64 "
	cpus="cpus=12 "
fi
if [ -z $skript ]; then
	echo "$load$kernel$cpus" | rev | cut -b 2- | rev
else
      	if [ -z $load ]; then
		if [ -z $cpus ]; then
			if [ -z $kernel ]; then
				echo "load=$(cut -d " " -f 1 /proc/loadavg)"
				echo "kernel=$(uname -r)"
				echo "cpus=$(nproc)"
			fi
		fi
	fi
fi

