#!/usr/bin/python
import os

# command to run
command = '/home/zhihengw/project/test/test_hold'

if __name__ == "__main__":
    while 1:
        ret=os.system(command)
        #print ret
        if ret == 1:
            break

