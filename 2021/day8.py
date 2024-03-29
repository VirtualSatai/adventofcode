from pprint import pprint
import statistics

DEBUG = False
PATH = f"C:\\work\\SVN\\adventofcode\\2021\\day8_{'sample' if DEBUG else 'input'}.txt"

with open(PATH, 'r') as f:
    #inp2 = [tuple(parse.parse("{:d},{:d} -> {:d},{:d}",
                  #l.strip()).fixed) for l in f.readlines()]
    # print(inp2)
    inp = [[v.strip().split(" ") for v in i.strip().split("|")] for i in f.readlines()]
    print(inp)



def part1():
    ones = 0
    fours = 0
    sevens = 0
    eights = 0
    for codes in [k[1] for k in inp]:
        for code in codes:
            if len(code) == 2:
                ones += 1
            elif len(code) == 4:
                fours += 1
            elif len(code) == 3:
                sevens += 1
            elif len(code) == 7:
                eights += 1
    print(f"Part 1: {ones + fours + sevens + eights}")


def part2():
    sum_all = 0
    for all_codes, answer_codes in inp:
        d_one = [c for c in all_codes if len(c) == 2][0]
        d_four = [c for c in all_codes if len(c) == 4][0]
        d_seven = [c for c in all_codes if len(c) == 3][0]
        d_eight = [c for c in all_codes if len(c) == 7][0]

        d_zero_six_nine = [c for c in all_codes if len(c) == 6]
        d_six = [c for c in d_zero_six_nine if len([value for value in d_one if value in c]) == 1][0]
        d_nine = [c for c in d_zero_six_nine if len([value for value in d_four if value in c]) == 4][0]
        d_zero = [c for c in d_zero_six_nine if c != d_six and c != d_nine][0]
        d_two_three_five = [c for c in all_codes if len(c) == 5]
        d_five = [c for c in d_two_three_five if len([value for value in d_four if value in c]) == 3 and len([value for value in d_one if value in c]) == 1][0]
        d_two = [c for c in d_two_three_five if len([value for value in d_four if value in c]) == 2 and len([value for value in d_one if value in c]) == 1][0]
        d_three = [c for c in d_two_three_five if len([value for value in d_one if value in c]) == 2][0]
        digets = ["".join(sorted(a)) for a in [d_zero, d_one, d_two, d_three, d_four, d_five, d_six, d_seven, d_eight, d_nine]]
        answer = ''
        for a in ["".join(sorted(a)) for a in answer_codes]:
            answer += str(digets.index(a))
        sum_all += int(answer)

    print(f"Part 2: {sum_all}")

part1()
part2()
