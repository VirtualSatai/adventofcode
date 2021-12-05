from pprint import pprint
import parse

with open(r"C:\dev\adventofcode\2021\day5_input.txt", 'r') as f:
# with open(r"C:\dev\adventofcode\2021\day5_sample.txt", 'r') as f:
    inp2 = [tuple(parse.parse("{:d},{:d} -> {:d},{:d}",
                  l.strip()).fixed) for l in f.readlines()]
    # print(inp2)


grid = [[0]*1000 for _ in range(1000)]


def part1():
    for i in inp2:
        x1, y1, x2, y2 = i
        if x1 == x2:
            min_y = min(y1, y2)
            max_y = max(y1, y2)
            for j in range(min_y, max_y + 1):
                grid[j][x1] += 1
        elif y1 == y2:
            min_x = min(x1, x2)
            max_x = max(x1, x2)
            for j in range(min_x, max_x + 1):
                grid[y1][j] += 1

    result = sum([1 for sublist in grid for item in sublist if item > 1])
    print(f"Part 1: {result}")


def part2():
    for i in inp2:
        x1, y1, x2, y2 = i
        if x1 != x2 and y1 != y2:
            dx = 1 if x1 < x2 else -1
            dy = 1 if y1 < y2 else -1
            while x1 != x2 or y1 != y2:
                grid[y1][x1] += 1
                x1 += dx
                y1 += dy

            grid[y1][x1] += 1

    result = sum([1 for sublist in grid for item in sublist if item > 1])
    print(f"Part 2: {result}")


part1()
part2()
