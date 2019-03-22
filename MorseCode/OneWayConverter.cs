using System.Collections.Generic;

namespace MorseCode
{
    /// <summary>
    /// A one way converter from one character set to another
    /// </summary>
    interface IOneWayConverter
    {
        /// <summary>
        /// Converts a file to a list of strings in the new
        /// set of chars, each string in the list is a line of the file
        /// </summary>
        /// <param name="file">the file path of the file</param>
        /// <returns>A list of strings representing the lines of the file after conversion</returns>
        IList<string> ConvertFile(string file);

        /// <summary>
        /// Converts a line to a string in the new set of chars
        /// </summary>
        /// <param name="line">the line to be converted</param>
        /// <returns>a new string with the conversion completed</returns>
        string ConvertLine(string line);
    }
}
