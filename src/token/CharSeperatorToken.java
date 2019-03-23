package token;

public class CharSeperatorToken extends Token {

    public String getValue() {
        return "||";
    }

    @Override
    public String toString() {
        return "CHAR_SEPERATOR";
    }

}
