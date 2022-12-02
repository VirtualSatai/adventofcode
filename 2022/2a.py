with open("2022/2.input") as f:
    inp = f.readlines()

points = []

for rnd in inp:
    # print(points)
    their, my = rnd.strip().split(" ")
    p = 0

    MY_ROCK = "X"
    MY_PAPER = "Y"
    MY_SISSOR = "Z"
    THEIR_ROCK = "A"
    THEIR_PAPER = "B"
    THEIR_SISSOR = "C"
    if my == MY_ROCK:
        points.append(1)
    elif my == MY_PAPER:
        points.append(2)
    elif my == MY_SISSOR:
        points.append(3)

    if my == MY_ROCK and their == THEIR_SISSOR:
        points.append(6)
    elif my == MY_ROCK and their == THEIR_ROCK:
        points.append(3)
    elif my == MY_PAPER and their == THEIR_ROCK:
        points.append(6)
    elif my == MY_PAPER and their == THEIR_PAPER:
        points.append(3)
    elif my == MY_SISSOR and their == THEIR_PAPER:
        points.append(6)
    elif my == MY_SISSOR and their == THEIR_SISSOR:
        points.append(3)




print(f"Day 2A: {sum(points)}")

# print(f"Day 1A: {top_three}")
