#!/usr/bin/env python3
import os


def main():
    def Scan(files, kam = None):
        with os.scandir() as it:
            for entry in it:
                if not entry.name.startswith('.') and entry.is_file(follow_symlinks=False):
                    files += [[entry.name]]
                elif not entry.name.startswith('.') and entry.is_dir(follow_symlinks=False):
                    pomoc = [f"{entry.name}/"]
                    ted = os.getcwd()
                    os.chdir(entry.name)
                    Scan(pomoc, entry.name)
                    os.chdir(ted)
                    files += [pomoc]
        return files


    def Otevrit(files, dir):
        os.chdir(dir.name)
        with os.scandir() as it:
            for entry in it:
                if not entry.name.startswith('.') and entry.is_file():
                    files += [[entry.name]]
                elif not entry.name.startswith('.'):
                    pomoc = [f"{entry.name}/"]
                    ted = os.getcwd()
                    os.chdir(entry.name)
                    Scan(pomoc)
                    os.chdir(ted)
                    files += [pomoc]
        return files


    def vypiska(files, tab=""):
        for f in files:
            if type(f) == list:
                vypiska(f, tab + "    ")
            else:
                print(f"{tab[-4:0:-1]}{f}")

    def S(files):
        files = sorted(files)
        for i in range(len(files)):
            if type(files[i][0]) != list:
                files[i] = [files[i][0]] + sorted(files[i][1:])
        return files

    files = Scan([])
    files = S(files)
    vypiska(files)


if __name__ == '__main__':
    main()
