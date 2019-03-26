//
//  morseCode.cpp
//  
//
//  Created by Paul Lim on 3/23/19.
//

#include <stdio.h>
#include <iostream>
#include <fstream>
#include <string>
#include "morseCodeTree.h"

int main(int argc, char* argv[]) {
    if (argc != 2) {
        std::cout << "Must only provide 2 arguments." << std::endl;
        return 1;
    }
    
    // read morse code file
    // syntax of the lines in morseCodeFile are assumed to be "correct", and limited to
    //  only the characters '.', '-', and "||" as stated in the README.md
    std::ifstream morseCodeFile(argv[1]);
    if (!morseCodeFile){
        std::cout << "Could not open the morse code file: " << argv[1] << ".\n";
        return 1;
    }
    // hard code array of all morse codes and all alphanumeric characters
    int const SIZE = 26;
    std::string morseCodes[SIZE] = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
    char letters[SIZE] = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    // create MorseCodeTree
    // the MorseCodeTree class is essentially a finite state automata where each state
    //  is a subsequence of a morse code, and all states reached through a valid
    //   sequence of a morse code for a letter are "accepting states"
    MorseCodeTree tree = MorseCodeTree();
    for (int i = 0; i < SIZE; i++) {
        tree.addMorseCode(morseCodes[i], letters[i]);
    }
    
    // break is b/t chars or letters; prev_break is the start index of the current morse code
    //  sequence, next_break is the end index of the current morse code (index+1), where
    //   the || begins
    size_t prev_break, next_break;
    std::string morseCodeSeq, morseCodeSubSeq;
    while (morseCodeFile >> morseCodeSeq) {
        prev_break = 0;
        // while a break exists in the morse code subsequence that I have not translated yet..
        while ((next_break = morseCodeSeq.find("||", prev_break)) != std::string::npos) {
            morseCodeSubSeq = morseCodeSeq.substr(prev_break, next_break-prev_break);
            std::cout << tree.getLetterFromCode(morseCodeSubSeq);
            // skip over the "||"
            prev_break = next_break + 2;
            
            if (morseCodeSeq[next_break+2] == '|') {
                // there are subsequent breaks "||"
                // each subsequent break results in a space (eg: |||| -> 2 spaces,
                //  |||||| -> 3 spaces); assumed that groups of subsequent breaks only
                //   occur in sizes of even numbers
                while (morseCodeSeq[next_break+2] == '|') {
                    next_break += 2;
                    std::cout<< " ";
                }
                prev_break = next_break;
            }
        }
        // last morse code sub sequence, which does not precede a break
        morseCodeSubSeq = morseCodeSeq.substr(prev_break, morseCodeSeq.size()-prev_break);
        std::cout << tree.getLetterFromCode(morseCodeSubSeq) << std::endl;
    }
    
    return 0;
}
