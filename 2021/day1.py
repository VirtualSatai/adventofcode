with open(r"C:\dev\adventofcode\2021\day1_input.txt", 'r') as f:
    # with open(r"C:\dev\adventofcode\2021\day1_sample.txt", 'r') as f:
    inp = [int(i) for i in f.readlines()]


def day1():
    pairs = zip(inp[:-1], inp[1:])
    cnt = sum([1 for v1, v2 in pairs if v2 > v1])
    print(f"Part 1: {cnt}")


def day2():
    triple_sums = [sum(k) for k in zip(inp[:-2], inp[1:-1], inp[2:])]
    pairs = zip(triple_sums[:-1], triple_sums[1:])
    cnt = sum([1 for v1, v2 in pairs if v2 > v1])
    print(f"Part 2: {cnt}")


day1()
day2()
