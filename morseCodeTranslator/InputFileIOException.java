package morseCodeTranslator;

/**
 * Exception raised when an IOException occurs while reading a morse
 * code input file.
 */
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