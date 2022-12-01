with open("1.input") as f:
    inp = f.read()

elf_calories = []
for elf in inp.split("\n\n"):
    calories = [int(x) for x in elf.split("\n") if x != ""]
    cal_sum = sum(calories)
    elf_calories.append(cal_sum)

print(f"Day 1A: {max(elf_calories)}")

ordered = sorted(elf_calories, reverse=True)
top_three = sum(ordered[0:3])
print(f"Day 1A: {top_three}")
