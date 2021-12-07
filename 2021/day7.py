from pprint import pprint
import parse
import statistics

DEBUG = False
PATH = f"C:\\dev\\adventofcode\\2021\\day7_{'sample' if DEBUG else 'input'}.txt"

with open(PATH, 'r') as f:
    #inp2 = [tuple(parse.parse("{:d},{:d} -> {:d},{:d}",
                  #l.strip()).fixed) for l in f.readlines()]
    # print(inp2)
    inp = [int(i) for i in f.read().strip().split(',')]
    print(inp)



def part1():
    working = inp[:]
    median = int(statistics.median(working))
    distance_to_median = [abs(median - i) for i in working]
    print(f"Part 1: {sum(distance_to_median)}")


def part2():
    working = inp[:]
    lowest_sum = 99e99
    lowest_val = -1
    for val in range(min(working), max(working)):
        distance_to_median = [sum(range(1, int(abs(i - val)) + 1))  for i in working]
        if sum(distance_to_median) < lowest_sum:
            lowest_sum = sum(distance_to_median)
            lowest_val = val
        else: 
            break
        # print(f"{val}: {sum(distance_to_median)}")

    print(lowest_val)
    print(f"Part 2: {lowest_sum}")

part1()
part2()
