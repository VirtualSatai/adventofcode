from pprint import pprint
import statistics

DEBUG = False
PATH = f"C:\\dev\\adventofcode\\2021\\day9_{'sample' if DEBUG else 'input'}.txt"

with open(PATH, 'r') as f:
    inp = [[9] + [int(v) for v in l.strip()] + [9] for l in f.readlines()]


def part1():
    padded = [[9] * len(inp[0])] + inp + [[9] * len(inp[0])]
    sum_of_low_points = 0
    for row_index, row in enumerate(padded[1:-1]):
        for col_index, val in enumerate(row[1:-1]):
            if padded[1 + row_index - 1][1 + col_index] > val and \
                    padded[1 + row_index + 1][1 + col_index] > val and \
                    padded[1 + row_index][1 + col_index - 1] > val and \
                    padded[1 + row_index][1 + col_index + 1] > val:
                sum_of_low_points += val + 1

    print(f"Part 1: {sum_of_low_points}")


def part2():
    padded = [[9] * len(inp[0])] + inp + [[9] * len(inp[0])]

    def find_basin(row_index, col_index):
        queue = [(row_index, col_index)]
        included = []
        while len(queue) != 0:
            r, c = queue.pop(0)
            offset_r = 1 + r
            offset_c = 1 + c
            val = padded[offset_r][offset_c]
            if val == 9:
                continue
            if (offset_r, offset_c) not in included:
                included.append((offset_r, offset_c))

            if padded[offset_r - 1][offset_c + 0] > val:
                queue.append((r - 1, c))
            if padded[offset_r + 1][offset_c + 0] > val:
                queue.append((offset_r, c))
            if padded[offset_r + 0][offset_c - 1] > val:
                queue.append((r, c - 1))
            if padded[offset_r + 0][offset_c + 1] > val:
                queue.append((r, c + 1))

        return len(included)

    basins = []
    for row_index, row in enumerate(padded[1:-1]):
        for col_index, val in enumerate(row[1:-1]):
            if padded[1 + row_index - 1][1 + col_index] > val and \
                    padded[1 + row_index + 1][1 + col_index] > val and \
                    padded[1 + row_index][1 + col_index - 1] > val and \
                    padded[1 + row_index][1 + col_index + 1] > val:
                basins.append(find_basin(row_index, col_index))

    sorted_results = sorted(basins, reverse=True)
    res = sorted_results[0] * sorted_results[1] * sorted_results[2]
    print(f"Part 1: {res}")


part1()
part2()
