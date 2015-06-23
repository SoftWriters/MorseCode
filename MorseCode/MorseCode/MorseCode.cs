using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
/**
 * This class contains a dictionary of Morse codes that match up to english characters.
 * It contains the method to convert Morse code into English text.
 * */
namespace MorseCode
{
    class MorseCode
    {
        private Dictionary<string, char> codes;

        public Dictionary<string, char> Codes
        {
            get { return codes; }
            set { }
        }

        /*
         * Constructor for MorseCode class. 
         * Fills list of codes when instantiated using the FillCodes method.
         * */
        public MorseCode()
        {
            codes = new Dictionary<string, char>();
            codes = FillCodes();
        }

        /*
         * Populates the list of codes and english character equivalent dictionary
         * */
        private Dictionary<string, char> FillCodes()
        {
            Dictionary<string, char> _codes = new Dictionary<string, char>();
            _codes.Add(".-", 'A');
            _codes.Add("-...", 'B');
            _codes.Add("-.-.", 'C');
            _codes.Add("-..", 'D');
            _codes.Add(".", 'E');
            _codes.Add("..-.", 'F');
            _codes.Add("--.", 'G');
            _codes.Add("....", 'H');
            _codes.Add("..", 'I');
            _codes.Add(".---", 'J');
            _codes.Add("-.-", 'K');
            _codes.Add(".-..", 'L');
            _codes.Add("--", 'M');
            _codes.Add("-.", 'N');
            _codes.Add("---", 'O');
            _codes.Add(".--.", 'P');
            _codes.Add("--.-", 'Q');
            _codes.Add(".-.", 'R');
            _codes.Add("...", 'S');
            _codes.Add("-", 'T');
            _codes.Add("..-", 'U');
            _codes.Add("...-", 'V');
            _codes.Add(".--", 'W');
            _codes.Add("-..-", 'X');
            _codes.Add("-.--", 'Y');
            _codes.Add("--..", 'Z');
            _codes.Add(".----", '1');
            _codes.Add("..---", '2');
            _codes.Add("...--", '3');
            _codes.Add("....-", '4');
            _codes.Add(".....", '5');
            _codes.Add("-....", '6');
            _codes.Add("--...", '7');
            _codes.Add("---..", '8');
            _codes.Add("----.", '9');
            _codes.Add("-----", '0');
            return _codes;
        }
        /*
         * This method takes in the morse code and returns the english character equivalent.
         * */
        private char convertSymbol(string str)
        {
            if (codes.Keys.Contains(str))
                return codes[str];
            else
                return '\0';
        }
        /*
         * This method converts morse code into english. 
         * Takes in morse code that is split on every newline character. 
         * Uses a stringbuilder to put together the english string passed a capacity to ensure efficiency.
         * Converts the lines of morse code into english text adding a newline after every line. 
         * Returns the english text. 
         * */
        public string toEnglish(string stuff)
        {
            StringBuilder sb = new StringBuilder(stuff.Length);
            string[] lines = stuff.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                string[] words = line.Split(new string[] { "||||" }, StringSplitOptions.None);
                foreach (string word in words)
                {
                    string[] symbols = word.Split(new string[] { "||" }, StringSplitOptions.None);
                    foreach (string symbol in symbols)
                    {
                            if (symbols.Length != 0)
                            {
                                sb.Append(convertSymbol(symbol));
                            }
                    }
                    sb.Append(" ");
                }
               
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
