package morseCodeTranslator;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;

/**
 * Class for outputting morse code translations to file.
 */
class MorseCodeOutput {

    /*
     * Members
     */
    private BufferedWriter fileWriter;

    /*
     * Public Functions 
     */

    /**
     * MorseCodeOutput constructor.
     * @param outputFileName name of file to output to
     * @throws OutputFileIOException if an IOException occurs while
     *         trying to create the output file
     */
    public MorseCodeOutput(String outputFileName) throws OutputFileIOException {
        // initialize the file writer
        try {
            this.fileWriter = new BufferedWriter(new FileWriter(outputFileName));
        }
        catch (IOException e) {
            throw new OutputFileIOException("IOException occurred when initializing the output file", e);
        }
    }

    /**
     * Outputs a given character to file.
     * @param outputChar character to output
     * @throws OutputFileIOException if an IOException occurs
     *         while writing to the output file 
     */
    public void outputCharacter(char outputChar) throws OutputFileIOException {
        String outCharacter = Character.toString(outputChar);
        try {
            this.fileWriter.write(outCharacter);
        }
        catch(IOException e) {
            throw new OutputFileIOException("IOException occurred when writing to the output file", e);
        }
    }

    /**
     * Call this function to finish writing to the output file.
     * @throws OutputFileIOException if an IOException occurs
     *         when trying to close the output file 
     */
    public void finishWriting() throws OutputFileIOException {
        // close the fileWriter
        try {
            this.fileWriter.close();
        }
        catch (IOException e) {
            throw new OutputFileIOException("IOException occurred when closing the output file", e);
        }
    }

}