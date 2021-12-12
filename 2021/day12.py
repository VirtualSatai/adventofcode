from pprint import pprint
import statistics
from typing import DefaultDict

DEBUG = False
PATH = f"C:\\dev\\adventofcode\\2021\\day12_{'sample' if DEBUG else 'input'}.txt"


def get_input():
    with open(PATH, 'r') as f:
        return [tuple(s.strip().split("-")) for s in f.readlines()]


all_paths_part1 = []
all_paths_part2 = set()
part2_res = [0]
inp = get_input()
adjency_list: dict[str] = DefaultDict(lambda: list())
for f, t in inp:
    adjency_list[f].append(t)
    adjency_list[t].append(f)


def find_all_paths_single_small(current_path: list[str]):
    current_node = current_path[-1]
    candidates = [s for s in adjency_list[current_node]
                  if s not in current_path or s.isupper()]
    for s in candidates:
        new_path = current_path[:] + [s]
        if s == "end":
            all_paths_part1.append(new_path)
        else:
            find_all_paths_single_small(new_path)


def find_all_paths_one_double_small(current_path: list[str], small_twice: bool):
    current_node = current_path[-1]
    candiates = [s for s in adjency_list[current_node] if (s not in current_path and s != "start") or s.isupper()] if small_twice else [
        s for s in adjency_list[current_node] if (current_path.count(s) <= 1 and s != "start") or s.isupper()
    ]
    for s in candiates:
        new_path = current_path[:] + [s]
        if s == "end":
            all_paths_part2.add(tuple(new_path))
        else:
            if small_twice or (s.islower() and new_path.count(s) == 2):
                find_all_paths_one_double_small(new_path, True)
            else:
                find_all_paths_one_double_small(new_path, False)


def part1():
    find_all_paths_single_small(["start"])
    print(f"Part 1: {len(all_paths_part1)}")


def part2():
    find_all_paths_one_double_small(["start"], False)

    print(f"Part 2: {len(all_paths_part2)}")


part1()
part2()
