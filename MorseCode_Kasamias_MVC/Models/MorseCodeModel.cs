using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;


namespace MorseCode_Kasamias.Models
{
    public class MorseCodeModel
    {

        public IFormFile File { get; set; }

        public List<string> ConvertedText { get; set; }
    
        /// <summary>
        /// Converts Morse Code file to English text, and returns List of each line of text, converted. 
        /// </summary>
        /// <param name="file"></param>
        public List<string> ReadFileAndSave(IFormFile file)
        {
            
            //holds text, line by line
            List<string> output = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(file.OpenReadStream()))
                {
                    while (!sr.EndOfStream)
                    {
                        //read in line
                        string line = sr.ReadLine();

                        string newLine = Translator(line);
           
                        output.Add(newLine);


                    }



                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading file.");
                Console.WriteLine(e.Message);
            }

            return output;
        }



        /// <summary>
        /// Helper function for conversion.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string Translator(string line)
        {
            //TODO conversion here
            string[] lineArray = line.Split("||");
            string[] convertedLine = new string[lineArray.Length];

            //TODO question if I need a linq statement
            for (int i = 0; i < lineArray.Length; i++)
            {

                foreach (KeyValuePair<string, string> kvp in morseAlphabet)
                {
                    if (lineArray[i] == kvp.Key)
                    {
                        //save to new array
                        convertedLine[i] = kvp.Value;

                    }
                }
            }

            string newLine = string.Join("", convertedLine);

            return newLine;


        }


        public static Dictionary<string, string> morseAlphabet = new Dictionary<string, string>()
            {
                {".-", "a" },
                {"-...", "b" },
                {"-.-.", "c" },
                {"-..", "d" },
                {".", "e" },
                {"..-.", "f" },
                {"--.", "g" },
                {"....", "h" },
                {"..", "i" },
                {".---", "j" },
                {"-.-", "k" },
                {".-..", "l" },
                {"--", "m" },
                {"-.", "n" },
                {"---", "o" },
                {".--.", "p" },
                {"--.-", "q" },
                {".-.", "r" },
                {"...", "s" },
                {"-", "t" },
                {"..-", "u" },
                {"...-", "v" },
                {".--", "w" },
                {"-..-", "x" },
                {"-.--", "y" },
                {"--..", "z" },


                {"", " " },

                {"||", "" }

            };

        









    }
}
