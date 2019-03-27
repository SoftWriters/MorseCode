package morseCodeTranslator;

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