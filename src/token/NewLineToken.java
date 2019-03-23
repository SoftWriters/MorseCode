package token;

public class NewLineToken extends Token {

    public String getValue() {
        return "\n";
    }

    @Override
    public String toString() {
        return "NEW_LINE";
    }

}
