package morseCodeTranslator;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Arrays;

// This is the only class that is exposed to the user of this package

/**
 * Translates morse code.
 */
public class MorseCodeTranslator {

    /*
     * Members
     */
    private static MorseCodeDictionary morseCodeDictionary;

    // This class is meant to expose a static function, so the
    // user only needs one instance of this class.
    // Therefore the constructor private.
    private MorseCodeTranslator() {
        
    }

    /*
     * Public Functions
     */

    /**
     * Translates file containing morse code and writes the results to
     * an output file.
     * @param inputFileName name of input file containing morse code
     * @param outputFileName intended name of output file
     * @throws MorseCodeTranslatorException if any exception related to
     *         file input, file output, or morse code to character translation
     *         occurs. Specific exception inherited from MorseCodeTranslatorException
     *         will be thrown. 
     */
    public static void translateFile(String inputFileName, String outputFileName) throws MorseCodeTranslatorException {

        MorseCodeInput morseCodeInput = null;
        MorseCodeOutput morseCodeOutput = null;
        String[] morseCodeCharacters;

        try {
            // initialize input and output, get array of morse code characters
            morseCodeInput = new MorseCodeInput(inputFileName);
            morseCodeCharacters = morseCodeInput.getMorseCodeCharacters();
            morseCodeOutput = new MorseCodeOutput(outputFileName);

            // translate morse code character strings into characters and output them
            for (int i = 0; i < morseCodeCharacters.length; i++) {
                String msCharacter = morseCodeCharacters[i];

                // empty string indicates a space
                if (msCharacter.length() == 0) {
                    morseCodeOutput.outputCharacter(' ');
                }
                // string "\n" indicates a newline
                else if (msCharacter.length() == 1 && (char)msCharacter.charAt(0) == '\n') {

                    if (i == morseCodeCharacters.length - 1) {
                        // suppress trailing newline at end of file
                        continue;
                    }

                    morseCodeOutput.outputCharacter('\n');
                }
                else {
                    // translate morse code string to character and output it
                    morseCodeOutput.outputCharacter(morseCodeDictionary.getCharacter(msCharacter.trim()));
                }
            }
            morseCodeOutput.finishWriting();
        }
        catch (MorseCodeTranslatorException e) {
            // throw any caught exceptions to the user
            throw e;
        }
    }
}