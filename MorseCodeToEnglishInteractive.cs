using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MorseCodeToEnglishInteractive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the filename or full path (exit to quit):  ");
            string filename = Console.ReadLine();

            while (filename.ToLower() != "exit")
            {
                filename = getFullPath(filename);
                if (filename != "file not found")
                {
                    translateAndOutput(filename);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("file not found");
                }
                Console.WriteLine("");
                Console.WriteLine("Please enter the filename or full path (exit to quit):  ");
                filename = Console.ReadLine();
            }
        }

        private static void translateAndOutput(string filename)
        {
            var MorseHashTable = new Dictionary<string, string>();
            PopulateMorseHashTable(ref MorseHashTable);
            IEnumerable<string> lines;
            string[] letters;
            var outputline = new StringBuilder();

            Console.WriteLine("Output:");

            lines = System.IO.File.ReadLines(filename);
            foreach (string line in lines)
            {
                outputline.Clear();
                letters = line.Replace("||", ",").Split(',');
                foreach (string letter in letters)
                {
                    outputline.Append(MorseHashTable[letter]);
                }
                Console.WriteLine(outputline);
            }
        }

        private static string getFullPath(string filename)
        {   // user can enter the full file path or the filename if it is in the current directory
            string fullpath = "file not found";
            if (File.Exists(filename))
            {
                fullpath = filename;
            }
            else if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + filename))
            {
                fullpath = System.IO.Directory.GetCurrentDirectory() + filename;
            }
            return fullpath;
        }

        private static void PopulateMorseHashTable(ref Dictionary<string, string> hashtable)
        {
            hashtable.Add("", " "); //blank returns space
            hashtable.Add(".-", "a");
            hashtable.Add("-...", "b");
            hashtable.Add("-.-.", "c");
            hashtable.Add("-..", "d");
            hashtable.Add(".", "e");
            hashtable.Add("..-.", "f");
            hashtable.Add("--.", "g");
            hashtable.Add("....", "h");
            hashtable.Add("..", "i");
            hashtable.Add(".---", "j");
            hashtable.Add("-.-", "k");
            hashtable.Add(".-..", "l");
            hashtable.Add("--", "m");
            hashtable.Add("-.", "n");
            hashtable.Add("---", "o");
            hashtable.Add(".--.", "p");
            hashtable.Add("--.-", "q");
            hashtable.Add(".-.", "r");
            hashtable.Add("...", "s");
            hashtable.Add("-", "t");
            hashtable.Add("..-", "u");
            hashtable.Add("...-", "v");
            hashtable.Add(".--", "w");
            hashtable.Add("-..-", "x");
            hashtable.Add("-.--", "y");
            hashtable.Add("--..", "z");
            hashtable.Add("-----", "0");
            hashtable.Add(".----", "1");
            hashtable.Add("..---", "2");
            hashtable.Add("...--", "3");
            hashtable.Add("....-", "4");
            hashtable.Add(".....", "5");
            hashtable.Add("-....", "6");
            hashtable.Add("--...", "7");
            hashtable.Add("---..", "8");
            hashtable.Add("----.", "9");
        }
    }
}
