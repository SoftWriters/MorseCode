import token.*;

import java.io.*;
import java.util.LinkedList;
import java.util.List;

/**
 * @author Mark Nash
 *
 * Creates tokens for the whole file. The tokens are:
 * || -> a character seperator
 * |||| -> a space
 * '\n' -> a newline
 * '[.-]+' -> a character
 *
 * The four legal characters that can show up in a file are:
 * '.', '-', '|', '\n'
 */
public class MorseCodeTokenizer {

    /** The file reader. */
    private BufferedReader reader;

    /** An illegal character has been found while reading the file. */
    private static class IllegalMorseCodeCharacterException extends Exception {
        public IllegalMorseCodeCharacterException(char offendingCharacter) {
            super("'" + offendingCharacter + "' " + "(" +
                    (int)offendingCharacter + ") is not a valid character. " +
                    "Only 4 characters are excepted: '.', '-', '|', and '\\n'");
        }
    }

    /**
     * Opens the file and creates a reader object
     * @param filePath The path of the file to open
     * @throws FileNotFoundException if the file does not exist.
     */
    public MorseCodeTokenizer(String filePath) throws FileNotFoundException {
        reader = new BufferedReader(new FileReader(filePath));
    }

    /**
     * Reads the characters in the file and creates tokens out of them.
     * @return A List of tokens from the reading of the file
     * @throws MorseCodeInterpreter.MorseCodeRuntimeException A '|' character
     *      was read without another '|' with it
     * @throws IllegalMorseCodeCharacterException An unaccepted character of the
     *      four characters was read
     * @throws IOException Error closing the file or reading a line
     */
    public List<Token> tokenize() throws
            MorseCodeInterpreter.MorseCodeRuntimeException,
            IllegalMorseCodeCharacterException,
            IOException {

        LinkedList<Token> tokenList = new LinkedList<>();
        StringBuilder currChar = new StringBuilder();
        String line;
        while ((line = reader.readLine()) != null) {
            char[] charsOfLine = line.toCharArray();
            for (int i = 0; i < charsOfLine.length; i++) {
                char c = charsOfLine[i];
                switch (c) {
                    case '.':
                    case '-':
                        currChar.append(c);
                        break;
                    case '|':
                        if (i++ == charsOfLine.length ||
                                charsOfLine[i] != '|') {
                            throw new MorseCodeInterpreter.
                                    MorseCodeRuntimeException(
                                    "'|' is not a valid token");
                        }
                        if (tokenList.size() > 0 && currChar.length() == 0 &&
                                tokenList.getLast()
                                instanceof CharSeparatorToken) {
                            tokenList.removeLast();
                            tokenList.add(new SpaceToken());
                        } else {
                            tokenList.add(new CharToken(currChar.toString()));
                            currChar = new StringBuilder();
                            tokenList.add(new CharSeparatorToken());
                        }
                        break;
                    default:
                        throw new IllegalMorseCodeCharacterException(c);
                }
            }
            if (currChar.length() != 0) {
                tokenList.add(new CharToken(currChar.toString()));
                currChar = new StringBuilder();
            }
            tokenList.add(new NewLineToken());
        }

        tokenList.removeLast(); // the guaranteed extraneous newline

        reader.close();
        return tokenList;
    }
}
