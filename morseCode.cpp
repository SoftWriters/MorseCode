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
    
    // regular break is b/t chars; spaceBreak is b/t words
    size_t prev_break, next_break, i_spaceBreak;
    std::string morseCodeSeq, morseCodeSubSeq;
    while (morseCodeFile >> morseCodeSeq) {
        prev_break = 0;
        i_spaceBreak = morseCodeSeq.find("||||");
        while ((next_break = morseCodeSeq.find("||", prev_break)) != std::string::npos) {
            if (next_break == i_spaceBreak) {
                // space
                // print out the word before the space
                morseCodeSubSeq = morseCodeSeq.substr(prev_break, next_break-prev_break);
                std::cout << tree.getLetterFromCode(morseCodeSubSeq);
                // print the space
                std::cout<< " ";
                i_spaceBreak = morseCodeSeq.find("||||", i_spaceBreak+4);
                prev_break = next_break + 4;
                continue;
            }
            morseCodeSubSeq = morseCodeSeq.substr(prev_break, next_break-prev_break);
            std::cout << tree.getLetterFromCode(morseCodeSubSeq);
            prev_break = next_break + 2;
        }
        // last morse code sub sequence
        morseCodeSubSeq = morseCodeSeq.substr(prev_break, morseCodeSeq.size()-prev_break);
        std::cout << tree.getLetterFromCode(morseCodeSubSeq) << std::endl;
    }
    
    return 0;
}
