package morsecode;

import java.util.Hashtable;


public class MorseDecoder 
{
	
	public MorseDecoder()
	{
		
	}
	
	/**
	 * Decodes a String of Morse code into a String of English letters.
	 * @param morse Morse code in the following format: '.' = dot; '-' = dash; '|' = space
	 * @return the decoded String of English letters
	 */
	public static String decode(String morse)
	{
		String result = "";
		String morseChar = "";
		int pos = 0;
		while(pos < morse.length())
		{
			while ((pos < morse.length()) && (morse.charAt(pos) != '|'))
			{
				morseChar += morse.charAt(pos);
				pos++;
			}
			result += decodeChar(morseChar);
			morseChar = "";
			pos++;
		}
		return result;
	}
	
	/**
	 * Decodes a single character of Morse code into an English character
	 * @param morseChar the character of Morse code to be decoded
	 * @return the decoded English character, or ' ' (space) if the character could not be decoded
	 */
	private static char decodeChar(String morseChar)
	{
		if(morseChar.charAt(0) == '.') // "."
		{
			if(morseChar.length() == 1)
			{
				return 'e';
			}
			if(morseChar.charAt(1) == '.') // ".."
			{
				if(morseChar.length() == 2)
				{
					return 'i';
				}
				if(morseChar.charAt(2) == '.') //"..."
				{
					if(morseChar.length() == 3)
					{
						return 's';
					}
					if(morseChar.charAt(3) == '.') //"...."
					{
						return 'h';
					}
					else							//"...-"
					{
						return 'v';
					}
				}
				else							//"..-"
				{
					if(morseChar.length() == 3)
					{
						return 'u';
					}
					if(morseChar.charAt(3) == '.') //"..-."
					{
						return 'f';
					}
				}
			}
			else							//".-"
			{
				if(morseChar.length() == 2)
				{
					return 'a';
				}
				else
				{
					if(morseChar.charAt(2) == '.') //".-."
					{
						if(morseChar.length() == 3)
						{
							return 'r';
						}
						if(morseChar.charAt(3) == '.') //".-.."
						{
							return 'l';
						}
					}
					else							//".--"
					{
						if(morseChar.length() == 3)
						{
							return 'w';
						}
						if(morseChar.charAt(3) == '.') //".--."
						{
							return 'p';
						}
						else							//".---"
						{
							return 'j';
						}
					}
				}
			}
		}
		else if(morseChar.charAt(0) == '-') // "-"
		{
			if(morseChar.length() == 1)
			{
				return 't';
			}
			if(morseChar.charAt(1) == '.')//"-."
			{
				if(morseChar.length() == 2)
				{
					return 'n';
				}
				if(morseChar.charAt(2) == '.')//"-.."
				{
					if(morseChar.length() == 3)
					{
						return 'd';
					}
					if(morseChar.charAt(3) == '.')//"-..."
					{
						return 'b';
					}
					else							//"-..-"
					{
						return 'x';
					}
				}
				else								//"-.-"
				{
					if(morseChar.length() == 3)
					{
						return 'k';
					}
					if(morseChar.charAt(3) == '.')//"-.-."
					{
						return 'c';
					}
					else							//"-.--"
					{
						return 'y';
					}
				}
			}
			else								//"--"
			{
				if(morseChar.length() == 2)
				{
					return 'm';
				}
				if(morseChar.charAt(2) == '.')//"--."
				{
					if(morseChar.length() == 3)
					{
						return 'g';
					}
					if(morseChar.charAt(3) == '.')//"--.."
					{
						return 'z';
					}
					else							//"--.-"
					{
						return 'q';
					}
				}
				else							//"---"
				{
					return 'o';
				}
			}
			
		}
		return ' ';
	}
	
}
