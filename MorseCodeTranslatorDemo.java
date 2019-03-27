import morseCodeTranslator.*;
import java.io.IOException;
import java.util.Scanner;
import java.io.File;
import java.io.FileNotFoundException;

/**
 * Demo to demonstrate use of MorseCodeTranslator package.
 * Compile and run this file to see the translator in action.
 */
public class MorseCodeTranslatorDemo {
    public static void main(String[] args) {

        File outputDir; // output file directory

        // run valid input files
        try {
            // make output directory
            outputDir = new File("output");
            if (outputDir.exists() || outputDir.mkdir()) {
                // translate sample files (no exceptions should be thrown)
                MorseCodeTranslator.translateFile("input_files/sampleFile1.morsecode", "output/sampleOut1.translation");
                MorseCodeTranslator.translateFile("input_files/sampleFile2.morsecode", "output/sampleOut2.translation");
                MorseCodeTranslator.translateFile("input_files/emptyFile.morsecode", "output/emptyOutput.translation");
                MorseCodeTranslator.translateFile("input_files/allWhiteSpace.morsecode", "output/allWhiteSpace.translation");
            
                // print output files to console
                for (File file : outputDir.listFiles()) {
                    Scanner fileScanner = new Scanner(file);
                    System.out.println("\n" + file.getName() + ":");
                    while (fileScanner.hasNextLine()) {
                        System.out.println(fileScanner.nextLine());
                    }
                    fileScanner.close();
                }
            }
            else {
                System.out.println("Cannot create output directory");
            }
        }
        catch (MorseCodeTranslatorException | FileNotFoundException e) {
            e.printStackTrace();
        }

        // run invalid input files
        translateInvalidFile("input_files/nonExistentFile.morsecode", "output/shouldNotExist.translation");
        translateInvalidFile("input_files/invalidInput.morsecode", "output/invalid1.translation");
        translateInvalidFile("input_files/invalidInput2.morsecode", "output/invalid2.translation");
        translateInvalidFile("input_files/invalidInput3.morsecode", "output/invalid3.translation");
    }

    /**
     * Runs MorseCodeTranslator.translateFile() on an input file that's intended to be
     * invalid and prints exception.
     */
    private static void translateInvalidFile(String inputFileName, String outputFileName) {
        try {
            MorseCodeTranslator.translateFile(inputFileName, outputFileName);
        }
        catch (MorseCodeTranslatorException e) {
            System.out.println("\nSuccessfully caught exception:");
            System.out.println(e);
        }
    }
}