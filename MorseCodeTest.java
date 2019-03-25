import static org.junit.Assert.*;

import java.io.IOException;

import org.junit.Test;

public class MorseCodeTest {

    @Test
    public void testConstructorSampleInput() throws IOException {
        new MorseCode("sampleInput.txt", "decodedText.txt");
    }

}


/*
 * My series of inputs for "sampleInput.txt":
 * 
 * (1) .-
 * 
 * (2) .-||.-
 * 
 * (3) .-||.-
 *     .-
 * 
 * (4) .-||.-
 *     .-||
 *     
 * (5) .-||||.-
 * 
 * (6) .-||||.-
 *     .-||||
 * 
 * (7) -..||---||--.
 *     ....||.||.-..||.-..||---||||.--||---||.-.||.-..||-..
 * 
 */


