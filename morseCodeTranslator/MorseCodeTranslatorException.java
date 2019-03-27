package morseCodeTranslator;

// Using custom exceptions here to give user of MorseCodeTranslator useful
// exceptions that indicate any specific issues that occur during translation.

/**
 * Exception representing any exception specific to the MorseCodeTranslator
 */
public abstract class MorseCodeTranslatorException extends Exception {

    public MorseCodeTranslatorException() {
        super();
    }

    public MorseCodeTranslatorException(String message) {
        super(message);
    }
    
    public MorseCodeTranslatorException(String message, Throwable cause) {
        super(message, cause);
    }

    public MorseCodeTranslatorException(Throwable cause) {
        super(cause);
    }
}