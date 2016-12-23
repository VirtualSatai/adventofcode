#!/bin/python3
import sys

giveninput = 'L2, L5, L5, R5, L2, L4, R1, R1, L4, R2, R1, L1, L4, R1, L4, L4, R5, R3, R1, L1, R1, L5, L1, R5, L4, R2, L5, L3, L3, R3, L3, R4, R4, L2, L5, R1, R2, L2, L1, R3, R4, L193, R3, L5, R45, L1, R4, R79, L5, L5, R5, R1, L4, R3, R3, L4, R185, L5, L3, L1, R5, L2, R1, R3, R2, L3, L4, L2, R2, L3, L2, L2, L3, L5, R3, R4, L5, R1, R2, L2, R4, R3, L4, L3, L1, R3, R2, R1, R1, L3, R4, L5, R2, R1, R3, L3, L2, L2, R2, R1, R2, R3, L3, L3, R4, L4, R4, R4, R4, L3, L1, L2, R5, R2, R2, R2, L4, L3, L4, R4, L5, L4, R2, L4, L4, R4, R1, R5, L2, L4, L5, L3, L2, L4, L4, R3, L3, L4, R1, L2, R3, L2, R1, R2, R5, L4, L2, L1, L3, R2, R3, L2, L1, L5, L2, L1, R4'
listinput = giveninput.split(', ')
print(listinput)

direction = ['N', 'E', 'S', 'W']
current_direction = 0
currentLocation = {'lat': 0, 'lng': 0}
oldLocations =  []

for x in listinput:
	if x[0] is 'L':
		current_direction = (current_direction + 3) % 4
	else:
		current_direction = (current_direction + 1) % 4

	steps = int(x[1:])

	print('Direction: ' + str(direction[current_direction]) + ' Steps: ' + str(steps))

	for x in range(0, steps):
		if current_direction is 0:
			currentLocation['lat'] += 1
		elif current_direction is 1:
			currentLocation['lng'] += 1
		elif current_direction is 2:
			currentLocation['lat'] -= 1
		else:
			currentLocation['lng'] -= 1

		if any((currentLocation['lat'] is t[0] and currentLocation['lng'] is t[1]) for t in oldLocations):
			print("Duplicate found: " + str(currentLocation['lat']) + ',' + str(currentLocation['lng']))
			print("Result: " + str(abs(currentLocation['lat']) + abs(currentLocation['lng'])))
			sys.exit()

		oldLocations.append([currentLocation['lat'], currentLocation['lng']])

	print('New location: ' + str(currentLocation['lat']) + ',' + str(currentLocation['lng']))
