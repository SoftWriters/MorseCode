package morsecode;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * Decodes a file written in Morse code into readable text.
 * Uses the Morse code format: '.' = dot; '-' = dash; '|' = space .  Other characters will be replaced with a blank space.
 * Each line in the file will recieve its own line in the decoded output.
 * @author kensandala
 *
 */
public class MorseFileDecoder
{
	public File f;

	/**
	 * Creates a new file decoder
	 * @param fin Path of the file to decode
	 */
	public MorseFileDecoder(String fin)
	{
		f = new File(fin);
	}
	
	/**
	 * Decodes the Morse code in the file into text
	 * @return The decoded text
	 */
	public String decode() throws FileNotFoundException
	{
		String result = "";
		Scanner fileScanner = new Scanner(f);
		while(fileScanner.hasNextLine())
		{
			String inputLine = fileScanner.nextLine();
			result += (MorseDecoder.decode(inputLine) + "\n");
		}
		fileScanner.close();
		
		return result;
	}

}
