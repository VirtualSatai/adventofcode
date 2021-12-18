from pprint import pprint
import statistics
from typing import DefaultDict
import binascii
import parse

DEBUG = False
PATH = f"C:\\dev\\adventofcode\\2021\\day17_{'sample' if DEBUG else 'input'}.txt"


def get_input():
    with open(PATH, 'r') as f:
        inp = f.read()
        x0, x1, y0, y1 = parse.parse(
            "target area: x={:d}..{:d}, y={:d}..{:d}", inp.strip()).fixed
        return x0, x1, y0, y1


def day17():
    x0, x1, y0, y1 = get_input()
    count = 0

    print(f"Target: {x0} <= x <= {x1}")
    print(f"Target: {y0} <= y <= {y1}")
    max_y_global = 0
    for init_v_x in range(0, 500):
        for init_v_y in range(-200, 500):
            v_x = init_v_x
            v_y = init_v_y
            x_pos = 0
            y_pos = 0
            max_y_local = 0
            for step in range(1000):
                x_pos += v_x
                y_pos += v_y
                max_y_local = max(max_y_local, y_pos)
                v_x = max(v_x - 1, 0)
                v_y -= 1
                if x0 <= x_pos <= x1 and y0 <= y_pos <= y1:
                    count += 1
                    if max_y_local >= max_y_global:
                        print(
                            f"great success: max: {max_y_local} ({init_v_x},{init_v_y})")
                        max_y_global = max(max_y_global, max_y_local)
                    break
                if y_pos < y0 or x_pos > x1:
                    break

    print(f"Part 1: {max_y_global}")
    print(f"Part 2: {count}")


day17()
