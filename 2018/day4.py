import collections


def part2(input_list):
    def line_to_minute(line):
        return int(line.split(":")[1].split("]")[0])

    sort = sorted(input_list)
    guards = dict()
    current_guard = ""
    last_fall_asleep_time = None
    for l in sort:
        if "Guard" in l:
            current_guard = l.split(" ")[3]
        elif "falls asleep" in l:
            last_fall_asleep_time = line_to_minute(l)
        elif "wakes up" in l:
            if current_guard not in guards:
                guards[current_guard] = dict()

            for i in range(last_fall_asleep_time, line_to_minute(l)):
                if i not in guards[current_guard]:
                    guards[current_guard][i] = 0
                guards[current_guard][i] += 1

    sleepminutes = {k: sum(v) for k, v in guards.items()}

    highest_minute = 0
    highest_minute_value = 0
    most_sleeping = ""
    for g in [k for k, v in sleepminutes.items() if v == 1711]:
        for minute, minutes_asleep in guards[g].items():
            if minutes_asleep > highest_minute_value:
                highest_minute_value = minutes_asleep
                highest_minute = minute
                most_sleeping = g
                print(f"new high {g} {minute}")

    print(sleepminutes)
    print(most_sleeping)
    return int(most_sleeping.split("#")[1]) * highest_minute


def part1(input_list):
    def line_to_minute(line):
        return int(line.split(":")[1].split("]")[0])

    sort = sorted(input_list)
    guards = dict()
    current_guard = ""
    last_fall_asleep_time = None
    for l in sort:
        if "Guard" in l:
            current_guard = l.split(" ")[3]
        elif "falls asleep" in l:
            last_fall_asleep_time = line_to_minute(l)
        elif "wakes up" in l:
            if current_guard not in guards:
                guards[current_guard] = dict()

            for i in range(last_fall_asleep_time, line_to_minute(l)):
                if i not in guards[current_guard]:
                    guards[current_guard][i] = 0
                guards[current_guard][i] += 1

    sleepminutes_2 = {k: max(v.values()) for k, v in guards.items()}

    sleepminutes = {k: sum(v) for k, v in guards.items()}

    highest_minute = 0
    highest_minute_value = 0
    most_sleeping = ""
    for g in [k for k, v in sleepminutes.items()]:
        for minute, minutes_asleep in guards[g].items():
            if minutes_asleep > highest_minute_value:
                highest_minute_value = minutes_asleep
                highest_minute = minute
                most_sleeping = g
                print(f"new high {g} {minute}")

    print(sleepminutes)
    print(most_sleeping)
    return int(most_sleeping.split("#")[1]) * highest_minute

if __name__ == "__main__":
    f = open("day4_input")
    input_list = f.read().split("\n")

    print(f"Part 1 answer: {part1(input_list)}")
    print(f"Part 2 answer: {part2(input_list)}")
