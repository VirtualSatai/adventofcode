import numpy as np

def part1(input_list):
    cloth = np.zeros((1100, 1100))
    for l in input_list:
        p1, p2 = l.split(",")
        x = int(p1.split(' ')[-1])
        y = int(p2.split(':')[0])
        size_x = int(p2.split(' ')[-1].split("x")[0])
        size_y = int(p2.split(' ')[-1].split("x")[1])

        for i in range(size_x):
            for j in range(size_y):
                cloth[x + i, y + j] += 1

    unique, counts = np.unique(cloth, return_counts=True)
    d = dict(zip(unique, counts))
    return sum([d[i] for i in range(2, 100) if i in d])


def part2(input_list):
    cloth = np.zeros((1100, 1100))
    for l in input_list:
        p1, p2 = l.split(",")
        x = int(p1.split(' ')[-1])
        y = int(p2.split(':')[0])
        size_x = int(p2.split(' ')[-1].split("x")[0])
        size_y = int(p2.split(' ')[-1].split("x")[1])

        for i in range(size_x):
            for j in range(size_y):
                cloth[x + i, y + j] += 1

    for l in input_list:
        p1, p2 = l.split(",")
        x = int(p1.split(' ')[-1])
        y = int(p2.split(':')[0])
        size_x = int(p2.split(' ')[-1].split("x")[0])
        size_y = int(p2.split(' ')[-1].split("x")[1])

        to_pass = True
        for i in range(size_x):
            for j in range(size_y):
                if cloth[x + i, y + j] > 1:
                    to_pass = False

        if to_pass:
            return l.split(' ')[0].split("#")[1]


if __name__ == "__main__":
    f = open("day3_input")
    input_list = f.readlines()

    print(f"Part 1 answer: {part1(input_list)}")
    print(f"Part 2 answer: {part2(input_list)}")
