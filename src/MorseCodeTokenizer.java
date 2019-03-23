import token.*;

import java.io.*;
import java.util.LinkedList;
import java.util.List;
import java.util.NoSuchElementException;

public class MorseCodeTokenizer {

    private Reader reader;

    private static class IllegalMorseCodeCharacterException extends Exception {
        public IllegalMorseCodeCharacterException(char offendingCharacter) {
            super(offendingCharacter + '(' +
                    String.format("%04x", (int) offendingCharacter) + ')' +
                    " is not a valid character. Only 4 characters are " +
                    "excepted: '.', '-', '|', and '\\n'");
        }
    }

    public MorseCodeTokenizer(String filePath) {
        try {
            reader = new BufferedReader(new InputStreamReader(
                    new FileInputStream(filePath)));

        }
        catch (FileNotFoundException fnfe) {
            fnfe.printStackTrace();
        }
    }

    public List<Token> tokenize() {
        char c;
        int charInt;
        LinkedList<Token> tokenList = new LinkedList<>();
        StringBuilder currChar = new StringBuilder();
        boolean lastCharWasPipe = false;
        try {
            while ((charInt = reader.read()) != -1) {
                c = (char)charInt;
                System.out.println(c + "'" + currChar.toString() + "'" + tokenList);
                switch (c) {
                    case '.':
                    case '-':
                        currChar.append(c);
                        break;
                    case '|':
                        if (lastCharWasPipe) {
                            Token lastToken = tokenList.getLast(); // peak
                            if (lastToken instanceof CharSeperatorToken) {
                                tokenList.removeLast();
                                tokenList.add(new SpaceToken());
                            }
                            else {
                                tokenList.add(new CharSeperatorToken());
                            }
                            lastCharWasPipe = false;
                        }
                        else {
                            tokenList.add(new CharToken(currChar.toString()));
                            currChar = new StringBuilder();
                            lastCharWasPipe = true;
                        }
                        break;
                    case '\n':
                        if (currChar.length() != 0) {
                            tokenList.add(new CharToken(currChar.toString()));
                            currChar = new StringBuilder();
                        }
                        tokenList.add(new NewLineToken());
                        break;
                    default:
                        throw new IllegalMorseCodeCharacterException(c);
                }
            }
            tokenList.add(new CharToken(currChar.toString()));
        }
        catch (NoSuchElementException nse) {
            new MorseCodeInterpreter.MorseCodeRuntimeException(
                    "Line cannot start with '||'").printStackTrace();
        }
        catch (Exception e) {
            e.printStackTrace();
        }

        return tokenList;
    }
}
