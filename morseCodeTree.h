//
//  morseCodeTree.h
//  
//
//  Created by Paul Lim on 3/23/19.
//
#ifndef morseCodeTree_h
#define morseCodeTree_h

#include <stdio.h>
#include <vector>

class MorseCodeNode;

class MorseCodeTree {
public:
    MorseCodeTree();
    ~MorseCodeTree();
    // Accessors
    char getLetterFromCode(std::string& morseCode);
    // Modifiers
    void addMorseCode(std::string& morseCode, char letter);
private:
    char getLetterFromCode(MorseCodeNode* node, std::string& morseCode, int index);
    void addMorseCode(MorseCodeNode* node, std::string& morseCode, char letter, int index);
    void deleteTree(MorseCodeNode* node);
    MorseCodeNode* root;
};


class MorseCodeNode {
public:
    MorseCodeNode();
    MorseCodeNode(char subMorseCode, char letter);
    ~MorseCodeNode();
    // Accessors
    char getLetter();
    // Modifiers
    void addChild(MorseCodeNode* child);
    void setLetter(char letter);
    
    friend class MorseCodeTree;
private:
    char subMorseCode;
    char letter;
    std::vector<MorseCodeNode*> children;
};

#endif /* morseCodeTree_h */
