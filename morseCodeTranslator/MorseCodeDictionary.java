package morseCodeTranslator;

import java.util.Map;
import java.util.HashMap;

/**
 * Class representing a dictionary of morse code
 * strings to character translations.
 */
final class MorseCodeDictionary {

    /*
     * Members
     */

    // mapping of morse code strings to their translated characters
    // static so that we only create one instance of this
    private static final Map<String, Character> morseCodeMap = new HashMap<>();

    // initialize the morseCodeMap
    static {
        // ordered array of morse code strings
        String[] morseCodeStrings = new String[] {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..",
            ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.",
            "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----",
            ".----", "..---", "...--", "....-", ".....", "-....", "--...",
            "---..", "----.", ".-.-.-", "--..--", "..--..", "-...-"
        };
        // ordered array of morse code translation characters
        char[] morseCodeChars = new char[] {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ',', '?', '='
        };

        // arrays are ordered such that:
        //  morseCodeStrings[i] translates to morseCodeChars[i]

        for (int i=0; i < morseCodeStrings.length; i++) {
            morseCodeMap.put(morseCodeStrings[i], morseCodeChars[i]);
        }
    }

    // This class is meant to expose a static function, so the
    // user only needs one instance of this class.
    // Therefore the constructor private.
    private MorseCodeDictionary() {

    }

    /*
     * Public Functions 
     */

    /**
     * Returns character translation of the given morse code letter.
     * @param morseCodeInput string containing a morse code letter
     * @return translated char
     * @throws InvalidMorseCodeInputException if given an invalid morse code 
     *         string as parameter
     */
    public static char getCharacter(String morseCodeInput) throws InvalidMorseCodeInputException {
        Character msCharacter = morseCodeMap.get(morseCodeInput);
        
        // msCharacter will be null if we're given invalid input (input not in the morse code map)
        if (msCharacter == null)
            throw new InvalidMorseCodeInputException("Invalid morse code input: " + morseCodeInput);
        
        return msCharacter;
    }
}