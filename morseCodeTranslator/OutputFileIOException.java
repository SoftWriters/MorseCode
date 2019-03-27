package morseCodeTranslator;

/**
 * Exception raised when an IOException occurs while writing to the
 * translation output file.
 */
public class OutputFileIOException extends MorseCodeTranslatorException {
   
    public OutputFileIOException() {
        super();
    }

    public OutputFileIOException(String message) {
        super(message);
    }
    
    public OutputFileIOException(String message, Throwable cause) {
        super(message, cause);
    }

    public OutputFileIOException(Throwable cause) {
        super(cause);
    }

}