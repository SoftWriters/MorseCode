import java.util.*;

// Main class for parsing and decoding morse text given in flat file
public class Decoder {
    /* Variable initializations for morse and english alphabet */
    private static final String A = ".-";
    private static final String B = "-...";
    private static final String C = "-.-.";
    private static final String D = "-..";
    private static final String E = ".";
    private static final String F = "..-.";
    private static final String G = "--.";
    private static final String H = "....";
    private static final String I = "..";
    private static final String J = ".---";
    private static final String K = "-.-";
    private static final String L = ".-..";
    private static final String M = "--";
    private static final String N = "-.";
    private static final String O = "---";
    private static final String P = ".--.";
    private static final String Q = "--.-";
    private static final String R = ".-.";
    private static final String S = "...";
    private static final String T = "-";
    private static final String U = "..-";
    private static final String V = "...-";
    private static final String W = ".--";
    private static final String X = "-..-";
    private static final String Y = "-.--";
    private static final String Z = "--..";
    private static final String ONE = ".----";
    private static final String TWO = "..---";
    private static final String THREE = "...--";
    private static final String FOUR = "....-";
    private static final String FIVE = ".....";
    private static final String SIX = "-....";
    private static final String SEVEN = "--...";
    private static final String EIGHT = "---..";
    private static final String NINE = "----.";
    private static final String ZERO = "-----";
    private static final String BREAK = "||";

    private static final String morseAlphabet[] = new String[] {A, B, C, D, E, F, G, H, I, J, K, L,
        M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, ONE, TWO, THREE, FOUR, FIVE, SIX,
        SEVEN, EIGHT, NINE, ZERO, BREAK};
    private static final StringBuilder englishAlphabet[] = new StringBuilder[] {
            new StringBuilder("a"), new StringBuilder("b"), new StringBuilder("c"),
            new StringBuilder("d"), new StringBuilder("e"), new StringBuilder("f"),
            new StringBuilder("g"), new StringBuilder("h"), new StringBuilder("i"),
            new StringBuilder("j"), new StringBuilder("k"), new StringBuilder("l"),
            new StringBuilder("m"), new StringBuilder("n"), new StringBuilder("o"),
            new StringBuilder("p"), new StringBuilder("q"), new StringBuilder("r"),
            new StringBuilder("s"), new StringBuilder("t"), new StringBuilder("u"),
            new StringBuilder("v"), new StringBuilder("w"), new StringBuilder("x"),
            new StringBuilder("y"), new StringBuilder("z"), new StringBuilder("1"),
            new StringBuilder("2"), new StringBuilder("3"), new StringBuilder("4"),
            new StringBuilder("5"), new StringBuilder("6"), new StringBuilder("7"),
            new StringBuilder("8"), new StringBuilder("9"), new StringBuilder("0"),
            new StringBuilder(" ")
    };

    private static final Map <String,StringBuilder> morseToEnglish = new HashMap<>();

    /* Constructor, initializes map for morse to english */
    public Decoder(){
        for(int i = 0; i < morseAlphabet.length; i++) { morseToEnglish.put(morseAlphabet[i], englishAlphabet[i]); }
    }

    /* Main method called by a Decoder object
     * Is given a String from a line in a flat file, determines if it is valid morse code,
     * Then calls other methods to decode and print english results
    */
    public void decodeText(String text){
        MorseVerification verifyInput = new MorseVerification();
        if(!verifyInput.isValid(text)){ System.out.println(text + " is not valid morse code"); return; }

        System.out.println(getEnglishText(getMorseCharacters(text)));
    }

    /* Goes through the String of morse code character by character,
     * determines when the end of a morse character has been reached, adds that character and a break character to
     * A list of StringBuilder objects
     * It returns that list once entire string as been parsed
     */
    private List<StringBuilder> getMorseCharacters(String text){
        List<StringBuilder> fullMorseText = new ArrayList<>();
        int characterCounter = 0;

        while(characterCounter < text.length()) {

            StringBuilder lastMorseCharacter = new StringBuilder();
            StringBuilder currentMorseLetter = new StringBuilder();
            String currentMorseCharacter = new String();
            while (!lastMorseCharacter.append(currentMorseCharacter).toString().equals(BREAK) && characterCounter < text.length()) {
                if(!currentMorseLetter.toString().equals("")){
                    lastMorseCharacter =
                        new StringBuilder(String.valueOf(currentMorseLetter.charAt(currentMorseLetter.length() - 1)));
                }
                currentMorseLetter.append(new StringBuilder(String.valueOf(text.charAt(characterCounter))));
                currentMorseCharacter = String.valueOf(text.charAt(characterCounter));
                characterCounter++;
            }

            if(!(characterCounter == text.length())){
                if(!currentMorseLetter.toString().equals(BREAK)) {
                    currentMorseLetter.delete(currentMorseLetter.length() - 2, currentMorseLetter.length());
                    fullMorseText.add(currentMorseLetter);
                }
                fullMorseText.add(new StringBuilder(BREAK));
            }
            else{ fullMorseText.add(currentMorseLetter); }
        }
        return fullMorseText;
    }

    /* Is given a List of StringBuilder objects that are individual morse code characters,
     * goes through and determines what break characters
     * should be removed and which should remain to be interpreted as spaces in phrases
     * then builds and returns that english String
     */
    private String getEnglishText(List<StringBuilder> morseText){
        StringBuilder englishText = new StringBuilder();
        StringBuilder previousChar, currentChar = new StringBuilder();

        for(int i = 0; i < morseText.size(); i++){
            previousChar = currentChar;
            currentChar = morseText.get(i);
            if(previousChar.toString().equals(BREAK) && currentChar.toString().equals(BREAK)){
                morseText.remove(i);
                currentChar = new StringBuilder();
            }
            else if (previousChar.toString().equals(BREAK) && !currentChar.toString().equals(BREAK)){
                morseText.remove(i - 1);
                i--;
            }
        }
        for (StringBuilder aMorseText : morseText) { englishText.append(getNextEnglishCharacter(aMorseText)); }
        return englishText.toString();
    }

    /* Method uses the morse character passed in to look up corresponding english character
     * In the morse to english map, and returns that english character
     */
    private StringBuilder getNextEnglishCharacter(StringBuilder morseCharacter){
       return morseToEnglish.get(morseCharacter.toString());
    }
}
