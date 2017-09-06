using System;
using System.IO;
using System.Collections.Generic;

namespace MorseCodeClass
{
    /// <summary>
    /// Will open and convert a file from either plain text or Morse Code to a string
    /// </summary>
    public class MorseCodeFileConverter : MorseCodeConverter
    {

        /// <summary>
        /// Open a file, read it and interpret its contents as Morse Code (dots, dashes, breaks)
        /// </summary>
        /// <param name="FileName">Fully qualified path of file to open</param>
        /// <returns>Morse Code file contents converted to plain text</returns>
        public string MorseCodeFile_ToText(string FileName)
        {
            
        
           if (!File.Exists(FileName)) throw new Exception("File does not exist:" + FileName);

             try
             {

                 using (StreamReader reader = File.OpenText(FileName))
                 {
                     string MorseCodeFile = reader.ReadToEnd();

                     return MorseCode_ToText(MorseCodeFile); // Using will ensure file is closed
                 }

             }

             catch (Exception Ex) // Always capture exceptions when doing file I/O.  Lots can go wrong.
             {
                // Capture filename we had an issue with and throw to client
                throw new Exception("Could not read file: " + FileName, Ex);
             }
             
        }

        public string TextFile_ToMorseCode(String FileName)
        {

            if (!File.Exists(FileName)) throw new Exception("File does not exist:" + FileName);

            try
            {

                using (StreamReader reader = File.OpenText(FileName))
                {
                    string PlainTextFile = reader.ReadToEnd();

                    return Text_ToMorseCode (PlainTextFile); // Using will ensure file is closed
                }

            }

            catch (Exception Ex) // Always capture exceptions when doing file I/O.  Lots can go wrong.
            {
                // Capture filename we had an issue with and throw to client
                throw new Exception("Could not read file: " + FileName, Ex);
            }
        }
    }
}
