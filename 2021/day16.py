from pprint import pprint
import statistics
from typing import DefaultDict
import binascii

DEBUG = True
PATH = f"C:\\dev\\adventofcode\\2021\\day16_{'sample' if DEBUG else 'input'}.txt"

hexdict = dict()
hexdict['0'] = '0000'
hexdict['1'] = '0001'
hexdict['2'] = '0010'
hexdict['3'] = '0011'
hexdict['4'] = '0100'
hexdict['5'] = '0101'
hexdict['6'] = '0110'
hexdict['7'] = '0111'
hexdict['8'] = '1000'
hexdict['9'] = '1001'
hexdict['A'] = '1010'
hexdict['B'] = '1011'
hexdict['C'] = '1100'
hexdict['D'] = '1101'
hexdict['E'] = '1110'
hexdict['F'] = '1111'

def get_input():
    with open(PATH, 'r') as f:
        packet = f.read()
        bits_string = "".join([hexdict[v] for v in packet])
        return bits_string

def decode_literal_packet(body):
    n = 5
    to_continue = True
    value = ''
    index = 0
    while to_continue:
        part = body[index:index+n]
        value += part[1:]
        to_continue = part[0] == '1'
        index += 5
    number = int(value, 2)
    return number

def part1():
    bits = get_input()
    header = bits[0:6]
    version = int(header[0:3], 2)
    type_id = int(header[3:6], 2)
    body = bits[6:]
    if type_id == 4:
        # Literal value
        print(decode_literal_packet(body))
    else:
        pass


    print(f"Part 1: {0}")


def part2():

    print(f"Part 2: {0}")


part1()
part2()
