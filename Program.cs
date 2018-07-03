using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MorseCodeTranslator
{
    /* 
     * Variables BELOW need to be updated below for this program to work in your environment
     */
    class MainClass
    {
        //Initialize core information used in this program
        //Log file to record program execution information
        /* 
         * UPDATE THIS VARIABLE TO LOG INFO
        */
        static string _logFile = @"/Users/tracymee/Documents/MorseCodeTranslator.log";
        /*
         */
        //File to obtain all directory and file information to use to obtain inputs and output results
        /* UPDATE THIS VARIABLE TO USE INIT FILE - (FUTURE)*/
        static string _initDictionaryFile = @"/Users/tracymee/init.txt";
        /* Logging information from INIT file */
        static bool _outputToConsole = false;
        static bool _verboseLogging = false;



        public static void Main(string[] args)
        {
            /*User input can be obtained multiple ways for the currently designed program
                1) Internally hard coding through string definitions 
                2) Console prompts for real-time user input
                3) Externally through file definition (for systems designed to operate independently wth no human interation
            Each Agile development iteration implemented additonal functionality obsoleting the old prototypes*/

            // 1) Internally hard coding through string definitions
            //Files to use
            //Initialize variables
            /* 
             * 
             * UPDATE THESE VARIABLES TO THE PATHS TO THE FILES YOU ARE USING
            */
            string _morseToTextDictionaryFile = @"/Users/tracymee/Documents/morsecode.txt";
            string _textToMorseDictionaryFile = @"/Users/tracymee/Documents/english.txt";
            string _morseFile = @"/Users/tracymee/morseToTranslate.txt";
            string _textFile = @"/Users/tracymee/englishin.txt";
            string _morseFileOutput = @"/Users/tracymee/morseText.txt";
            /*
             * UPDATE ^^^^^^^^^^^^ABOVE VARIABLES^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
             * 
             */
            //string _textFileOutput = @"/Users/tracymee/englishMorse.txt"; - for reverse translation to test (future)

            // 2) Console prompts for real-time user input
            //UserInputFilePath();

            // 3) Externally through file definition (for systems designed to operate independently wth no human interation
            //GetInitFile();
            //LoadInitFile();

            //Log file & Console communication methods to use throughout program
            WriteToLogFile($"This is the log file for the Morse Code Translator: {_logFile}", false);
            WriteToConsole("Morse Code Translator console communication!");
            WriteVerboseToLogFile("Verbose logging has been enabled via the _verboseLogging variable to help with debugging.", true);

            //CHECK mapping file date to see if changes are made requiring a re-import of the file
            //CREATE a check-file method and call each loop (Load Map procedure call)
            //Initialization parameters
            //NOTE: This code is not currently implemented (future planning)
            //bool _isMapLoaded = false;
            //bool _doesMapFileExist = false;

            //code to ensure translation file exists
            //NOTE: This code is not currently implemented (future planning)    
            try
            {
                WriteVerboseToLogFile($"Loop to load morseToTextDictionaryFile {_morseToTextDictionaryFile}.", true);
                //while (!_isMapLoaded)
                {
                    //This is an INFINITE loop, because translation can NOT be done until we have a mapping defined
                    // Add code to break loop after so long and through ERROR to console and logs to notify user

                    if (!File.Exists(_morseToTextDictionaryFile))
                    {
                        //Wait for file to load
                    }
                    else
                    {
                        // Load Dictionary
                    }
                }
            }
            catch (Exception e)
            {
                WriteToLogFile($"The process failed to get _moreseToTextDictionaryFile with exception: {e.ToString()}", true);
            }



            //If map was previously loaded and file gets removed, CONTINUE with _isMapLoaded=true until Time check confirms new file
            DateTime _mapFileTime = File.GetLastWriteTime(_morseToTextDictionaryFile);
            //Console.WriteLine("Last file write time for {0} was {1}.", _morseToTextDictionaryFile, _mapFileTime);
            WriteVerboseToLogFile($"Last file write time for {_morseToTextDictionaryFile} was {_mapFileTime}", true);

            //Create Morse Code to English Dictionary from file
            Dictionary<string, string> _myMorseToTextDictionary = new Dictionary<string, string>();

            using (StreamReader _morseToTextFile = new StreamReader(_morseToTextDictionaryFile))
            {
                string _morseToTextFileLine;
                while ((_morseToTextFileLine = _morseToTextFile.ReadLine()) != null)
                {
                    string[] _myMorseKeyValues = _morseToTextFileLine.Split('\t');
                    _myMorseToTextDictionary.Add(_myMorseKeyValues[0], _myMorseKeyValues[1]);
                    //Console.WriteLine($"{_myMorseKeyValues[0]}, {_myMorseKeyValues[1]}");
                    WriteVerboseToLogFile($"Morse'{_myMorseKeyValues[0]}', Text'{_myMorseKeyValues[1]}'", false);
                }
            }


            //Create Text(English) to Morse Code Dictionary from file
            Dictionary<string, string> _myTextToMorseDictionary = new Dictionary<string, string>();

            using (StreamReader _textToMorseFile = new StreamReader(_textToMorseDictionaryFile))
            {
                string _textToMorseFileLine;
                while ((_textToMorseFileLine = _textToMorseFile.ReadLine()) != null)
                {
                    string[] _myTextKeyValues = _textToMorseFileLine.Split('\t');
                    _myTextToMorseDictionary.Add(_myTextKeyValues[0], _myTextKeyValues[1]);
                    WriteVerboseToLogFile($"Text'{_myTextKeyValues[0]}', Morse'{_myTextKeyValues[1]}'", false);
                }
            }


            //Import MORSE file to be converted
            string _myBreak = "||";
            string[] _myDelimiterChar = { _myBreak, " " };
            string[] _importedMorseFileLines = File.ReadAllLines(_morseFile);
            StringBuilder _buildOutputString = new StringBuilder();
            foreach (string _importedMorseFileSingleLine in _importedMorseFileLines)
            {
                WriteVerboseToLogFile($"Line from Morse file: {_importedMorseFileSingleLine}", true);
                //Might want to convert line before removing delimiters
                //var result = String.Join("", _importedMorseFileSingleLine.Select(x => _myMorseToTextDictionary[x]));
                //Console.WriteLine(result);

                //Replace text between || symbols using dictionary


                //This ADDS a Space between words (designated by "||||") but leaves || between each morse letter
                //        var _importedMorseFileSingleLineSpaced = _importedMorseFileSingleLine.Replace("||||", " ");
                //        Console.WriteLine(_importedMorseFileSingleLineSpaced);

                //I don't think we want this for morse to text! text to morse, maybe (was _importedMorseFileSingleLineSpaced)
                string[] _importedMorseFileSingleLineChars = _importedMorseFileSingleLine.Split(_myDelimiterChar, StringSplitOptions.None);

                string _textChar = "-";
                foreach (string _importedMorseFileSingleLineSingleChar in _importedMorseFileSingleLineChars)
                {
                    //MorseToText();

                    if (_importedMorseFileSingleLineSingleChar == "")
                    {
                        _textChar = " ";
                    }
                    else if (!_myMorseToTextDictionary.TryGetValue(_importedMorseFileSingleLineSingleChar, out _textChar))
                    {
                        // the key isn't in the dictionary.
                        if (_importedMorseFileSingleLineSingleChar.Contains('|'))
                        {
                            WriteToLogFile("ERROR: The delimiter should be '||' between characters and '||||' between words.", true);
                            WriteToLogFile($"ERROR: The file '{_morseFile}' contains '{_importedMorseFileSingleLineSingleChar}'.", true);
                            return;
                        }
                        else if (!(_importedMorseFileSingleLineSingleChar.Contains('.') || _importedMorseFileSingleLineSingleChar.Contains('-')))
                        {
                            WriteToLogFile("ERROR: The file should specify Morse Code with '.' and '-' characters.", true);
                            WriteToLogFile($"ERROR: The file '{_morseFile}' contains '{_importedMorseFileSingleLineSingleChar}'.", true);
                            return;
                        }
                        else
                        {
                            WriteToLogFile($"ERROR: The file '{_morseFile}' contains '{_importedMorseFileSingleLineSingleChar}' which has no English mapping.", true);
                            return;
                        }
                    }

                    //Build a string locally with Stringbuilder, to save on IO expenditure
                    //Write the completed result stringbuilder string to a file - use using statement to catch file errors/close
                    _buildOutputString.Append(_textChar);


                    WriteVerboseToLogFile($"{_importedMorseFileSingleLineSingleChar}, {_textChar}", false);
                }
                _buildOutputString.AppendLine();
                WriteVerboseToLogFile("", false);
            }
            WriteVerboseToLogFile($"Completed with looping file. Output Text: \"{_buildOutputString}\"", true);
            WriteToConsole($"Output Text: \"{_buildOutputString}\"");

            //Write stringbuilder string to output text file
            if (!File.Exists(_morseFileOutput))
            {
                using (StreamWriter sw = new StreamWriter(_morseFileOutput))
                {
                    sw.Write(_buildOutputString.ToString());
                }
            }
            else
            {
                WriteToLogFile($"File \"{_morseFileOutput}\" already exists.", true);
                return;
            }

            //Import TEXT file to be converted
            string[] _myTDelimiterChar = { " " };
            string[] _importedTextFileLines = File.ReadAllLines(_textFile);
            foreach (string _importedTextFileSingleLine in _importedTextFileLines)
            {
                Console.WriteLine(_importedTextFileSingleLine);
                var _importedTextFileSingleLineSpaced = _importedTextFileSingleLine.Replace(" ", "||||");
                Console.WriteLine(_importedTextFileSingleLineSpaced);
                string[] _importedTextFileSingleLineChars = _importedTextFileSingleLineSpaced.Split(_myTDelimiterChar, StringSplitOptions.RemoveEmptyEntries);

                foreach (string _importedTextFileSingleLineSingleChar in _importedTextFileSingleLineChars)
                {
                    //TextToMorse();
                    //Console.Write($"{_importedTextFileSingleLineSingleChar}");
                }
                //Console.WriteLine();
            }
        }


        static void UserInputFilePath()
        {
            /* All this data would be in an initialization file or database to be pulled in at initialization
             * An assumption is being made that no validation needs to be performed here.
             * As part of a larger system this would not be run via user input, it would be called. */

            //Prompt user for input of filenames for all variables being used
            WriteToConsole("Enter file path to be used for Input: ");
            string _inputFilePath = Console.ReadLine();
            WriteToLogFile($"User entered \"{_inputFilePath}\" into the console for _inputFilePath", false);
            WriteToConsole("Enter filename of the Morse Code input file to be converted to English: (Enter Y if entered with file path)");
            string _inputFileName = Console.ReadLine();
            if (_inputFileName.ToUpper() == "Y")
            {
                string _inputFile = _inputFilePath;
                WriteToConsole($"{_inputFile}");
            }
            else
            {
                string _inputFile = Path.Combine(_inputFilePath, _inputFileName);
                WriteToConsole($"{_inputFile}");
            }

            //Get Output File info
            WriteToConsole("Enter the file path to be used for Output: ");
            string _outputFilePath = Console.ReadLine();
            WriteToConsole("Enter filename of the English converted output file: (Enter Y if entered with file path)");
            string _outputFileName = Console.ReadLine();
            if (_outputFileName.ToUpper() == "Y")
            {
                string _outputFile = _outputFilePath;
                WriteToConsole($"{_outputFile}");
            }
            else
            {
                string _outputFile = Path.Combine(_outputFilePath, _outputFileName);
                WriteToConsole($"{_outputFile}");
            }

            //Get Morse to English mapping to load into Dictionary for converting input files to text
            WriteToConsole("Enter the file path where the Morse Code mapping file is located: ");
            string _mapFilePath = Console.ReadLine();
            WriteToConsole("Enter filename of the Morse Code mapping file[Mose>Text]: (Enter Y if entered with file path)");
            string _mapFileName = Console.ReadLine();
            if (_mapFileName.ToUpper() == "Y")
            {
                string _mapFile = _mapFilePath;
                WriteToConsole($"{_mapFile}");
            }
            else
            {
                string _mapFile = Path.Combine(_mapFilePath, _mapFileName);
                WriteToConsole($"{_mapFile}");
            }
        }

        //Method to write verbose message to Log File and Console if desired
        //NOTE: This is a combination Log & Console output function
        static void WriteToLogFile(string msg, bool consoleMsg)
        {
            //Open file to append message
            StreamWriter sw = File.AppendText(_logFile);
            try
            {
                //Format message
                string logLine = String.Format("{0:G}: {1}", DateTime.Now, msg);
                //Write message to file
                sw.WriteLine(logLine);

                // Write a message to the console if consoleMsg=true and _outputToConsole=true
                if (consoleMsg && _outputToConsole)
                {
                    //Write message to console
                    Console.WriteLine($"{logLine}");
                }
            }
            finally
            {
                //Close Log file
                sw.Close();
            }
        }

        //Method to write verbose message to Log File and Console if desired
        //NOTE: There is no "verbose console" method
        static void WriteVerboseToLogFile(string msg, bool consoleMsg)
        {
            // Write a message to the log file if _verboseLogging=true
            if (_verboseLogging)
            {
                //Open file to append message
                StreamWriter sw = File.AppendText(_logFile);
                try
                {
                    //Format message
                    string logLine = String.Format("{0:G}:Verbose: {1}", DateTime.Now, msg);
                    //Write message to file
                    sw.WriteLine(logLine);

                    // Write a message to the console if consoleMsg=true and _outputToConsole=true
                    if (consoleMsg && _outputToConsole)
                    {
                        //Write message to console
                        Console.WriteLine($"{logLine}");
                    }
                }
                finally
                {
                    //Close file
                    sw.Close();
                }
            }
        }

        //Method to write a message to the console
        static void WriteToConsole(string msg)
        {
            //Write message to console
            Console.WriteLine(msg);
        }

        //Method to use console to prompt user for input> Provide initialization file path
        /* The initialization file contains all related variables for this programs opperation
         * from a real-time unattended execution perspective.
         * File names/locations and other system variables are read from this file and used*/
        static void GetInitFile()
        {
            //This data could be pulled from a database table with constraints
            WriteToConsole("Enter file path/name to be used to intialize all defaults, file paths, etc.: ");
            string _initFile = Console.ReadLine();
        }

        //Method to load File names/locations and other system variables from the initialization file
        static void LoadInitFile()
        {
            //Load values from INIT file into variables used for processing using a dictionary
            Dictionary<string, string> _myInitFileDictionary = new Dictionary<string, string>();

            using (StreamReader _initFile = new StreamReader(_initDictionaryFile))
            {
                string _initFileLine;
                //Process each line of the file
                WriteVerboseToLogFile($"Loading contents of file {_initDictionaryFile} into dictionary _myInitFileDictionary", true);
                while ((_initFileLine = _initFile.ReadLine()) != null)
                {
                    //File is expected to be tab (\t) delimited - separate each line into Key & its Value
                    string[] _myInitKeyValues = _initFileLine.Split('\t');
                    //Add Key/Value pair into dictionary
                    _myInitFileDictionary.Add(_myInitKeyValues[0], _myInitKeyValues[1]);
                    //Write key/value pair mapping to log file & console if _verboseLogging=true flag
                    WriteVerboseToLogFile($"Variable'{_myInitKeyValues[0]}', Value'{_myInitKeyValues[1]}'", true);
                }
            }
        }
    }
}
