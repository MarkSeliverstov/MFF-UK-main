#!/bin/bash

set -ueo pipefail
tr -s " " | tr -d "|" |  cut -d " " -f 2- | tr " " "+" | rev | cut -d "+" -f 2- | rev | bc

