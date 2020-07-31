Morse Code
==========

Implementation Details
-----------
The morseCodeTree class is implemented using the Trie data structure, which functions identically to a Deterministic Finite Automaton (DFA). The root of the tree is the starting state, and each node in the morseCodeTree (or state, in DFA terms), contains a letter and transition(s) to other nodes.

When given morse code (e.g.: ..-) to translate, the morseCodeTree will start from its root and recursively traverse through the tree based on the current character (. or -) it is reading while reading each character in the code from left to right. Once the morse code is read, if the morse code is a valid sequence of characters that can be translated to a letter, the current node or state will contain the letter (e.g.: u) that corresponds to the given morse code. Invalid morse codes will lead to a state that contains the null character '\0'.

The morseCodeTree instance is created at the beginning of program execution, and all valid morse code sequences are added to the tree through a hard-coded array of size 26 that contains the morse code sequences for all 26 letters in the English alphabet.

Instructions
-----------
1) Clone the repo.
2) Compile .cpp files and create an executable file through the terminal app with command `g++ *.cpp -o morseCode.exe -Wall`.
3) Files should successfully compile without errors or warnings.
4) Run the executable with the input file as a command line argument through the teriminal app with command `./morseCode.exe sampleInput.txt`.
5) Program should translate the morse code from 'sampleInput.txt' file and output the translation on the console of the terminal app.

The Problem
-----------
Morse code is a way to encode messages in a series of long and short sounds or visual signals. During transmission, operators use pauses to split letters and words.

Please write a program which will translate lines of Morse code into readable English text. The program should:

1. Accept a flat file as input.
2. Each new line will contain a string of Morse code. The characters used will be:
	1.	. = dot
	2.	\- = dash
	3.	|| = break
3. Output the English text for each line

Sample Input
------------
-..||---||--.

….||.||.-..||.-..||---||||.--||---||.-.||.-..||-..

Sample Output
-------------
dog

hello world
