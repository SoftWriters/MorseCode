package token;

/**
 * @author Mark Nash
 *
 * Holds a string of '.' and/or '-'.
 */
public class CharToken implements Token {

    private String value;

    public CharToken(String value) {
        this.value = value;
    }

    @Override
    public String getValue() {
        return value;
    }

    @Override
    public String toString() {
        return "'" + value + "'";
    }

}
