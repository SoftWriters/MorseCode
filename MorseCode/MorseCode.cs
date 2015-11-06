using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/* Justin Onofrey  
 * SoftWriters Application
 * 11/6/2015 
 */

namespace MorseCode
{
    public class MorseCode
    {
        #region Constants
        private const string S_DELIMITER = "||";
        private const string S_ERROR = "ERROR";

        private const string S_EX_EXCEPTION = "Error: An exception has occurred:";

        private const string S_A_MORSE = ".-";
        private const string S_B_MORSE = "-...";
        private const string S_C_MORSE = "-.-.";
        private const string S_D_MORSE = "-..";
        private const string S_E_MORSE = ".";
        private const string S_F_MORSE = "..-.";
        private const string S_G_MORSE = "--.";
        private const string S_H_MORSE = "....";
        private const string S_I_MORSE = "..";
        private const string S_J_MORSE = ".---";
        private const string S_K_MORSE = "-.-";
        private const string S_L_MORSE = ".-..";
        private const string S_M_MORSE = "--";
        private const string S_N_MORSE = "-.";
        private const string S_O_MORSE = "---";
        private const string S_P_MORSE = ".--.";
        private const string S_Q_MORSE = "--.-";
        private const string S_R_MORSE = ".-.";
        private const string S_S_MORSE = "...";
        private const string S_T_MORSE = "-";
        private const string S_U_MORSE = "..-";
        private const string S_V_MORSE = "...-";
        private const string S_W_MORSE = ".--";
        private const string S_X_MORSE = "-..-";
        private const string S_Y_MORSE = "-.--";
        private const string S_Z_MORSE = "--..";

        private const string S_1_MORSE = ".----";
        private const string S_2_MORSE = "..---";
        private const string S_3_MORSE = "...--";
        private const string S_4_MORSE = "....-";
        private const string S_5_MORSE = ".....";
        private const string S_6_MORSE = "-....";
        private const string S_7_MORSE = "--...";
        private const string S_8_MORSE = "---..";
        private const string S_9_MORSE = "----.";
        private const string S_10_MORSE = "-----";

        private const string S_A_ENGLISH = "A";
        private const string S_B_ENGLISH = "B";
        private const string S_C_ENGLISH = "C";
        private const string S_D_ENGLISH = "D";
        private const string S_E_ENGLISH = "E";
        private const string S_F_ENGLISH = "F";
        private const string S_G_ENGLISH = "G";
        private const string S_H_ENGLISH = "H";
        private const string S_I_ENGLISH = "I";
        private const string S_J_ENGLISH = "J";
        private const string S_K_ENGLISH = "K";
        private const string S_L_ENGLISH = "L";
        private const string S_M_ENGLISH = "M";
        private const string S_N_ENGLISH = "N";
        private const string S_O_ENGLISH = "O";
        private const string S_P_ENGLISH = "P";
        private const string S_Q_ENGLISH = "Q";
        private const string S_R_ENGLISH = "R";
        private const string S_S_ENGLISH = "S";
        private const string S_T_ENGLISH = "T";
        private const string S_U_ENGLISH = "U";
        private const string S_V_ENGLISH = "V";
        private const string S_W_ENGLISH = "W";
        private const string S_X_ENGLISH = "X";
        private const string S_Y_ENGLISH = "Y";
        private const string S_Z_ENGLISH = "Z";

        private const string S_1_ENGLISH = "1";
        private const string S_2_ENGLISH = "2";
        private const string S_3_ENGLISH = "3";
        private const string S_4_ENGLISH = "4";
        private const string S_5_ENGLISH = "5";
        private const string S_6_ENGLISH = "6";
        private const string S_7_ENGLISH = "7";
        private const string S_8_ENGLISH = "8";
        private const string S_9_ENGLISH = "9";
        private const string S_10_ENGLISH = "10";

        private const string S_SPACE = " ";
        #endregion

        #region Constructor
        
        public MorseCode()
        {
        }
        #endregion

        #region Methods
        public string TranslateMorseCodeFile(string sourceFileLocation, string outputFileLocation)
        {
            string result = "Success!";

            try
            {
                // Set our delimiter
                string[] delimiter = { S_DELIMITER };

                // Get our source text
                string[] sourceLines = File.ReadAllLines(sourceFileLocation);

                string[] englishLines = new string[sourceLines.Length];
                string currentLine;
                string[] morseLetters;

                for (int i = 0; i < sourceLines.Length; i++)
                {
                    currentLine = "";
                    morseLetters = sourceLines[i].Split(delimiter, StringSplitOptions.None);

                    for (int j = 0; j < morseLetters.Length; j++)
                    {
                        currentLine += (mapLetter(morseLetters[j]));
                    }

                    englishLines[i] = currentLine;
                }

                // Write our output to output file.
                File.WriteAllLines(outputFileLocation, englishLines);
            }
            catch (Exception ex)
            {
                // Formally log exceptions here and send back in return object if applicable
                result = S_EX_EXCEPTION + ex.Message;
            }

            return result;
        }

        // We use a string as the output over a char because a char cannot hold all the outputs we wish to return
        private string mapLetter(string morseLetter)
        {
            string englishLetter;

            // Check for an empty space to denote a space character in a sentence.
            if (String.IsNullOrEmpty(morseLetter))
            {
                englishLetter = S_SPACE;
                return englishLetter;
            }

            // Check for a valid letter or number
            switch (morseLetter)
            {
                case S_A_MORSE:
                    englishLetter = S_A_ENGLISH;
                    break;
                case S_B_MORSE:
                    englishLetter = S_B_ENGLISH;
                    break;
                case S_C_MORSE:
                    englishLetter = S_C_ENGLISH;
                    break;
                case S_D_MORSE:
                    englishLetter = S_D_ENGLISH;
                    break;
                case S_E_MORSE:
                    englishLetter = S_E_ENGLISH;
                    break;
                case S_F_MORSE:
                    englishLetter = S_F_ENGLISH;
                    break;
                case S_G_MORSE:
                    englishLetter = S_G_ENGLISH;
                    break;
                case S_H_MORSE:
                    englishLetter = S_H_ENGLISH;
                    break;
                case S_I_MORSE:
                    englishLetter = S_I_ENGLISH;
                    break;
                case S_J_MORSE:
                    englishLetter = S_J_ENGLISH;
                    break;
                case S_K_MORSE:
                    englishLetter = S_K_ENGLISH;
                    break;
                case S_L_MORSE:
                    englishLetter = S_L_ENGLISH;
                    break;
                case S_M_MORSE:
                    englishLetter = S_M_ENGLISH;
                    break;
                case S_N_MORSE:
                    englishLetter = S_N_ENGLISH;
                    break;
                case S_O_MORSE:
                    englishLetter = S_O_ENGLISH;
                    break;
                case S_P_MORSE:
                    englishLetter = S_P_ENGLISH;
                    break;
                case S_Q_MORSE:
                    englishLetter = S_Q_ENGLISH;
                    break;
                case S_R_MORSE:
                    englishLetter = S_R_ENGLISH;
                    break;
                case S_S_MORSE:
                    englishLetter = S_S_ENGLISH;
                    break;
                case S_T_MORSE:
                    englishLetter = S_T_ENGLISH;
                    break;
                case S_U_MORSE:
                    englishLetter = S_U_ENGLISH;
                    break;
                case S_V_MORSE:
                    englishLetter = S_V_ENGLISH;
                    break;
                case S_W_MORSE:
                    englishLetter = S_W_ENGLISH;
                    break;
                case S_X_MORSE:
                    englishLetter = S_X_ENGLISH;
                    break;
                case S_Y_MORSE:
                    englishLetter = S_Y_ENGLISH;
                    break;
                case S_Z_MORSE:
                    englishLetter = S_Z_ENGLISH;
                    break;
                case S_1_MORSE:
                    englishLetter = S_1_ENGLISH;
                    break;
                case S_2_MORSE:
                    englishLetter = S_2_ENGLISH;
                    break;
                case S_3_MORSE:
                    englishLetter = S_3_ENGLISH;
                    break;
                case S_4_MORSE:
                    englishLetter = S_4_ENGLISH;
                    break;
                case S_5_MORSE:
                    englishLetter = S_5_ENGLISH;
                    break;
                case S_6_MORSE:
                    englishLetter = S_6_ENGLISH;
                    break;
                case S_7_MORSE:
                    englishLetter = S_7_ENGLISH;
                    break;
                case S_8_MORSE:
                    englishLetter = S_8_ENGLISH;
                    break;
                case S_9_MORSE:
                    englishLetter = S_9_ENGLISH;
                    break;
                case S_10_MORSE:
                    englishLetter = S_10_ENGLISH;
                    break;                
                default:
                    englishLetter = S_ERROR; // If the text found is not a valid morse code, then return error
                    break;
            }

            return englishLetter;
        }

        #endregion

    }
}
