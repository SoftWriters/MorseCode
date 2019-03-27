package morseCodeTranslator;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Arrays;

public class MorseCodeTranslator {

    /*
     * Members
     */
    private static MorseCodeDictionary morseCodeDictionary;

    private MorseCodeTranslator() {
        
    }

    /*
     * Public Functions
     */

    /**
     * Translates file containing morse code and writes the results to
     * an output file.
     * @param inputFileName name of input file containing morse code
     * @param outputFileName intended name of output file for translation
     * @throws MorseCodeTranslatorException if any exception related to
     *         file input, file output, or morse code to character translation
     *         occurs. Specific exception inherited from MorseCodeTranslatorException
     *         will be thrown. 
     */
    public static void translateFile(String inputFileName, String outputFileName) throws MorseCodeTranslatorException {

        MorseCodeInput morseCodeInput;
        MorseCodeOutput morseCodeOutput;
        String[] morseCodeCharacters;

        try {
            // initialize input and output, get array of morse code characters
            morseCodeInput = new MorseCodeInput(inputFileName);
            morseCodeOutput = new MorseCodeOutput(outputFileName);
            morseCodeCharacters = morseCodeInput.getMorseCodeCharacters();

            // translate morse code character strings into characters and output them
            for (int i=0; i < morseCodeCharacters.length; i++) {
                String msCharacter = morseCodeCharacters[i];

                // empty string indicates a space
                if (msCharacter.length() == 0) {
                    morseCodeOutput.outputCharacter(' ');
                }
                // string "\n" indicates a newline
                else if (msCharacter.length() == 1 && (char)msCharacter.charAt(0) == '\n') {
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
            throw e;
        }
    }
}