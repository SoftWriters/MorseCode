import token.*;

import java.io.*;
import java.util.LinkedList;
import java.util.List;
import java.util.NoSuchElementException;

public class MorseCodeTokenizer {

    private BufferedReader reader;

    private static class IllegalMorseCodeCharacterException extends Exception {
        public IllegalMorseCodeCharacterException(char offendingCharacter) {
            super("'" + offendingCharacter + "' " + "(" +
                    (int)offendingCharacter + ") is not a valid character. " +
                    "Only 4 characters are excepted: '.', '-', '|', and '\\n'");
        }
    }

    public MorseCodeTokenizer(String filePath) throws FileNotFoundException {
        reader = new BufferedReader(new FileReader(filePath));
    }

    public List<Token> tokenize() throws
            NoSuchElementException,
            MorseCodeInterpreter.MorseCodeRuntimeException,
            IllegalMorseCodeCharacterException,
            IOException {

        LinkedList<Token> tokenList = new LinkedList<>();
        StringBuilder currChar = new StringBuilder();
        boolean lastCharWasPipe = false;
        String line;
        while ((line = reader.readLine()) != null) {
            for (char c : line.toCharArray()) {
                switch (c) {
                    case '.':
                    case '-':
                        currChar.append(c);
                        break;
                    case '|':
                        if (lastCharWasPipe) {
                            if (tokenList.size() == 0) {
                                throw new MorseCodeInterpreter.
                                        MorseCodeRuntimeException(
                                        "Line cannot start with '||'");
                            } else if (tokenList.getLast() instanceof
                                    CharSeperatorToken) {
                                tokenList.removeLast();
                                tokenList.add(new SpaceToken());
                            } else {
                                tokenList.add(new CharSeperatorToken());
                            }
                            lastCharWasPipe = false;
                        } else {
                            if (currChar.length() != 0) {
                                tokenList.add(new CharToken(
                                        currChar.toString()));
                                currChar = new StringBuilder();
                            }
                            lastCharWasPipe = true;
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

        if (tokenList.size() > 0 &&
                !(tokenList.getLast() instanceof NewLineToken)) {
            tokenList.add(new CharToken(currChar.toString()));
        }
        return tokenList;
    }
}
