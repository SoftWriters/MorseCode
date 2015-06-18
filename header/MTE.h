#ifndef MTE_H
#define MTE_H

#include <fstream>
#include <stdexcept>
#include <sstream>
#include <string>
#include <vector>

#include "constants.h"
#include "Node.h"

using std::getline;
using std::ifstream;
using std::runtime_error;
using std::string;
using std::stringstream;
using std::vector;

/// <summary>
/// MTE = Morse to English
/// 
/// This class accepts a flat file as input, and provides an interface
/// by which a programmer can loop through each line to convert any
/// alphabetical character which is represented in Morse code, to English.
/// </summary>

class MTE {
public:
	MTE(string file);

public:
    bool translateLine(string& out);
	
private:
    void parseFile();
    string parseMorse();
	
private:
    stringstream Buffer;
    string File;
    unsigned int Line;
	vector<string> Lines;
};

#endif