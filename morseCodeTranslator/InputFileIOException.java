package morseCodeTranslator;

public class InputFileIOException extends MorseCodeTranslatorException {
   
    public InputFileIOException() {
        super();
    }

    public InputFileIOException(String message) {
        super(message);
    }
    
    public InputFileIOException(String message, Throwable cause) {
        super(message, cause);
    }

    public InputFileIOException(Throwable cause) {
        super(cause);
    }

}