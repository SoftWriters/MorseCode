package token;

/**
 * @author Mark Nash
 *
 * A token that represents a space between characters.
 */
public class SpaceToken implements Token {

    @Override
    public String getValue() {
        return " ";
    }

    @Override
    public String toString() {
        return "SPACE";
    }

}
