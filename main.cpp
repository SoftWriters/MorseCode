#include <iostream>
#include <stdexcept>
#include <string>

#include "header/constants.h"
#include "header/MTE.h"

using std::cerr;
using std::cin;
using std::cout;
using std::endl;
using std::exception;
using std::ofstream;
using std::ostream;
using std::string;

int main(int argc, char **argv) {
	string in, out;
	ostream* stream = &cout;
	
//Obtain input and output locations
	if(argc >= 2) {
		in = argv[1];
	} else {
		cout << INPUT_PROMPT << ": ";
		cin >> in;
	}
	
	if(argc >= 3) {
		out = argv[2];
		stream = new ofstream(out.c_str());
	}

//Open the file and translate the morse code to English
	try {
		MTE morse(in);
		string line;
		
		while(morse.translateLine(line)) {
			*stream << line << endl;
		}
	} catch(exception& e) {
		cerr << e.what() << endl;
	}
	
//Close the file stream
	//Done automatically
	
	return 0;
}