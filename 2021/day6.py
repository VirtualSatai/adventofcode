from pprint import pprint
import parse

DEBUG = False
PATH = f"C:\\dev\\adventofcode\\2021\\day6_{'sample' if DEBUG else 'input'}.txt"

with open(PATH, 'r') as f:
    #inp2 = [tuple(parse.parse("{:d},{:d} -> {:d},{:d}",
                  #l.strip()).fixed) for l in f.readlines()]
    # print(inp2)
    inp = [int(i) for i in f.read().strip().split(',')]
    print(inp)



def part1():
    working = inp[:]
    for day in range(1, 80 + 1):
        for index, value in enumerate(working):
            if value >= 1:
                working[index] -= 1
            else:
                working[index] = 6
                working.append(9) # off by one since it gets iterated later...
        # print(f"After {day:03} days: " + ",".join([str(s) for s in inp]))

    print(f"Part 1: {len(working)}")


def part2():
    # count how many of each fish exist of each day in the spawn cycle
    fishes = [inp.count(n) for n in range(9)]
    for _ in range(1, 256 + 1):
        # remove the fish with the lowest index (i.e. 0 days to spawn)
        num_of_fish_that_spawn = fishes.pop(0)
        # set back into list at index 6
        fishes[6] += num_of_fish_that_spawn 
        # add newly spawned fish
        fishes.append(num_of_fish_that_spawn) 
    
    print(f"Part 2: {sum(fishes)}")

part1()
part2()
