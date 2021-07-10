package token;

/**
 * @author Mark Nash
 *
 * Separates characters in a Morse Code file.
 */
public class CharSeparatorToken implements Token {

    @Override
    public String getValue() {
        return "||";
    }

    @Override
    public String toString() {
        return "CHAR_SEPERATOR";
    }

}
