using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;


namespace MorseCode.Tests
{
    /// <summary>
    /// Test class for unit testing
    /// Calls either ConvertFile or ConvertLine on the converter
    /// member variable, and Asserts values based on what the Morse 
    /// code should be
    /// </summary>
    [TestClass()]
    public class MorseCodeToEnglishConverterTests
    {
        private readonly MorseCodeToEnglishConverter converter = new MorseCodeToEnglishConverter();

        [TestMethod()]
        public void ConvertFileTest()
        {
            CreateFileForTesting("test.txt", "-..||---||--." 
                + System.Environment.NewLine 
                + "....||.||.-..||.-..||---||||.--||---||.-.||.-..||-..");
            List<string> result = (List<string>)converter.ConvertFile("test.txt");
            DeleteFileForTesting("test.txt");
            CollectionAssert.AreEqual(new List<string> { "dog", "hello world" }, result);
        }

        [TestMethod()]
        public void ConvertLineTest()
        {
            string result = converter.ConvertLine("..-.||---||---");
            Assert.AreEqual("foo", result);
        }

        [TestMethod()] 
        public void NumberTest()
        {
            string result = converter.ConvertLine(".----||..---||||...--");
            Assert.AreEqual("12 3", result);
        }

        [TestMethod()]
        public void InvalidCharTest()
        {
            string result = converter.ConvertLine("........||.-");
            Assert.AreEqual("*a", result);
        }

        [TestMethod()]
        public void InvalidCharsTest()
        {
            string result = converter.ConvertLine("f||o||o||.-");
            Assert.AreEqual("***a", result);
        }

        [TestMethod()]
        public void ThreeBreaksTest()
        {
            string result = converter.ConvertLine("..-.||---||---||||||-...||.-||.-.");
            Assert.AreEqual("foo  bar", result);
        }

        [TestMethod()]
        public void InvalidBreakTest()
        {
            string result = converter.ConvertLine("..|.-|-.||.-");
            Assert.AreEqual("*a", result);
        }

        [TestMethod()]
        public void NumberAndCharTest()
        {
            string result = converter.ConvertLine("..||-.||||-....||...--");
            Assert.AreEqual("in 63", result);
        }

        [TestMethod()]
        public void NumberAndCharAndInvalidTest()
        {
            string result = converter.ConvertLine("..||n||||-....||...--");
            Assert.AreEqual("i* 63", result);
        }

        [TestMethod()]
        public void EmptyFileTest()
        {
            CreateFileForTesting("empty.txt", "");
            IList<string> result = converter.ConvertFile("empty.txt");
            DeleteFileForTesting("empty.txt");
            Assert.IsTrue((result.Count == 0));
        }

        [TestMethod()]
        public void BigFileTest()
        {
            CreateFileForTesting("test.txt", "-..||---||--."
                + System.Environment.NewLine
                + "....||.||.-..||.-..||---||||.--||---||.-.||.-..||-.."
                + System.Environment.NewLine
                + "-||....||..||...||||..||...||||.-||||-||.||...||-||||...||-||.-.||..||-.||--."
                + System.Environment.NewLine 
                + ".-..||---||.-.||.||--||||..||.--.||...||..-||--" +
                "||||-..||---||.-..||---||.-.||||...||..||-||||.-||--||.||-");
            List<string> result = (List<string>)converter.ConvertFile("test.txt");
            DeleteFileForTesting("test.txt");
            CollectionAssert.AreEqual(
                new List<string> { "dog", "hello world", "this is a test string", "lorem ipsum dolor sit amet" }, 
                result);
        }


        private void CreateFileForTesting(string filename, string text)
        {
            File.WriteAllText(filename, text);
        }

        private void DeleteFileForTesting(string filename)
        {
            File.Delete(filename);
        }
    }
}