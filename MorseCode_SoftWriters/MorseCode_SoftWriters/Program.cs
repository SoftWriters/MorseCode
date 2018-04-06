using System;

namespace MorseCode_SoftWriters
{
    class Program
    {
        static void Main(string[] args)
        {
            // path I used on my computer to test the input
            string path = "C:\\Users\\Taylor\\Desktop\\input.txt";

            // I'd expect some sort of check to be done in the system to make sure the file can actually be opened before passing in the path to the new class

            // creates a new MorseCode object and passes in the path
            MorseCode mc = new MorseCode(path);

            // string array that stores the lines of english words
            string[] sa = mc.ReturnEnglishArray();

            foreach(string output in sa)
            {
                Console.WriteLine(output);
            }

            Console.Out.Write("Press any key to continue");
            Console.ReadKey();

        }
    }
}
