import sys

puzzle = open(sys.argv[1], 'r').read().split('\n')
print(puzzle)

keypad = [[None, None,   1, None, None],
		  [None,    2,   3,    4, None],
		  [ 5,      6,   7,    8,    9],
		  [None,  'A', 'B',  'C', None],
		  [None, None, 'D', None, None]]
		  

x = 0
y = 2

password = []

for line in puzzle[:-1]:
		#print(line + '\n')
	for d in line:
		if d is 'D':
			if keypad[min(y + 1, 4)][x] != None:
				y = min(y + 1, 4) 
		elif d is 'U':
			if keypad[min(y - 1, 0)][x] != None: 
				y = max(y - 1, 0)
		elif d is 'R':
			if keypad[y][min(x + 1, 4)] != None: 
				x = min(x + 1, 4)
		elif d is 'L':
			if keypad[y][max(x - 1, 0)] != None:
				x = max(x - 1, 0)
		print(keypad[y][x])
	password.append(keypad[y][x])
	print('\n')

print(password)
