#include "../header/MTE.h"

/// <summary>
/// Attempts to open the text file which is located at the provided
/// file path.
/// </summary>
/// 
/// <param name="file">The path to a file containing multiple lines of Morse code</param>

MTE::MTE(string file) : File(file), Line(0) {
	parseFile();
}

/// <summary>
/// Opens the file supplied to the class constructor, and puts each
/// line of the text file into a vector<string>.
/// </summary>

void MTE::parseFile() {
	ifstream in(File.c_str());
	
//Check to see if the file was opened
	if(!in.is_open()) {
		in.close();
		throw runtime_error(FILE_NOT_FOUND);
		return;
	}
	
//Parse each line into the vector of strings
	string line;
	
	while(getline(in, line)) {
		Lines.push_back(line);
	}
	
	in.close();
}

/// <summary>
/// Iteratively works through the vector<string> variable, corresponding
/// to lines in the input text file, and converts each line to its
/// associated English statement.
/// </summary>
///
/// <returns>The English statement for a line of Morse code</returns>

string MTE::parseMorse() {
	string::iterator it;
	Node* current = root;
	string morse = Lines[Line];
	Buffer.str("");
	
	for(it = morse.begin(); it != morse.end(); ++it) {
		if(*it == '.') {
			current = current->Dot;
		} else if (*it == '-') {
			current = current->Dash;
		} else if(*it == '|') {
			if((it == morse.begin()) || (it != morse.begin() && *(it - 1) == '|')) {
				Buffer << ' '; // Add a space if the first char is a | or if the previous char was also a |
			} else {
				Buffer << *current; //Otherwise, just append the character
			}
			
			current = root;
		} else {
			Buffer << INVALID_CHARACTER;
			++Line;
			
			return Buffer.str();
		}
	}
	
	if(*(it - 1) != '|') // Don't print a | character again, if it is the last character in the string
		Buffer << *current;
	++Line;
	
	return Buffer.str();
}

/// <summary>
/// Manages external access to the parseMorse() function, by modifying
/// the value of the out parameter when more lines can be translated,
/// and returning false whenever no more lines exist.
/// </summary>
///
/// <param name="out">An out parameter, which will contain a translated English statement</param>
/// <returns>False whenever all lines in the input file have been translated</returns>

bool MTE::translateLine(string& out) {
	if(Line >= Lines.size())
		return false;
	
	string line = parseMorse();
	out = (line.size() == 1) ? EMPTY_LINE : line; // 1 for \0 character
	return true;
}