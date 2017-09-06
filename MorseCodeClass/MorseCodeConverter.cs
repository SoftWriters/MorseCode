using System;
using System.Collections.Generic;

namespace MorseCodeClass
{
    /// <summary>
    /// Provides basic operations to convert to//from Morse Code
    /// </summary>
    public class MorseCodeConverter
    {
        /// <summary>
        /// Lookup table for text to morse code
        /// </summary>
        private IDictionary<string, string> MorseCodeTable = new Dictionary<string, string>();
        
        private string sNewLine = "\r\n"; // Default EOL as CR/LF

        public MorseCodeConverter()
        {
            Build_MorseCodeLookupTable();
        }

        /// <summary>
        /// string to use for new line.
        /// </summary>
        public string NewLine
        {
            get { return sNewLine; }
            set
            {
                if (sNewLine.Contains(".") || sNewLine.Contains("-") || sNewLine.Contains("|"))
                    throw new Exception("NewLine cannont contain '.','-' or '|'");
                else
                    sNewLine = value;
            }
        }

        /// <summary>
        /// Convert a string in Morse Code to a string to plain text.
        /// </summary>
        /// <param name="MorseCode">String in Morse Code to convert</param>
        /// <returns>Converted Plain text</returns>
        public string MorseCode_ToText(string MorseCode)
        {
            string PlainText = "";

            // Whatever newline character(s) are, change to CR only to split into seperate lines.
            string[] Lines = MorseCode.Replace(sNewLine,"\r").Split('\r');

            for (int iIndex = 0; iIndex< Lines.Length;iIndex++)
            {
                // Can only use split with charcacters, not strings so change every break notaed by "||" to "|" first
                string[] Letters = Lines[iIndex].Replace("||", "|").Split('|');

                foreach (string SingleLetter in Letters)
                {
                        string ConvertedMorseCode = "";

                        if (MorseCodeTable.TryGetValue(SingleLetter, out ConvertedMorseCode))
                            PlainText += ConvertedMorseCode;
                        else
                            PlainText += "?"; // Could not convert this text.  Not A-Z or 0-9
                }
                
                if (iIndex != Lines.Length-1) PlainText += sNewLine; // Done with line.  Add new line 
            }

            return PlainText;
        }

        /// <summary>
        /// Convert a string in plain text to a string of Morse Code.
        /// </summary>
        /// <param name="Text">String of Plain Textto convert</param>
        /// <returns>Converted Morse Coe</returns>
        public string Text_ToMorseCode(string Text)
        {
            string MorseCode = "";

            // Whatever newline character(s) are, change to CR only to split into seperate lines.
            // If EOL was always single character, would not need to split into lines like this.  
            string[] Lines = Text.Replace(sNewLine, "\r").Split('\r');

            // ForEach would be nice here, but then have to deal with not putting a trailing CR/LF
            for (int iLineNum = 0; iLineNum < Lines.Length; iLineNum++)
            {
                for (int iIndex = 0; iIndex < Lines[iLineNum].Length; iIndex++)
                {
                    MorseCode += TextToMorse(Lines[iLineNum].Substring(iIndex, 1));
                    if (iIndex != Lines[iLineNum].Length - 1) MorseCode += "||"; // Break between each letter or space.
                }

                if (iLineNum != Lines.Length - 1) MorseCode += sNewLine; // Done with line.  Add new line 
            }

            return MorseCode;
        }

            /// <summary>
            /// Populates a dictionary of Morse Code to use to conver letters/numbers to Morse Code. 
            /// </summary>
            private void Build_MorseCodeLookupTable()
        {
            MorseCodeTable.Clear();
            MorseCodeTable.Add(".-", "A");
            MorseCodeTable.Add("-...", "B");
            MorseCodeTable.Add("-.-.", "C");
            MorseCodeTable.Add("-..", "D");
            MorseCodeTable.Add(".","E");
            MorseCodeTable.Add("..-.", "F");
            MorseCodeTable.Add("--.", "G");
            MorseCodeTable.Add("....", "H");
            MorseCodeTable.Add("..", "I");
            MorseCodeTable.Add(".---", "J");
            MorseCodeTable.Add("-.-", "K");
            MorseCodeTable.Add(".-..", "L");
            MorseCodeTable.Add("--", "M");
            MorseCodeTable.Add("-.", "N");
            MorseCodeTable.Add("---", "O");
            MorseCodeTable.Add(".--.", "P");
            MorseCodeTable.Add("--.-", "Q");
            MorseCodeTable.Add(".-.", "R");
            MorseCodeTable.Add("...", "S");
            MorseCodeTable.Add("-", "T");
            MorseCodeTable.Add("..-", "U");
            MorseCodeTable.Add("...-", "V");
            MorseCodeTable.Add(".--", "W");
            MorseCodeTable.Add("-..-", "X");
            MorseCodeTable.Add("-.--", "Y");
            MorseCodeTable.Add("--..", "Z");

            MorseCodeTable.Add(".----", "1");
            MorseCodeTable.Add("..---", "2");
            MorseCodeTable.Add("...--", "3");
            MorseCodeTable.Add("....-", "4");
            MorseCodeTable.Add(".....", "5");
            MorseCodeTable.Add("-....", "6");
            MorseCodeTable.Add("--...", "7");
            MorseCodeTable.Add("---..", "8");
            MorseCodeTable.Add("----.", "9");
            MorseCodeTable.Add("-----", "0");

            MorseCodeTable.Add("", " "); // Two breaks in a row create this...which is a space between words

        }

        /// <summary>
        /// Converts one single character to the corrosponding morse code  
        /// </summary>
        /// <param name="text">character to convert to Morse Code</param>
        /// <returns>Morse Code representation</returns>
        private string TextToMorse(string text)
        {
            if (text.Length != 1) throw new Exception("TextToMorse accepts only a single character!");

            switch(text.ToUpper())
            {
                case "A": return ".-";
                case "B": return "-...";
                case "C":return "-.-.";
                case "D": return "-..";
                case "E": return ".";
                case "F": return "..-.";
                case "G": return "--.";
                case "H": return "....";
                case "I": return "..";
                case "J": return ".---";
                case "K": return "-.-";
                case "L": return ".-..";
                case "M": return "--";
                case "N": return "-.";
                case "O": return "---";
                case "P":return ".--.";
                case "Q": return "--.-";
                case "R": return ".-.";
                case "S": return "...";
                case "T": return "-";
                case "U": return "..-";
                case "V": return "...-";
                case "W": return ".--";
                case "X": return "-..-";
                case "Y": return "-.--";
                case "Z": return "--..";

                case "1":return ".----";
                case "2": return "..---";
                case "3": return "...--";
                case "4": return "....-";
                case "5": return ".....";
                case "6": return "-....";
                case "7": return "--...";
                case "8": return "---..";
                case "9":return "----.";
                case "0": return "-----";

                case " ": return "||";

                default: return "?";

            };
            
        }
        
    }
}
