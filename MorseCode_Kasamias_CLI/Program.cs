using System;
using MorseCode_Kasamias_CLI;

//MVP solution


namespace MorseCode_Kasamias_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running test case given by Softwriters -- please see output file 'ConvertedFile.txt' in bin.");
            Console.WriteLine("Press any key to begin translation.");
            //string fileName = Console.ReadLine();
            Console.ReadLine();

            MorseCodeTranslator translator = new MorseCodeTranslator();
            translator.ReadFileAndSave("MorseCodeTestCase.txt");






            Console.WriteLine("Thank you for using Morse Code Translator!");

        }
    }
}
