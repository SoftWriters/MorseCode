package token;

/**
 * @author Mark Nash
 *
 * A sort of token that has a semantic meaning. The data in an instance of one
 * of these tokens is the meaning, and the name is the token type.
 */
public interface Token {

    String getValue();
}
