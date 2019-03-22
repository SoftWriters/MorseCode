using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Program takes one argument that is a file of morse code to translate");
                Console.WriteLine("Example usage: java MorseCode.class test.txt");
                return;
            } else if (!File.Exists(args[0]))
            {
                Console.WriteLine("Could not find specified file " + args[0]);
                Console.WriteLine("Make sure the file path and name is correct");
                return;
            }

            IOneWayTranslator translator = new MorseCodeToEnglishTranslator();
            Console.WriteLine("Translating file " + args[0] + " to english");
            IList<String> lines = translator.TranslateFile(args[0]);
            //Print out translated lines one by one
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
