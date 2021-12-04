with open(r"C:\dev\adventofcode\2021\day2_input.txt", 'r') as f:
    # with open(r"C:\dev\adventofcode\2021\day2_sample.txt", 'r') as f:
    inp = [i.strip().split(' ') for i in f.readlines()]


def part1():
    distance = 0
    depth = 0
    for direction, value in inp:
        val = int(value)
        if direction == "forward":
            distance += val
        elif direction == "down":
            depth += val
        elif direction == "up":
            depth -= val

    print(f"Part 1: {depth * distance}")


def part2():
    distance = 0
    depth = 0
    aim = 0
    for direction, value in inp:
        val = int(value)
        if direction == "forward":
            distance += val
            depth += aim * val
        elif direction == "down":
            aim += val
        elif direction == "up":
            aim -= val

    print(f"Part 2: {depth * distance}")


part1()
part2()
