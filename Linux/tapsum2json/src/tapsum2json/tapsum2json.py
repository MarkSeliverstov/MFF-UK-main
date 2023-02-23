#!/usr/bin/env python3

from tap.parser import Parser
import os
import sys

def print_summary(filename, total, passed, skipped, failed):
    print("        {")
    print(f"            \"failed\": {failed},")
    print(f"            \"filename\": \"{filename}\",")
    print(f"            \"passed\": {passed},")
    print(f"            \"skipped\": {skipped},")
    print(f"            \"total\": {total}")
    print("        }", end='')


def main():
    if len(sys.argv) > 1:
        parser = Parser()
        print("{\n    \"summary\": [")
        count = 0
        for arg in sys.argv[1:]:
            count += 1
            filename = arg
            if '\"' in arg:
                index = arg.index('\"')
                filename = arg[:index]+'\\'+arg[index:]
            if os.path.exists(arg):
                passed = 0
                skipped = 0
                failed = 0
                total = 0
                g = parser.parse_file(arg)
                for test in g:
                    if test.category == 'test':
                        if test.skip == True:
                            skipped += 1
                        elif test.ok == True:
                            passed += 1
                        else:
                            failed += 1

                    elif test.category == 'plan':
                        total = test.expected_tests

                    elif test.category == 'bail':
                        skipped = total - failed - passed - skipped
                print_summary(filename, total, passed, skipped, failed)
            else:
                print_summary(filename, 0 ,0 ,0 ,0)
            if count != len(sys.argv)-1:
                print(',\n')
        print("\n    ]\n}")
    else:
        print("{\n    \"summary\": []\n}")
if __name__ == '__main__':
    main()

