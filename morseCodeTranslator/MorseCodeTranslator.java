package morseCodeTranslator;

public class MorseCodeTranslator {

    /**
     * Members
     */
    private static MorseCodeDictionary morseCodeDictionary;

    private MorseCodeTranslator() {
        
    }

    /**
     * Translates file containing morse code and writes the results to
     * an output file.
     * @param inputFileName name of input file containing morse code
     * @param outputFileName intended name of output file for translation
     */
    public static void translateFile(String inputFileName, String outputFileName) {
        MorseCodeInput morseCodeInput = new MorseCodeInput(inputFileName);
        MorseCodeOutput morseCodeOutput = new MorseCodeOutput(outputFileName);
    }
}