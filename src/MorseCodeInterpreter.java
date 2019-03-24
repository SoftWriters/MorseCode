import token.Token;

import java.util.List;

/**
 * @author Mark Nash
 *
 * The entry point to Morse Code interpreter. Call "interpret" from anywhere
 * in your code.
 */
public class MorseCodeInterpreter {

    /**
     * A runtime exception that happened while tokenizing a string of
     * Morse Code. The message of the exception further specifies the issue.
     */
    static class MorseCodeRuntimeException extends RuntimeException {
        MorseCodeRuntimeException(String message) {
            super(message);
        }
    }

    /**
     * Reads the file, creates a list of tokens from the four token types,
     * parses those tokens into English
     * @param path A string of the file path to translate
     * @return The interpreted string, null is returned if the file contained
     *      incorrect input
     */
    public static String interpret(String path) {
        if (path == null) {
            throw new IllegalArgumentException(
                    "Morse Code file path cannot be null.");
        }
        List<Token> tokenList;
        try {
            tokenList = new MorseCodeTokenizer(path).tokenize();
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
        String interpretedString = new MorseCodeParser(tokenList).parse();
        return interpretedString;
    }

}
