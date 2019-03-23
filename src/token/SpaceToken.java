package token;

public class SpaceToken extends Token {

    public String getValue() {
        return "||||";
    }

    @Override
    public String toString() {
        return "SPACE";
    }

}
