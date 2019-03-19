using Microsoft.VisualStudio.TestTools.UnitTesting;
using MorseCodeLibrary;
using System;
using System.Diagnostics;

namespace MorseCodeTest {

    [TestClass]
    public class MorseCodeTest {

        [TestMethod]
        public void Test_Alphabet_A_Through_H() {
            string input = ".-||-...||-.-.||-..||.||..-.||--.||....";
            string output = MorseCodeTranslator.TranslateLine(input);

            Assert.AreEqual("abcdefgh", output);
        }

        [TestMethod]
        public void Test_Alphabet_I_Through_P() {
            string input = "..||.---||-.-||.-..||--||-.||---||.--.";
            string output = MorseCodeTranslator.TranslateLine(input);

            Assert.AreEqual("ijklmnop", output);
        }

        [TestMethod]
        public void Test_Alphabet_Q_Through_Z() {
            string input = "--.-||.-.||...||-||..-||...-||.--||-..-||-.--||--..";
            string output = MorseCodeTranslator.TranslateLine(input);

            Assert.AreEqual("qrstuvwxyz", output);
        }

        [TestMethod]
        public void Test_Numerals_One_Through_Five() {
            string input = ".----||..---||...--||....-||.....";
            string output = MorseCodeTranslator.TranslateLine(input);

            Assert.AreEqual("12345", output);
        }

        [TestMethod]
        public void Test_Numerals_Six_Through_Zero() {
            string input = "-....||--...||---..||----.||-----";
            string output = MorseCodeTranslator.TranslateLine(input);

            Assert.AreEqual("67890", output);
        }

        [TestMethod]
        public void Test_String_Dog() {
            string input = "-..||---||--.";
            string output = MorseCodeTranslator.TranslateLine(input);

            Assert.AreEqual("dog", output);
        }

        [TestMethod]
        public void Test_String_Hello_World() {
            string input = "....||.||.-..||.-..||---||||.--||---||.-.||.-..||-..";
            string output = MorseCodeTranslator.TranslateLine(input);
            Console.WriteLine(output);

            Assert.AreEqual("hello world", output);
        }

        [TestMethod]
        public void Test_String_Non_Morse() {
            string input = "This is not morse code";
            string output = MorseCodeTranslator.TranslateLine(input);
            Console.WriteLine(output);

            Assert.AreEqual("!", output);
        }

        [TestMethod]
        public void Test_String_Invalid_Morse() {
            string input = "....--.-.||-..||---||--.||    fs";
            string output = MorseCodeTranslator.TranslateLine(input);
            Console.WriteLine(output);

            Assert.AreEqual("!dog!", output);
        }
    }
}
