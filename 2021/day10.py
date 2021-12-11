from pprint import pprint
import statistics

DEBUG = False
PATH = f"C:\\dev\\adventofcode\\2021\\day10_{'sample' if DEBUG else 'input'}.txt"

with open(PATH, 'r') as f:
    inp = [s.strip() for s in f.readlines()]

start = "([{<"
end = ")]}>"
i_matches = dict(zip(start, end))
matches = dict(zip(end, start))
values_1 = dict(zip(end, [3, 57, 1197, 25137]))
values_2 = dict(zip(end, range(1, 5)))


def check_parens(s, stack: list):
    if not s:
        return 0, "".join([i_matches[v] for v in stack[::-1]])
    elif s[0] in start:
        stack.append(s[0])
        return check_parens(s[1:], stack)
    else:
        top_of_stack = stack.pop()
        if matches[s[0]] == top_of_stack:
            return check_parens(s[1:], stack)
        else:
            return values_1[s[0]], None


def part1():
    result = sum([check_parens(r, [])[0] for r in inp])
    print(f"Part 1: {result}")


def part2():
    result = []
    for s in inp:
        _, res = check_parens(s, [])
        if res is not None:
            score = 0
            for d in res:
                score *= 5
                score += values_2[d]
            result.append(score)

    print(f"Part 2: {sorted(result)[len(result) // 2]}")


part1()
part2()
