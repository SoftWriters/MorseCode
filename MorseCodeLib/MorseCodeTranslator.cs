using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace MorseCodeLib
{
    public class MorseCodeTranslator
    {
        private static Dictionary<string, char> _dictonary;

        /// <summary>
        /// Morse Code dictonary obtained from the Morse Code wikipedia page. 
        /// Contains alphanumeric characters and as a subset of symbols and punctuation.
        /// </summary>
        static MorseCodeTranslator()
        {
            _dictonary = new Dictionary<string, char>()
            {
                {".-",'a'},
                {"-...",'b'},
                {"-.-.",'c'},
                {"-..",'d'},
                {".",'e'},
                {"..-.",'f'},
                {"--.",'g'},
                {"....",'h'},
                {"..",'i'},
                {".---",'j'},
                {"-.-",'k'},
                {".-..",'l'},
                {"--",'m'},
                {"-.",'n'},
                {"---",'o'},
                {".--.",'p'},
                {"--.-",'q'},
                {".-.",'r'},
                {"...",'s'},
                {"-",'t'},
                {"..-",'u'},
                {"...-",'v'},
                {".--",'w'},
                {"-..-",'x'},
                {"-.--",'y'},
                {"--..",'z'},
                {"-----",'0'},
                {".----",'1'},
                {"..---",'2'},
                {"...--",'3'},
                {"....-",'4'},
                {".....",'5'},
                {"-....",'6'},
                {"--...",'7'},
                {"---..",'8'},
                {"----.",'9'},
                {".-.-.-",'.'},
                {"..--..",'?'},
                {"--..--",','},
                {"-..-.",'/'},
                {".--.-.",'@'},
                {"---...",':'},
                {"-.-.-.",';'},
                {".----.",'\''},
                {"-....-",'-'},
                {".-.-.",'+'},
                {"-.--.",'('},
                {"-.--.-",')'},
                {".-..-.",'\"'},
                {"-...-",'='},
                {"..--.-",'_'},
                {"...-..-",'$'},
                {".-...",'&'},
                {"-.-.--",'!'}
            };
        }

        /// <summary>
        /// Reads each line of a file
        /// </summary>
        /// <param name="fileName">A filepath to MyTests where the uploaded test files reside</param>
        /// <returns></returns>
        public StringBuilder TranslateInput(string fileName)
        {
            StringBuilder builtString = new StringBuilder();
            MatchCollection invalidChar = null;
            string[] lines = File.ReadAllLines(fileName);
            for(int i = 0; i < lines.Length; i++)
            {
                invalidChar = Regex.Matches(lines[i], @"[^*-|]");
                if (invalidChar.Count > 0)
                {   //Exception will need to be caught in that class utilizing this method
                    throw new System.ArgumentException($"Line #{i} contains an invalid character: \"{invalidChar[0]}\"\n This translator can only translate morse code characters: \"*\", \"-\", and \"|\"");
                }

                builtString.Append(translate(lines[i]));
            }
            return builtString;            
        }

        /// <summary>
        /// Translates the Morse Code into English 
        /// </summary>
        /// <param name="input">A single line from the file</param>
        /// <returns></returns>
        public StringBuilder translate(string input)
        {
            StringBuilder sb = new StringBuilder();
            string[] wordDelimiter = new string[] { "||||" };
            string[] letterDelimiter = new string[] { "||" };
            string[] morseWords = input.Split(wordDelimiter, StringSplitOptions.None);

            foreach (string word in morseWords) 
            {
                string[] morseLetters = word.Split(letterDelimiter, StringSplitOptions.None);
                foreach (string letter in morseLetters)
                {
                    if (_dictonary.ContainsKey(letter))
                    {
                        sb.Append(_dictonary[letter]);              //Appends the cooresponding letter to the english word
                    }
                }
                if (morseWords.Last() != word) { sb.Append(' '); }  //Append a space to all words except the last
            }
            return sb;
        }
    }
}
