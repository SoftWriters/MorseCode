package morseCodeTranslator;

public class InputFileNotFoundException extends MorseCodeTranslatorException {
   
    public InputFileNotFoundException() {
        super();
    }

    public InputFileNotFoundException(String message) {
        super(message);
    }
    
    public InputFileNotFoundException(String message, Throwable cause) {
        super(message, cause);
    }

    public InputFileNotFoundException(Throwable cause) {
        super(cause);
    }

}