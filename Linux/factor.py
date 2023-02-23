#!/usr/bin/env python3

def main():
    with open("input.txt", "r") as f:
        try:
            a = int(f.read())
        except ValueError:
            print("-")
            return
    k = 2
    if a <= 0:
        print("-")
        return
    else:
        if a == 1:
            print("1")
            return
        else:
            while a != 1:
                if a % k == 0:
                    a //= k
                    print(k)
                else:
                    k+=1


if __name__ == '__main__':
    main()
