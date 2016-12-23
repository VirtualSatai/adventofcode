puzzle = open('2.input', 'r').read().split('\n')
print(puzzle)

keypad = [[1, 2, 3],
		  [4, 5, 6],
		  [7, 8, 9]]

x = 1
y = 1

password = []

for line in puzzle:
	if line.strip() is '':
		pass
	print(line + '\n')
	for d in line:
		if d is 'D':
			y = min(y + 1, 2)
		elif d is 'U':
			y = max(y - 1, 0)
		elif d is 'R':
			x = min(x + 1, 2)
		elif d is 'L':
			x = max(x - 1, 0)
	#rint(keypad[y][x])
	password.append(keypad[y][x])

print(password[:-1])
