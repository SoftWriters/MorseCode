#include "../header/constants.h"

/// <summary>
/// This BST utilizes the advantageous organization of the Morse 
/// code system, and allows for lg(N) lookup time for any of the
/// characters supported by this translator.
/// </summary>

Node* root = new Node(
new Node(
	'e', new Node(
		'i', new Node(
			's', new Node(
				'h'
			), new Node (
				'v'
			)
		), new Node(
			'u', new Node(
				'f'
			)
		)
	), new Node(
		'a', new Node(
			'r', new Node(
				'l'
			)
		), new Node(
			'w', new Node(
				'p'
			), new Node(
				'j'
			)
		)
	)
), new Node(
	't', new Node(
		'n', new Node(
			'd', new Node(
				'b'
			), new Node(
				'x'
			)
		), new Node(
			'k', new Node(
				'c'
			), new Node(
				'y'	
			)
		)
	), new Node(
		'm', new Node(
			'g', new Node(
				'z'
			), new Node(
				'q'
			)
		), new Node(
			'o'
		)
	)
));