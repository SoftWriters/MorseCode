namespace MorseCodeLibrary {

    public interface ITranslator {

        /// <summary>
        /// Translates a file with the object's method of translation.
        /// </summary>
        /// <param name="inputFilePath">The file to translate</param>
        /// <returns>A string containing the translation</returns>
        string Translate(string inputFilePath);

        /// <summary>
        /// Translates a string with the object's method of translation.
        /// </summary>
        /// <param name="line">The line to translate</param>
        /// <returns>The translated line</returns>
        string TranslateLine(string line);
    }
}
