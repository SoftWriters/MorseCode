package morseCodeTranslator;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileNotFoundException;
import java.io.IOException;

/**
 * Class for reading a morse code input file.
 */
class MorseCodeInput {

    /*
     * Members
     */
    private BufferedReader fileReader;
    private static final String inputFileDelimiter = "\\|\\|";

    /*
     * Public functions 
     */

    /**
     * MorseCodeInput constructor.
     * @param inputFileName name of morse code input file
     * @throws InputFileNotFoundException if input morse code
     *         file is not found
     */
    public MorseCodeInput(String inputFileName) throws InputFileNotFoundException {
        // initialize the file reader
        try {
            this.fileReader = new BufferedReader(new FileReader(inputFileName));
        }
        catch (FileNotFoundException e) {
            throw new InputFileNotFoundException("Input file \""+inputFileName+"\" not found");
        }
    }

    /**
     * Gets all morse code characters in a file.
     * @return String array with all morse code characters.
     *         May contain '\n': this indicates a newline
     *         May contain empty strings: this indicates a space
     */
    public String[] getMorseCodeCharacters() throws InputFileIOException {
        // initialize array of morse code characters
        String[] morseCodeCharacters = new String[0];

        // parse the file
        try {
            // read in each line of input file
            String line = this.fileReader.readLine();
            while (line != null) {
                // split line into morse code character strings using delimiter
                String[] lineCharacters = line.split(this.inputFileDelimiter);
                morseCodeCharacters = this.concatArraysAndNewline(morseCodeCharacters, lineCharacters);
                line = this.fileReader.readLine();
            }

            this.fileReader.close();
        }
        catch (IOException e) {
            throw new InputFileIOException("IOException occurred with the input file", e);
        }

        return morseCodeCharacters;
    }

    /*
     * Helper functions
     */

    /**
     * Concatenates two string arrays + a newline and returns the resulting array.
     */
    private String[] concatArraysAndNewline(String[] array1, String[] array2) {
        int a1Length = array1.length;
        int a2Length = array2.length;
        String[] resultArray = new String[a1Length + a2Length + 1];

        // copy array1 and array2 into result array
        System.arraycopy(array1, 0, resultArray, 0, a1Length);
        System.arraycopy(array2, 0, resultArray, a1Length, a2Length);
        // newline
        resultArray[resultArray.length - 1] = "\n";

        return resultArray;
    }
}