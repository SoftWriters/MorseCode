import java.io.*;

public class MorseCodeInterpreter {

    private static final class IllegalMorseCodeCharacterException extends Exception {
        public IllegalMorseCodeCharacterException() {
            super("Only 4 characters are excepted: '.', '-', '|', and '\\n'");
        }
    }

    private static final char[] STATES_TO_CHARS = { '\0', 'e', 't', 'i', 'a', 'n', 'm',
            's', 'u', 'r', 'w', 'd', 'k', 'g', 'o', 'h', 'v', 'f', '\0', 'l',
            '\0', 'p', 'j', 'b', 'x', 'c', 'y', 'z', 'q', '\0' };

    private static final int[][] TRANSITIONS = {
            {1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29}, // .
            {2, 4, 6, 8, 10, 12, 14, 16, 29, 29, 22, 24, 26, 28, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29}, // -
    };

    public static String interpret(String path) throws Exception {
        if (path == null) {
            throw new IllegalArgumentException(
                    "Morse Code file path cannot be null.");
        }
        StringBuilder returnString = new StringBuilder();
        String currLine;
        BufferedReader fileReader = new BufferedReader((new FileReader(path)));
        while ((currLine = fileReader.readLine()) != null) {
            int currState = 0;
            boolean readOnePipe = false;
            for (char c : currLine.toCharArray()) {
                switch (c) {
                    case '.':
                        currState = TRANSITIONS[0][currState];
                        break;
                    case '-':
                        currState = TRANSITIONS[1][currState];
                        break;
                    case '|':
                        if (readOnePipe) {
                            if (currState == 0) {
                                returnString.append(' ');
                            } else {
                                returnString.append(STATES_TO_CHARS[currState]);
                                currState = 0;
                            }
                            readOnePipe = false;
                        } else {
                            readOnePipe = true;
                        }
                        break;
                    default:
                        throw new IllegalMorseCodeCharacterException();
                }
            }
            returnString.append('\n');
        }
        return returnString.substring(0, returnString.length() - 1);
    }

    public static void main(String[] args) throws Exception{
        System.out.println(MorseCodeInterpreter.interpret("test/fle"));
    }

}
