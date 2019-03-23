using System;
using System.IO;
using System.Collections.Generic;

namespace MorseCode
{
    class Program
    {
        /// <summary>
        /// Main method runs the converter
        /// </summary>
        /// <param name="args">the command line arguments passed into the program</param>
        static void Main(string[] args)
        {
            //Check if we have the right amount of arguments
            if (args.Length != 1)
            {
                //Give the user feedback
                Console.WriteLine("Program takes one argument that is a file of Morse code to translate");
                Console.WriteLine("Example usage: MorseCode.exe test.txt");
                return;
            } else if (!File.Exists(args[0]))
            {
                //The file does not exist
                Console.WriteLine("Could not find specified file " + args[0]);
                Console.WriteLine("Make sure the file path and name is correct");
                return;
            }

            //Create a new Morse code to English converter
            IOneWayConverter converter = new MorseCodeToEnglishConverter();
            //Convert the file
            IList<string> lines = converter.ConvertFile(args[0]);
            //Print out translated lines one by one
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            //Used for making sure the correct output is there when running from visual studio
            Console.ReadLine();
        }
    }
}
