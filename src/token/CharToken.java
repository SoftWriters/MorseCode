package token;

public class CharToken extends Token {

    private String value;

    public CharToken(String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }

}
