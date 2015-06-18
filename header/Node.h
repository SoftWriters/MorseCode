#ifndef NODE_H
#define NODE_H

#include <iostream>

using std::ostream;

/// <summary>
/// The most fundamental unit for the BST which is used for lg(N)
/// lookup time for all of the characters which are supported by
/// this Morse to English translator. It contains a character data
/// value and two child Nodes, one for a Dot and another for a Dash
/// descendent.
/// </summary>

class Node {
public:
	Node() : Dash(NULL), Dot(NULL), Value('\0') { }
	Node(char v) : Dash(NULL), Dot(NULL), Value(v) { }
	Node(Node* dot) : Dash(NULL), Dot(dot), Value('\0') { }
	Node(Node* dot, Node* dash) : Dash(dash), Dot(dot), Value('\0') { }
	Node(char v, Node* dot) : Dash(NULL), Dot(dot), Value(v) { }
	Node(char v, Node* dot, Node* dash) : Dash(dash), Dot(dot), Value(v) { }
	
	~Node() {
		if(Dash != NULL) delete Dash;
		if(Dot != NULL)  delete Dot;
	}
	
public:
	friend ostream& operator<<(ostream& out, const Node& n){ 
		out << n.Value;
		return out;            
	}

public:
	Node* Dash;
	Node* Dot;
	char Value;
};

#endif