using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MorseCode.MorseCode
{
    public class MorseCodeFile
    {
        public Boolean Save(string code)
        {
            try
            {
                string morseCode = ConvertToMorseCode(code);
                File.WriteAllText("./Upload/MorseCode.json", morseCode);
                return true;
            }
            catch (Exception ex)
            {
                //Some point log execption
                Console.Write(ex.InnerException);
                return false;
            }

        }

        public Boolean Load(IFormFile file)
        {
            return true;
        }

        public string ConvertToPlainText(StreamReader reader)
        {

            //Append each ling for return
            StringBuilder resultBuilder = new StringBuilder();
            var alphabet = new MorseCodeModel().MorseCodeAlphabet;

            string[] currentString = reader.ReadLine().Split(new string[] { "||" }, StringSplitOptions.None);

            while (currentString != null)
            {
       
                foreach (string code in currentString)
                {

                    try
                    {
                        MorseCodeLetter pair = (from c in alphabet
                                                where c.Code == code
                                                select c).First();

                            resultBuilder.Append(pair.Letter);
                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }

                resultBuilder.Append(Environment.NewLine);


                if (!reader.EndOfStream)
                {//read the next line
                    currentString = reader.ReadLine().Split(new string[] { "||" }, StringSplitOptions.None);
                }
                else
                {
                    currentString = null;
                }
      
            }


            return resultBuilder.ToString();

        }


        private string ConvertToMorseCode(string plainText)
        {

            StringBuilder resultBuilder = new StringBuilder();
            var alphabet = new MorseCodeModel().MorseCodeAlphabet;

            //Morse code file is limit to lower case alphas
            foreach (Char v in plainText.ToLower().ToCharArray())
            {
                try
                {
                    MorseCodeLetter pair = (from c in alphabet
                                            where c.Letter == v.ToString()
                                            select c).First();

                    if (v.ToString() == "\r")
                    {
                        resultBuilder.Append(Environment.NewLine);
                    }
                    else
                    {
                        if (pair != null)
                        {
                            resultBuilder.Append(pair.Code);
                            resultBuilder.Append(@"||");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }

            return resultBuilder.ToString();

        }


    }
}
