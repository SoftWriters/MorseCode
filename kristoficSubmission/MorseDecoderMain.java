import java.io.*;

/* Main driver class, should be compiled using javac MorseDecoderMain.java on the command line
 * Then run using java MorseDecoderMain [filename]
 */
public class MorseDecoderMain {
    public static void main(String[] args) throws IOException {

        /* Checks to see if there are too many arguments */
        if (args.length > 1) {System.out.println("There are too many arguments"); return;}
        /* Instantiates FileVerification object and checks to see if command line file is a valid format */
        FileVerification fileVerifier = new FileVerification();
        if(!fileVerifier.isValid(args[0])){ System.out.println(args[0] + " is not an accepted file format. Please use .txt"); return; }

        /* Instantiates Decoder object and parses file line by line to get morse phrases */
        Decoder decoder = new Decoder();
        File file = new File(args[0]);
        BufferedReader br = new BufferedReader(new FileReader(file));
        String st;
        while((st = br.readLine()) != null){ decoder.decodeText(st);}
    }
}
