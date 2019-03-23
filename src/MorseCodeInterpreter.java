import token.Token;

import java.util.List;

public class MorseCodeInterpreter {

    static class MorseCodeRuntimeException extends Exception {
        MorseCodeRuntimeException(String message) {
            super(message);
        }
    }

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

    public static void main(String[] args) {
        System.out.println(MorseCodeInterpreter.interpret("test/fle"));
    }

}
