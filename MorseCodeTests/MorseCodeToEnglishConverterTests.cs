using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;


namespace MorseCode.Tests
{
    /// <summary>
    /// Test class for unit testing
    /// </summary>
    [TestClass()]
    public class MorseCodeToEnglishConverterTests
    {
        private readonly MorseCodeToEnglishConverter translator = new MorseCodeToEnglishConverter();

        [TestMethod()]
        public void ConvertFileTest()
        {
            CreateFileForTesting("test.txt", "-..||---||--." 
                + System.Environment.NewLine 
                + "....||.||.-..||.-..||---||||.--||---||.-.||.-..||-..");
            List<string> result = (List<string>)translator.ConvertFile("test.txt");
            DeleteFileForTesting("test.txt");
            CollectionAssert.AreEqual(new List<string> { "dog", "hello world" }, result);
        }

        [TestMethod()]
        public void ConvertLineTest()
        {
            string result = translator.ConvertLine("..-.||---||---");
            Assert.AreEqual("foo", result);
        }

        [TestMethod()] 
        public void NumberTest()
        {
            string result = translator.ConvertLine(".----||..---||||...--");
            Assert.AreEqual("12 3", result);
        }

        [TestMethod()]
        public void InvalidCharTest()
        {
            string result = translator.ConvertLine("........||.-");
            Assert.AreEqual("*a", result);
        }

        [TestMethod()]
        public void InvalidCharsTest()
        {
            string result = translator.ConvertLine("f||o||o||.-");
            Assert.AreEqual("***a", result);
        }

        [TestMethod()]
        public void ThreeBreaksTest()
        {
            string result = translator.ConvertLine("..-.||---||---||||||-...||.-||.-.");
            Assert.AreEqual("foo  bar", result);
        }

        [TestMethod()]
        public void InvalidBreakTest()
        {
            string result = translator.ConvertLine("..|.-|-.||.-");
            Assert.AreEqual("*a", result);
        }

        [TestMethod()]
        public void NumberAndCharTest()
        {
            string result = translator.ConvertLine("..||-.||||-....||...--");
            Assert.AreEqual("in 63", result);
        }

        [TestMethod()]
        public void NumberAndCharAndInvalidTest()
        {
            string result = translator.ConvertLine("..||n||||-....||...--");
            Assert.AreEqual("i* 63", result);
        }

        [TestMethod()]
        public void EmptyFileTest()
        {
            CreateFileForTesting("empty.txt", "");
            IList<string> result = translator.ConvertFile("empty.txt");
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
                + ".-..||---||.-.||.||--||||..||.--.||...||..-||--||||-..||---||.-..||---||.-.||||...||..||-||||.-||--||.||-");
            List<string> result = (List<string>)translator.ConvertFile("test.txt");
            DeleteFileForTesting("test.txt");
            CollectionAssert.AreEqual(new List<string> { "dog", "hello world", "this is a test string", "lorem ipsum dolor sit amet" }, result);
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