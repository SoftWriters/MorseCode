// Main class for determining if file given on command line is of valid format
public class FileVerification {
    private final String ACCEPTED_FILE_FORMAT = ".txt";

    /* Constructor */
    FileVerification(){}
    /* Searches filename for valid extension
     * returns true if valid extension is found, false if it is not found
     */
    public boolean isValid(String commandLineArgument){ return commandLineArgument.toLowerCase().contains(ACCEPTED_FILE_FORMAT); }
}
