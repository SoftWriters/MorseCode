// Gabrielle Hemlick
// 25 March 2019

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.Writer;
import java.util.HashMap;
import java.util.Map;

/**
 * A MorseCode object uses I/O and a Map dictionary of encodings 
 * to translate an input file containing morse code into English text. 
 * It writes the decoded output to a specified output file.
 * 
 * The morse code symbols used are:
 * .
 * -
 * || this represents a break between output characters
 * |||| this represents a space between output words
 */

public class MorseCode {
    
    //used to increase efficiency. Needed for printLine() method.
    private BufferedReader reader;
    
    private Writer writer;
    
    //used to easily store and access the translation of each encoded character
    private Map<String, String> encodingDictionary = new HashMap<String, String>();
        
    
    
    /**
     * Constructs a MorseCode.
     * Uses a library of standard encodings containing
     * - English alphabet
     * - digits 1-9
     * - punctuation and special symbols
     * 
     * @param inFile The file of morse code
     * This file must only contain characters that are in standardEncodings.txt
     * @param outFile The file to which translated text code will be written
     */
    public MorseCode(String inFile, String outFile) throws IOException {
        reader = new BufferedReader(new FileReader(inFile));
        writer = new PrintWriter(outFile);
        makeEncodingDictionary("standardEncodings.txt");
        decodeText(inFile);
    }
    
    /**
     * Constructs a MorseCode.
     * Uses user-defined encodings.
     * 
     * @param inFile The file of morse code
     * This file must only contain characters that are in inputEncodings.
     * @param outFile The file to which translated text code will be written
     * @param inputEncodings The file of user-defined encodings. 
     * This must be in the following format in the text file:
     * code translation
     * code translation
     * code translation
     * ...
     */
    public MorseCode(String inFile, String outFile, String inputEncodings) throws IOException {
        reader = new BufferedReader(new FileReader(inFile));
        writer = new PrintWriter(outFile);
        makeEncodingDictionary(inputEncodings);
        decodeText(inFile);
    }
    
    /**
     * Reformats a file of encodings into a Map
     * that maps code to translation.
     * 
     * @param fileName The file of encodings
     * This must be in the following format in the text file:
     * code translation
     * code translation
     * code translation
     * ...
     */
    private void makeEncodingDictionary(String fileName) throws IOException {
        BufferedReader dictReader = new BufferedReader(new FileReader(fileName));
        
        try {
            while (dictReader.ready()) {
                //since there is a format to the dictionary, 
                // I split each line and add to the encodingLibrary Map
                String line = dictReader.readLine();
                String[] pairArray = line.split(" ");
                encodingDictionary.put(pairArray[0], pairArray[1]);
            }
        } catch (IOException e) {
            System.out.println("Document finished reading.");
        } finally {
            if (dictReader != null) {
                dictReader.close();
            }
        }
    }
    
    /**
     * Decodes a file of morse code.
     * 
     * NOTE: print statements are commented out, but they remain in the 
     * method in order to show the process of debugging.
     * 
     * @param fileName The file of morse code.
     * This file must only contain characters that are in encodingDictionary
     */
    private void decodeText(String fileName) throws IOException {
        
        try {
            char nextChar;
            
            //StringBuilder is used to increase String concatenation efficiency
            StringBuilder currentEncoding = new StringBuilder();
            
            //A boolean used to signal whether or not two || are the most
            //recent characters read in the file
            boolean readyForSpace = false;
            
            while (reader.ready()) {
                
                nextChar = (char) reader.read();
                
                if (nextChar == '\n') {
                    readyForSpace = false;
                    //System.out.println("(1)" + encodingDictionary.get(currentEncoding.toString()));
                    //System.out.println("(5)" + currentEncoding.toString());
                    if (encodingDictionary.get(currentEncoding.toString()) != null) {
                        writer.write(encodingDictionary.get(currentEncoding.toString()));
                    } 
                    writer.write('\n');
                    
                    //I clear the StringBuilder object instead of creating a new 
                    //empty StringBuilder object in order to conserve space on stack and heap
                    currentEncoding = currentEncoding.delete(0, currentEncoding.length());
                } else {
                    if (nextChar == '|') {
                        //I assume my file is formatted with pairs of || instead of singleton |
                        reader.read();
                        if (!readyForSpace) {
                            //I check for null to avoid writing 'null' to the output file
                            if (encodingDictionary.get(currentEncoding.toString()) != null) {
                                writer.write(encodingDictionary.get(currentEncoding.toString()));
                                currentEncoding = 
                                        currentEncoding.delete(0, currentEncoding.length());
                            }
                            readyForSpace = true;
                        } else {
                            writer.write(" ");
                            readyForSpace = false;
                        }
                    } else {
                        readyForSpace = false;
                        //System.out.println(nextChar);
                        currentEncoding.append(nextChar);
                        //System.out.println("(4)" + currentEncoding.toString());
                    }
                }
            }
            //when the document is finished reading, write any remaining
            //currentEncoding that was not written already
            writer.write(encodingDictionary.get(currentEncoding.toString()));
            
        } catch (IOException e) {
            System.out.println("Document unexpectedly stopped reading.");
            
        } finally {
            if (reader != null) {
                reader.close();
                writer.flush();
                writer.close();
            }
        }
    }
    
    
}














