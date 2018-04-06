using System;
using System.Collections.Generic;

namespace MorseCode_SoftWriters
{
    class MorseCode
    {
        private string[] readIn;
        private string[] englishArray = new string[0];

        // Dictionary that uses morse-code string as a key and an english character as the value
        private static IDictionary<string, string> morseChart = new Dictionary<string, string>()
        {
            {".-", "a"},
            {"-...", "b"},
            {"-.-.", "c"},
            {"-..", "d"},
            {".", "e"},
            {"..-.", "f"},
            {"--.", "g"},
            {"....", "h"},
            {"..", "i"},
            {".---", "j"},
            {"-.-", "k"},
            {".-..", "l"},
            {"--", "m"},
            {"-.", "n"},
            {"---", "o"},
            {".--.", "p"},
            {"--.-", "q"},
            {".-.", "r"},
            {"...", "s"},
            {"-", "t"},
            {"..-", "u"},
            {"...-", "v"},
            {".--", "w"},
            {"-..-", "x"},
            {"-.--", "y"},
            {"--..", "z"},
            {"", " " },
            {".----", "1" },
            {"..---", "2" },
            {"...--", "3" },
            {"....-", "4" },
            {".....", "5" },
            {"-....", "6" },
            {"--...", "7" },
            {"---..", "8" },
            {"----.", "9" },
            {"-----", "0" }
        };
        public MorseCode(string path)
        {
            // sets readIn to an array of morse-code strings seperated by line from the file located in 'path'
            readIn = System.IO.File.ReadAllLines(@path);


            // sets englishArray to a new array with the same size as 'readIn'
            englishArray = new string[readIn.Length];

            for (int i = 0; i < readIn.Length; i++)
            {
                // in each line, split the variables at the "||" and save each new string into a temporary array
                string[] temp = readIn[i].Split(new[] { "||" }, StringSplitOptions.None);

                string s = "";

                for (int j = 0; j < temp.Length; j++)
                {
                    // adds the english equivalent to the string 's' using the dictionary 'morseChart'
                    s += morseChart[temp[j]];
                }
                if (s.Length != 0)
                {
                    englishArray[i] = s;
                }
            }
        }
        public string[] ReturnEnglishArray()
        {
            //return englishArray
            return englishArray;
        }
    }
}
