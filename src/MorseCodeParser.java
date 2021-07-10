import token.*;

import java.util.LinkedList;
import java.util.List;

/**
 * @author Mark Nash
 *
 * Builds the string based on the tokens that have been read in
 */
public class MorseCodeParser {

    /** The tokens that have been read in. */
    private LinkedList<Token> tokenList;

    /**
     * Each index is a state and the data is the character that that state
     * corresponds to.
     */
    private static final char[] STATES_TO_CHARS = { '\0', 'e', 't', 'i', 'a',
            'n', 'm', 's', 'u', 'r', 'w', 'd', 'k', 'g', 'o', 'h', 'v', 'f',
            '\0', 'l', '\0', 'p', 'j', 'b', 'x', 'c', 'y', 'z', 'q', '\0' };

    /** Store the token list. */
    public MorseCodeParser(List<Token> tokenList) {
        this.tokenList = (LinkedList<Token>)tokenList;
    }

    /**
     * Create meaning out of the list of tokens
     * @return The string that the list of tokens translates to
     */
    public String parse() {
        StringBuilder result = new StringBuilder();
        for (Token token : tokenList) {
            if (token instanceof CharToken) {
                result.append(decodeCharacter(token.getValue()));
            }
            else if (token instanceof SpaceToken) {
                result.append(token.getValue());
            }
            else if (token instanceof NewLineToken) {
                result.append(token.getValue());
            }
            else {
                // This is a CharSeparatorToken. The tokenizer has already
                // separated the characters, so nothing needs to be done
                // with this
            }
        }
        return result.toString();
    }

    /**
     * Determine the character from running a DFA state machine.
     * An example of one can be found here:
     * http://sound.whsites.net/articles/morse-f5.gif
     * Each state is numbered starting from 0 going
     * top to bottom, right to left.
     *
     * @param tokenValue A string of '.' and or '-'
     * @return an ascii character that the Morse Code string corresponds to
     */
    private char decodeCharacter(String tokenValue) {
        int currState = 0;
        for (char c : tokenValue.toCharArray()) {
            switch (c) {
                case '.':
                    currState = currState * 2 + 1;
                    break;
                case '-':
                    currState = (currState + 1) * 2;
                    break;
                default:
                    // this has already been dealt with during tokenizing
            }
        }
        if (currState > 29) {
            currState = 29;
        }
        char parsedChar = STATES_TO_CHARS[currState];

        if (parsedChar == '\0') {
            throw new MorseCodeInterpreter.MorseCodeRuntimeException(
                    "Illegal character: '" + tokenValue + "'");
        }
        return parsedChar;
    }
}
