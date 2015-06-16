package morsecode;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class MorseCodeTest 
{


	public static void main(String[] args) 
	{
		/*
		try 
		{
			Scanner fileScanner = new Scanner(new File("words.txt"));
			while(fileScanner.hasNextLine())
			{
				String inputLine = fileScanner.nextLine();
			}
		} 
		catch (FileNotFoundException e) 
		{
			e.printStackTrace();
		}
		*/
		System.out.println(MorseDecoder.decode(".-|-...|-.-.|-..|.|..-.|--.|....|..|.---|-.-|.-..|--|-.|---|.--.|--.-|.-.|...|-|..-|...-|.--|-..-|-.--|--.."));

	}

}
