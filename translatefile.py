from MorseCode import MorseCode
from MorseCode import InvalidMorseCode
import re
import argparse

parser = argparse.ArgumentParser()
parser.add_argument("file",help="input file with morse code to translate")
args = parser.parse_args()

morsecode1 = MorseCode()

with open(args.file, 'r') as input_file:
    for line in input_file:
        #strip out CR and LF characters at start and end of strings
        cleanline = line.strip()
        try:
            print(morsecode1.translate(cleanline))
        except InvalidMorseCode:
            print("Error: invalid morse code encountered!")


