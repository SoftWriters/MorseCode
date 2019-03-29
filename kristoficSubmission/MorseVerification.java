// Main class that parses morse text to look for invalid characters
public class MorseVerification {
    /* Constructor */
    MorseVerification() {}

    /* Goes through morse string to look for invalid characters
     * if an invalid character is detected returns false
     * if no invalid character is detected, returns true
     */
    protected boolean isValid(String text){
        for (int i = 0; i < text.length(); i++) {
            if (text.isEmpty()) { return false; }
            if(!((text.charAt(i) == '|') || (text.charAt(i) == '.') || (text.charAt(i) == '-'))) { return false; }
            if(text.charAt(i) == '|' && i == 0) { return false; }
            if(text.charAt(i) == '|' && i == (text.length() - 1)) { return false; }
            if(i < text.length() - 1) {
                if (text.charAt(i) == '|') {
                    if(text.charAt(i - 1) == '|') {}
                    else if (text.charAt( i + 1) == '|') {}
                    else { return false; }
                }
            }
        }
        return true;
    }
}
