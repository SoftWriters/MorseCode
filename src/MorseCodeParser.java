import token.*;

import java.util.LinkedList;
import java.util.List;

public class MorseCodeParser {

    private LinkedList<Token> tokenList;

    private static final char[] STATES_TO_CHARS = { '\0', 'e', 't', 'i', 'a',
            'n', 'm', 's', 'u', 'r', 'w', 'd', 'k', 'g', 'o', 'h', 'v', 'f',
            '\0', 'l', '\0', 'p', 'j', 'b', 'x', 'c', 'y', 'z', 'q', '\0' };

    private static final int[][] TRANSITIONS = {
            {1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29}, // .
            {2, 4, 6, 8, 10, 12, 14, 16, 29, 29, 22, 24, 26, 28, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29}, // -
    };

    public MorseCodeParser(List<Token> tokenList) {
        this.tokenList = (LinkedList<Token>)tokenList;
    }

    public String parse() {
        StringBuilder result = new StringBuilder();
        for (Token token : tokenList) {
            if (token instanceof CharToken) {
                result.append(parseCharacter((CharToken)token));
            }
            else if (token instanceof SpaceToken) {
                result.append(' ');
            }
            else if (token instanceof NewLineToken) {
                result.append('\n');
            }
            else {
                // This is a CharSeperatorToken. The tokenizer has already
                // separated the characters, so nothing needs to be done
                // with this
            }
        }
        return result.toString();
    }

    private Character parseCharacter(CharToken token) {
        int currState = 0;
        for (char c : token.getValue().toCharArray()) {
            switch (c) {
                case '.':
                    currState = TRANSITIONS[0][currState];
                    break;
                case '-':
                    currState = TRANSITIONS[1][currState];
                    break;
                default:
                    // this has already been dealt with during tokenizing
            }
        }
        char parsedChar = STATES_TO_CHARS[currState];

        if (parsedChar == '\0') {
            new MorseCodeInterpreter.MorseCodeRuntimeException(
                    "Illegal character: '" + token.getValue() + "'"
            ).printStackTrace();
        }
        return parsedChar;
    }
}
