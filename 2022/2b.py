with open("2022/2.input") as f:
    inp = [l.strip() for l in f.readlines()]

points = []

for rnd in inp:
    their, my = rnd.split(" ")
    p = 0

    LOSE = "X"
    DRAW = "Y"
    WIN = "Z"

    THEIR_ROCK = "A"
    THEIR_PAPER = "B"
    THEIR_SISSOR = "C"
    if my == LOSE:
        points.append(0)
        if their == THEIR_ROCK:
            points.append(3)
        if their == THEIR_PAPER:
            points.append(1)
        if their == THEIR_SISSOR:
            points.append(2)
    elif my == DRAW:
        points.append(3)

        if their == THEIR_ROCK:
            points.append(1)
        if their == THEIR_PAPER:
            points.append(2)
        if their == THEIR_SISSOR:
            points.append(3)
    elif my == WIN:
        points.append(6)
        if their == THEIR_ROCK:
            points.append(2)
        if their == THEIR_PAPER:
            points.append(3)
        if their == THEIR_SISSOR:
            points.append(1)

    # if my == MY_ROCK and their == THEIR_SISSOR:
    #     points.append(6)
    # elif my == MY_ROCK and their == THEIR_ROCK:
    #     points.append(3)
    # elif my == MY_PAPER and their == THEIR_ROCK:
    #     points.append(6)
    # elif my == MY_PAPER and their == THEIR_PAPER:
    #     points.append(3)
    # elif my == MY_SISSOR and their == THEIR_PAPER:
    #     points.append(6)
    # elif my == MY_SISSOR and their == THEIR_SISSOR:
    #     points.append(3)


print(f"Day 2B: {sum(points)}")

# print(f"Day 1A: {top_three}")
