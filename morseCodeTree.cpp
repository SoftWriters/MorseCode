//
//  morseCodeTree.cpp
//  
//
//  Created by Paul Lim on 3/23/19.
//

#include "morseCodeTree.h"
#include <vector>
#include <string>

// MorseCodeTree implementation
// public
MorseCodeTree::MorseCodeTree() {
    root = new MorseCodeNode();
}

MorseCodeTree::~MorseCodeTree() {
    deleteTree(root);
    delete root;
    root = NULL;
}

// returns NULL char '\0' if morseCode does not exist in the tree; else return the letter
//  that matches with the morseCode parameter
char MorseCodeTree::getLetterFromCode(std::string& morseCode) {
    if (root == NULL) {
        return '\0';
    }
    return getLetterFromCode(root, morseCode, 0);
}

void MorseCodeTree::addMorseCode(std::string& morseCode, char letter) {
    if (root == NULL) {
        return;
    }
    addMorseCode(root, morseCode, letter, 0);
}

// private
char MorseCodeTree::getLetterFromCode(MorseCodeNode* node, std::string& morseCode, int index) {
    if (index == morseCode.size()) {
        // 'node' is where the 'letter' should be
        // in terms of finite state automata, 'node' should be an accepting state for morseCode
        return node->letter;
    }
    
    char subMorseCode = (char) morseCode.substr(index,1)[0];
    for (std::vector<MorseCodeNode*>::iterator child = node->children.begin();
         child != node->children.end(); child++) {
        if ((*child)->subMorseCode == subMorseCode) {
            return getLetterFromCode(*child, morseCode, index+1);
        }
    }
    return '\0';
}

void MorseCodeTree::addMorseCode(MorseCodeNode* node, std::string& morseCode, char letter, int index) {
    if (index == morseCode.size()) {
        // 'node' is where the 'letter' should be
        // in terms of finite state automata, 'node' should be an accepting state for morseCode
        node->setLetter(letter);
        return;
    }
    char subMorseCode = (char) morseCode.substr(index,1)[0];
    for (std::vector<MorseCodeNode*>::iterator child = node->children.begin();
         child != node->children.end(); child++) {
        if ((*child)->subMorseCode == subMorseCode) {
            addMorseCode(*child, morseCode, letter, index+1);
            return;
        }
    }
    // 'node' does not have a child with subMorseCode == morseCode.substr(index,1).
    //  In other words, the 'morseCode' that needs to be added is an extension of an already
    //   known morse code subsequence
    MorseCodeNode* newChild = new MorseCodeNode(subMorseCode, '\0');
    node->children.push_back(newChild);
    // recurse down the new child node
    addMorseCode(newChild, morseCode, letter, index+1);
}

void MorseCodeTree::deleteTree(MorseCodeNode* node){
    if (node == NULL) {
        return;
    }
    for (int i = 0; i < node->children.size(); i++) {
        deleteTree(node->children[i]);
        delete node->children[i];
        node->children[i] = NULL;
    }
}


// MorseCodeNode implementation
MorseCodeNode::MorseCodeNode() {
    letter = '\0';
    children = std::vector<MorseCodeNode*>();
}

MorseCodeNode::MorseCodeNode(char subMorseCode, char letter) {
    this->subMorseCode = subMorseCode;
    this->letter = letter;
    this->children = std::vector<MorseCodeNode*>();
}

MorseCodeNode::~MorseCodeNode() {
    
}

void MorseCodeNode::addChild(MorseCodeNode* child) {
    children.push_back(child);
}

void MorseCodeNode::setLetter(char letter) {
    this->letter = letter;
}
