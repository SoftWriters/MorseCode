using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MorseCode;

/* Justin Onofrey  
 * SoftWriters Application
 * 11/6/2015 
 */

namespace MorseCode.Test
{
    /// <summary>
    /// Summary description for MorseCode
    /// </summary>
    [TestClass]
    public class MorseCodeTest
    {
        public MorseCodeTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        // This is our unit test for testing our method.
        [TestMethod]
        public void TestMorseCode()
        {
            MorseCode MorseCode = new MorseCode();
            string sourceFile = "C:/Temp/SoftWriters/MorseInput.txt";
            string outputFile = "C:/Temp/SoftWriters/MorseOutput.txt";

            string result = MorseCode.TranslateMorseCodeFile(sourceFile, outputFile);
            Console.WriteLine(result);
        }
    }
}
