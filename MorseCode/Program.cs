using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode {
	public class Program {
		public static void Main(string[] args) {
			if (args.Length != 1) {
				Console.WriteLine("Enter the path of the input file to translate.");
				return;
			}
			var inputFile = args[0];
			if (!File.Exists(inputFile)) {
				Console.WriteLine("The specified file does not exist.");
				return;
			}
			foreach (var translatedLine in TranslateFileLines(inputFile)) {
				Console.WriteLine(translatedLine);
			}
		}

		public static IEnumerable<string> TranslateFileLines(string filePath) {
			foreach (var line in File.ReadLines(filePath)) {
				yield return Morse.DecodeString(line.Trim());//Trim whitespace and feed to translation
			}
		}
	}
}
