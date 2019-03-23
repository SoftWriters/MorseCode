using MorseCode.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MorseCode
{
    /// <summary>
    /// A converter for Morse code to English
    /// Implements the OneWayConverter interface
    /// </summary>
    public class MorseCodeToEnglishConverter : IOneWayConverter
    {
        //The dictionary used for conversion
        private IDictionary<string, char> morseToCharDict;

        /// <summary>
        /// Creates a new MorseCodeToEnglishConverter
        /// Initializes the dictionary based on Morse code to English
        /// </summary>
        public MorseCodeToEnglishConverter()
        {
            morseToCharDict = new Dictionary<string, char>();
            string[] lines = Resources.MorseToEnglish.Split(
                new string[] { System.Environment.NewLine }, 
                StringSplitOptions.None);
            foreach (string line in lines) {
                string[] keyValue = line.Split(new char[] { ',' });
                morseToCharDict.Add(keyValue[0], keyValue[1][0]);
            }
        }

        /// <summary>
        /// Converts a file that has lines containing Morse code
        /// to English characters
        /// </summary>
        /// <param name="file">The file path of the file, will already have been verified to exist</param>
        /// <returns>A list containing the English representation of the Morse code of each line of the file</returns>
        public IList<string> ConvertFile(string file)
        {
            //Create result variable
            IList<string> result = new List<string>();
            //Read all lines of the file
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                //Add each converted line
                result.Add(ConvertLine(line));
            }

            return result;
        }

        /// <summary>
        /// Converts a line of Morse code to a line of English text
        /// </summary>
        /// <param name="line">the line to convert</param>
        /// <returns>a new string that is converted from Morse code to English</returns>
        public string ConvertLine(string line)
        {
            string[] split = line.Split(new string[] { "||" }, StringSplitOptions.None);
            StringBuilder sb = new StringBuilder();
            foreach (string letter in split)
            {
                //If there are two breaks in a row add a space
                if (letter.Length == 0)
                {
                    sb.Append(" ");
                }
                else if (morseToCharDict.ContainsKey(letter))
                {
                    //Append character in dictionary if the dictionary contains the current string
                    sb.Append(morseToCharDict[letter]);
                }
                else
                {
                    //If the string of characters is not in the dictionary append a *
                    sb.Append('*');
                }
            }
            //Build the string
            return sb.ToString();
        }
    }
}
