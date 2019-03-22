using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MorseCode
{
    public class MorseCodeToEnglishTranslator : IOneWayTranslator
    {
        private IDictionary<string, char> morseToCharDict;

        public MorseCodeToEnglishTranslator()
        {
            morseToCharDict = new Dictionary<string, char>
            {
                { ".-", 'a' },
                { "-...", 'b' },
                { "-.-.", 'c' },
                { "-..", 'd' },
                { ".", 'e' },
                { "..-.", 'f' },
                { "--.", 'g' },
                { "....", 'h' },
                { "..", 'i' },
                { ".---", 'j' },
                { "-.-", 'k' },
                { ".-..", 'l' },
                { "--", 'm' },
                { "-.", 'n' },
                { "---", 'o' },
                { ".--.", 'p' },
                { "--.-", 'q' },
                { ".-.", 'r' },
                { "...", 's' },
                { "-", 't' },
                { "..-", 'u' },
                { "...-", 'v' },
                { ".--", 'w' },
                { "-..-", 'x' },
                { "-.--", 'y' },
                { "--..", 'z' },
                { "-----", '0' },
                { ".----", '1' },
                { "..---", '2' },
                { "...--", '3' },
                { "....-", '4' },
                { ".....", '5' },
                { "-....", '6' },
                { "--...", '7' },
                { "---..", '8' },
                { "----.", '9' }
            };
        }

        public IList<string> TranslateFile(string file)
        {
            IList<string> result = new List<string>();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                result.Add(TranslateLine(line));
            }

            return result;
        }

        public string TranslateLine(string line)
        {
            string[] split = line.Split(new string[] { "||" }, StringSplitOptions.None);
            StringBuilder sb = new StringBuilder();
            foreach (string s in split)
            {
                if (s.Length == 0)
                {
                    sb.Append(" ");
                } else if (morseToCharDict.ContainsKey(s))
                {
                    sb.Append(morseToCharDict[s]);
                } else
                {
                    sb.Append('*');
                }
            }

            return sb.ToString();
        }
    }
}
