using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MorseCodeTranslateToEnglish
{
    class Program
    {

        static Dictionary<string, char> morse;

        static void Main(string[] args)
        {
            InitialiseDictionary();
            readFromFile();                
        }

        private static void InitialiseDictionary()
        {
           morse = new Dictionary<string, char>()  //dictionary to translate morse code to characers
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
                {"--..",'z' },
                {".----",'1'},
                {"..---",'2'},
                {"...--",'3'},
                {"....-",'4'},
                {".....",'5'},
                {"-....",'6'},
                {"--...",'7'},
                {"---..",'8'},
                {"----.",'9'},
                {"-----",'0'},
                {"", ' ' }
            };
        }

        public static void readFromFile()
        {
            try                                               //attempts to access the file C:\Temp\MorrisCodeFile.txt. If the file cannot be accessed, then the user will receive notification of file read failure
            { 
                string input = System.IO.File.ReadAllText(@"C:\Temp\MorrisCodeFile.txt");
                input = input.Replace("||", " ").Replace("\r", " \r").Replace("\n", " \n "); //replaces the  || delimiter with a space, also a space after carriage return and line feed
                Console.WriteLine(translate(input));
                Console.WriteLine("Press enter to end.");
                Console.ReadKey(false);
            }
            catch
            {
                Console.WriteLine("The file doesn't exist. Please check the file location and file name. (C:\\Temp\\MorrisCodeFile.txt)");
                Console.WriteLine("Press any key to close.");
                Console.ReadKey(false);
            }
        }

        private static string translate(string input)
        {

            string[] words = input.Split(' ');          //separates the morse code into individual words based on single space
            StringBuilder sb = new StringBuilder();
            foreach (string word in words)
            {
                if (morse.Keys.Contains(word))        //if the value exists in the dictionary, then it will display the associated character value
                    sb.Append(morse[word]);
                else sb.Append(word);                  //if the value does not exist, then the value will be used (mainly for troubleshooting purposes)
            }
            return sb.ToString();
        }
    }
}
