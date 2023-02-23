#!/bin/bash

set -ueo pipefail
cut -d: -f 3 | sort -n | tail -n 2 | sort -n -r| tail -n 1
