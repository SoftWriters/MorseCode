package morseCodeTranslator;

public class InvalidMorseCodeInputException extends MorseCodeTranslatorException {
   
    public InvalidMorseCodeInputException() {
        super();
    }

    public InvalidMorseCodeInputException(String message) {
        super(message);
    }
    
    public InvalidMorseCodeInputException(String message, Throwable cause) {
        super(message, cause);
    }

    public InvalidMorseCodeInputException(Throwable cause) {
        super(cause);
    }

}