with open(r"C:\dev\adventofcode\2021\day4_input.txt", 'r') as f:
    # with open(r"C:\dev\adventofcode\2021\day4_sample.txt", 'r') as f:
    numbers = [i for i in f.readline().strip().split(',')]
    boards = [[j.split() for j in i.strip().split('\n')]
              for i in f.read().split('\n\n')]


def part1():
    def find_winner():
        for n in numbers:
            for i, b in enumerate(boards):
                for j, row in enumerate(b):
                    for k, val in enumerate(row):
                        if n == val:
                            boards[i][j][k] = 'x'
                            if all(map(lambda x: x == 'x', row)):
                                return val, b
                            if all(map(lambda x: x == 'x', [boards[i][0][j], boards[i][1][j], boards[i][2][j], boards[i][3][j], boards[i][4][j]])):
                                return val, b

    winning_value, winning_board = find_winner()
    board_sum = sum(
        [int(item) for sublist in winning_board for item in sublist if item != 'x'])

    print(f"Part 1: {int(winning_value) * board_sum}")


def part2():
    def find_loser():
        finished_indexes = []
        for n in numbers:
            for i, b in enumerate(boards):
                if i in [index for _, index in finished_indexes]:
                    continue
                for j, row in enumerate(b):
                    for k, val in enumerate(row):
                        if n == val:
                            boards[i][j][k] = 'x'
                            if all(map(lambda x: x == 'x', row)):
                                finished_indexes.append((val, i))
                            elif all(map(lambda x: x == 'x', [boards[i][0][k], boards[i][1][k], boards[i][2][k], boards[i][3][k], boards[i][4][k]])):
                                finished_indexes.append((val, i))

        value, board_index = finished_indexes[-1]
        return value, boards[board_index]

    winning_value, winning_board = find_loser()
    board_sum = sum(
        [int(item) for sublist in winning_board for item in sublist if item != 'x'])

    print(f"Part 2: {int(winning_value) * board_sum}")


part1()
part2()
