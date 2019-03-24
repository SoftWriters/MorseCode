package token;

/**
 * @author Mark Nash
 *
 * A newline token.
 */
public class NewLineToken implements Token {

    @Override
    public String getValue() {
        return "\n";
    }

    @Override
    public String toString() {
        return "NEW_LINE";
    }

}
