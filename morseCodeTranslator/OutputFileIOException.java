package morseCodeTranslator;

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