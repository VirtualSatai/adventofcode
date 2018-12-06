def part1(input_list):
    return sum([int(a) for a in input_list])


def part2(input_list):
    running_sum = 0
    already_seen = {running_sum: 1}
    while True:
        for i in [int(a) for a in input_list]:
            running_sum = running_sum + i
            if running_sum in already_seen:
                already_seen[running_sum] += 1
                return running_sum
            else:
                already_seen[running_sum] = 1


if __name__ == "__main__":
    f = open("day1_input")
    input_list = f.readlines()

    print(f"Part 1 answer: {part1(input_list)}")
    print(f"Part 2 answer: {part2(input_list)}")
