using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCode {
	public class Morse {
		//Create the initial mapping and its inverse form for encoding/decoding.
		static Morse() {
			MorseMapping = new Dictionary<string, char> {
				[".-"] = 'a',
				["-..."] = 'b',
				["-.-."] = 'c',
				["-.."] = 'd',
				["."] = 'e',
				["..-."] = 'f',
				["--."] = 'g',
				["...."] = 'h',
				[".."] = 'i',
				[".---"] = 'j',
				["-.-"] = 'k',
				[".-.."] = 'l',
				["--"] = 'm',
				["-."] = 'n',
				["---"] = 'o',
				[".--."] = 'p',
				["--.-"] = 'q',
				[".-."] = 'r',
				["..."] = 's',
				["-"] = 't',
				["..-"] = 'u',
				["...-"] = 'v',
				[".--"] = 'w',
				["-..-"] = 'x',
				["-.--"] = 'y',
				["--.."] = 'z',
				//Numerals
				["-----"] = '0',
				[".----"] = '1',
				["..---"] = '2',
				["...--"] = '3',
				["....-"] = '4',
				["....."] = '5',
				["-...."] = '6',
				["--..."] = '7',
				["---.."] = '8',
				["----."] = '9',
				//Punctuation
				[".-.-.-"] = '.',
				["--..--"] = ',',
				["..--.."] = '?',
				["-...-"] = '=',
				["-..-."] = '/',
				[""] = ' ',
			};
			MorseInverseMapping = MorseMapping.ToDictionary(kv => kv.Value, kv => kv.Key);
		}
		public static readonly Dictionary<string, char> MorseMapping;
		public static readonly Dictionary<char, string> MorseInverseMapping;

		public static string EncodeString(string line, string separator = "||") {
			return String.Join(separator, line.ToLowerInvariant().Select(EncodeCharacter));
		}
		public static string DecodeString(string line, string separator = "||") {
			var codes = line.Split(new[] { separator }, StringSplitOptions.None);
			return String.Concat(codes.Select(Morse.DecodeCharacter));
		}
		
		public static string EncodeCharacter(char character) => MorseInverseMapping[Char.ToLowerInvariant(character)];
		public static char DecodeCharacter(string code) => MorseMapping[code];
	}
}
