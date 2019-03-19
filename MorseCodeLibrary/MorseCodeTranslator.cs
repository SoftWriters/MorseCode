using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MorseCodeLibrary {

    public class MorseCodeTranslator : ITranslator {
        private IDictionary<string, string> dictionary = new Dictionary<string, string>() {
            { ".-", "a" }
            ,{ "-...", "b" }
            ,{ "-.-.", "c" }
            ,{ "-..", "d" }
            ,{ ".", "e" }
            ,{ "..-.", "f" }
            ,{ "--.", "g" }
            ,{ "....", "h" }
            ,{ "..", "i" }
            ,{ ".---", "j" }
            ,{ "-.-", "k" }
            ,{ ".-..", "l" }
            ,{ "--", "m" }
            ,{ "-.", "n" }
            ,{ "---", "o" }
            ,{ ".--.", "p" }
            ,{ "--.-", "q" }
            ,{ ".-.", "r" }
            ,{ "...", "s" }
            ,{ "-", "t" }
            ,{ "..-", "u" }
            ,{ "...-", "v" }
            ,{ ".--", "w" }
            ,{ "-..-", "x" }
            ,{ "-.--", "y" }
            ,{ "--..", "z" }
            ,{ ".----", "1" }
            ,{ "..---", "2" }
            ,{ "...--", "3" }
            ,{ "....-", "4" }
            ,{ ".....", "5" }
            ,{ "-....", "6" }
            ,{ "--...", "7" }
            ,{ "---..", "8" }
            ,{ "----.", "9" }
            ,{ "-----", "0" }
            ,{ ",", " "}
        };

        /// <summary>
        /// Translates a file containing morse code.
        /// </summary>
        /// <param name="inputFilePath">The file to translate</param>
        /// <returns>A string containing the translation</returns>
        public string Translate(string inputFilePath) {
            StringBuilder sb = new StringBuilder();

            var lines = File.ReadLines(inputFilePath);
            foreach (var line in lines) {
                string translatedLine = TranslateLine(line);
                sb.Append(translatedLine);
                sb.AppendLine();
            }

            return sb.ToString();
        }
        
        /// <summary>
        /// Returns the translation of an individual line of morse code.
        /// </summary>
        /// <param name="line">The line to translate</param>
        /// <returns>The translated line</returns>
        public string TranslateLine(string line) {
            StringBuilder sb = new StringBuilder();

            // Replace two breaks in a row with a comma in between, signifying a space
            string formattedLine = line.Trim().Replace("||||", "||,||");

            string[] letters = formattedLine.Split("||");
            foreach (string letter in letters) {
                string value = dictionary.ContainsKey(letter) ? dictionary[letter] : "!";
                sb.Append(value);
            }

            return sb.ToString();
        }
    }
}
