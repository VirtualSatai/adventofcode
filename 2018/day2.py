from collections import defaultdict


def part1(input_list):
    two_letter = 0
    three_letter = 0
    for li in input_list:
        letters = defaultdict()
        for l in li:
            if l not in letters:
                letters[l] = 0
            letters[l] += 1

        to_add_two = False
        to_add_three = False
        for k, v in letters.items():
            if v == 2:
                to_add_two = True
            elif v == 3:
                to_add_three = True

        two_letter += 1 if to_add_two else 0
        three_letter += 1 if to_add_three else 0

    return two_letter * three_letter


def levenshteinDistance(s1, s2):
    if len(s1) > len(s2):
        s1, s2 = s2, s1

    distances = range(len(s1) + 1)
    for i2, c2 in enumerate(s2):
        distances_ = [i2 + 1]
        for i1, c1 in enumerate(s1):
            if c1 == c2:
                distances_.append(distances[i1])
            else:
                distances_.append(1 + min((distances[i1], distances[i1 + 1], distances_[-1])))
        distances = distances_
    return distances[-1]


def part2(input_list):
    for l1 in input_list:
        for l2 in input_list:
            if levenshteinDistance(l1, l2) == 1:
                return l1, l2

    return "error"


if __name__ == "__main__":
    f = open("day2_input")
    input_list = f.readlines()

    print(f"Part 1 answer: {part1(input_list)}")
    print(f"Part 2 answer: {part2(input_list)}")
