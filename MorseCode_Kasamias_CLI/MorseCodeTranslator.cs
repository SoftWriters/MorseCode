using System;
using System.Collections.Generic;
using System.IO;




namespace MorseCode_Kasamias_CLI
{
    public class MorseCodeTranslator
    {

            /// <summary>
            /// Converts Morse Code file to English text, and saves new file to the directory of the given input file. 
            /// </summary>
            /// <param name="fileName"></param>
            public void ReadFileAndSave(string fileName)
            {
             

                string outputFile = "ConvertedFile.txt";

                Console.WriteLine("File contains the following translated text: ");
                Console.WriteLine();

                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            //read in line
                            string line = sr.ReadLine();

                            string[] convertedLine = Translator(line);
                          

                            // write converted line onto new file-- .txt
                            try
                            {
                                using (StreamWriter sw = new StreamWriter(outputFile, true))
                                {
                                    string newLine = string.Join("", convertedLine);
                                    sw.WriteLine(newLine);
                                    sw.WriteLine();

                                
                                Console.WriteLine(newLine);
                                Console.WriteLine();

                                
                                }
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("Error writing file");
                                Console.WriteLine(e.Message);
                            }

                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error reading file.");
                    Console.WriteLine(e.Message);
                }
                

            }

            /// <summary>
            /// Returns array of translated text.
            /// </summary>
            /// <param name="lineInput"></param>
            /// <returns></returns>
            public string[] Translator(string lineInput)
            {

                string[] lineArray = lineInput.Split("||");
                string[] convertedLine = new string[lineArray.Length];


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

                return convertedLine;

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
