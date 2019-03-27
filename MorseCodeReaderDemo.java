import java.io.IOException;

import morseCodeTranslator.*;

public class MorseCodeReaderDemo {
    public static void main(String[] args) {
        try {
            MorseCodeTranslator.translateFile("sampleFile1.txt", "sampleOut1.txt");
        }
        catch (MorseCodeTranslatorException e) {
            System.out.println(e);
        }
    }
}