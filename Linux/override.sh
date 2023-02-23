#!/bin/bash

set -ueo pipefail
test -f .NO_HEADER  || { { test -f HEADER && cat HEADER; } || { echo "Error: HEADER not found." >&2;  exit 1; }; }
