with open(r"C:\work\SVN\adventofcode\2021\day3_input.txt", 'r') as f:
#with open(r"C:\work\SVN\adventofcode\2021\day3_sample.txt", 'r') as f:
    inp = [list(i.strip()) for i in f.readlines()]


def part1():
    # print(inp)
    transposed = list(map(list, zip(*inp)))
    # print(transposed)
    final = ""
    for l in transposed:
        final += '1' if l.count('1') > l.count('0') else '0'
    # print(final)
    gamma = int(final,2)
    epsilon = int("".join(['1' if l == '0' else '0' for l in final]), 2)
    # print(gamma)
    # print(epsilon)
    print(f"Part 1: {gamma*epsilon}")


def part2():
    remaining = list(inp)
    for i in range(len(remaining[0])):
        transposed = list(map(list, zip(*remaining)))
        tokeep = '1' if transposed[i].count('1') >= transposed[i].count('0') else '0'
        # print(tokeep)
        remaining = [l for l in remaining if l[i] == tokeep]
        # print(f"len: {len(remaining)}")
    oxygen = int("".join(remaining[0]), 2)

    remaining = list(inp)
    for i in range(len(remaining[0])):
        if len(remaining) == 1:
            continue
        transposed = list(map(list, zip(*remaining)))
        tokeep = '1' if transposed[i].count('1') < transposed[i].count('0') else '0'
        # print(tokeep)
        remaining = [l for l in remaining if l[i] == tokeep]
        # print(f"len: {len(remaining)}")
    co2 = int("".join(remaining[0]), 2)
    # print(remaining)
    print(f"Part2: {co2*oxygen}")

part1()
part2()
