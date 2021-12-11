from pprint import pprint
import statistics

DEBUG = False
PATH = f"C:\\dev\\adventofcode\\2021\\day11_{'sample' if DEBUG else 'input'}.txt"


def get_input():
    with open(PATH, 'r') as f:
        return [[None] + [int(i) for i in list(s.strip())] + [None]
                for s in f.readlines()]


def flash(padded, ri, ci):
    padded[ri][ci] += 1000
    for x in range(-1, 2):
        for y in range(-1, 2):
            ry = ri + y
            cx = ci + x
            if padded[ry][cx] is not None:
                padded[ry][cx] += 1
                if padded[ry][cx] >= 10 and padded[ry][cx] < 1000:
                    flash(padded, ry, cx)


def part1():
    inp = get_input()
    padded = [[None] * len(inp[0])] + inp[:] + [[None] * len(inp[0])]
    flash_counter = 0
    for _ in range(100):
        # Increase energy
        for ri, r in enumerate(padded):
            for ci, c in enumerate(r):
                if c is not None:
                    padded[ri][ci] += 1

        # Find flashes
        for ri, r in enumerate(padded):
            for ci, c in enumerate(r):
                if c is not None and 10 <= c < 1000:
                    flash(padded, ri, ci)

        # Reset
        for ri, r in enumerate(padded):
            for ci, c in enumerate(r):
                if c is not None and c >= 10:
                    flash_counter += 1
                    padded[ri][ci] = 0

    print(f"Part 1: {flash_counter}")


def part2():
    inp = get_input()
    padded = [[None] * len(inp[0])] + inp[:] + [[None] * len(inp[0])]
    for cnt in range(1, 10000):
        # Increase energy
        for ri, r in enumerate(padded):
            for ci, c in enumerate(r):
                if c is not None:
                    padded[ri][ci] += 1

        # Find flashes
        for ri, r in enumerate(padded):
            for ci, c in enumerate(r):
                if c is not None and 10 <= c < 1000:
                    flash(padded, ri, ci)

        flash_counter = 0
        for ri, r in enumerate(padded):
            for ci, c in enumerate(r):
                if c is not None and c >= 10:
                    flash_counter += 1
                    padded[ri][ci] = 0
        if flash_counter == 100:
            break
    print(f"Part 2: {cnt}")


part1()
part2()
