using MorseCodeLibrary;
using System;
using System.IO;

namespace MorseCode {

    class MorseCodeDriver {

        static void Main(string[] args) {
            if (ValidArgs(args)) {
                string filePath = args[0];
                ITranslator translator = new MorseCodeTranslator();
                Console.WriteLine("Translating file: " + filePath);
                Console.WriteLine("Any invalid characters will be denoted by '!'\n");
                Console.WriteLine(translator.Translate(filePath));
            }
        }

        private static bool ValidArgs(string[] args) {
            bool valid = true;
            if (args.Length != 1) {
                Console.WriteLine("Error: Must have only one argument specifying a valid file path");
                valid = false;
            } else if (!File.Exists(args[0])) {
                Console.WriteLine("Error: Could not read file " + args[0]);
                valid = false;
            }

            return valid;
        }
    }
}
