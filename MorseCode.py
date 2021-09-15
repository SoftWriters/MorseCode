"""
Define exception raised when invalid morse code encountered
"""
class InvalidMorseCode(Exception):
    pass

"""
Define MorseCode class which translates morse code to text
"""
class MorseCode():
    """
    define a static dictionary that contains the letters of the alphabet as the
    key and the morse code as the value
    """
    translate_dict = {
        'a' : '.-',
        'b' : '-...',
        'c' : '-.-.',
        'd' : '-..',
        'e' : '.',
        'f' : '..-.',
        'g' : '--.',
        'h' : '....',
        'i' : '..',
        'j' : '.---',
        'k' : '-.-',
        'l' : '.-..',
        'm' : '--',
        'n' : '-.',
        'o' : '---',
        'p' : '.--.',
        'q' : '--.-',
        'r' : '.-.',
        's' : '...',
        't' : '-',
        'u' : '..-',
        'v' : '...-',
        'w' : '.--',
        'x' : '-..-',
        'y' : '-.--',
        'z' : '--..',
        '0' : '-----',
        '1' : '.----',
        '2' : '..---',
        '3' : '...--',
        '4' : '....-',
        '5' : '.....',
        '6' : '-....',
        '7' : '--...',
        '8' : '---..',
        '9' : '----.'
        }

    """
    generate a dictionary where the morse code is key and the value is the
    letter.  This makes it easier to translate the morse code.
    """
    morse_to_letter_dict = {code:letter for letter, code in \
                            translate_dict.items()}

    """
    Define init function for MorseCode class.  Optional argument input sets
    the morsecode to be translated to a default value
    """
    def __init__(self, input = "-..||---||--."):
        self.morsecode = input

    """
    Define translate function which takes as input the morse code and returns
    the translation.
    """
    def translate(self, input=None):

        if input != None:
            self.morsecode = input

        #create a list of morse code elements to be translated
        codes = self.morsecode.split('||')
        #print(codes)
        translated = ''

        for code in codes:
            # check to see if we have a valid morse code
            if code in self.morse_to_letter_dict.keys():
                #append the letter corresponding to the morse code to the
                #translation
                translated += self.morse_to_letter_dict[code]
            elif code == '':
                #if we encounter an empty code then translate to a space
                translated += ' '
            else:
                #print an error if we encounter an invalid code
                #print("ERROR: code not found!")
                raise InvalidMorseCode

        return translated

    """
    Define method to set the morse code to be translated
    """
    def set_morsecode(self, input):
        self.morsecode = input

    """
    Define method to get the morse code which is being translated
    """
    def get_morsecode(self):
        return self.morsecode

# define a main function which executes some tests on this module
def main():

    # define a dictionary that contains morse code with expected translation
    test_dict = {
        '-..||---||--.' : 'dog',
        '....||.||.-..||.-..||---||||.--||---||.-.||.-..||-..' : 'hello world',
        '...||---||...' : 'sos'
        }
    
    morsecode1 = MorseCode()
    try:
        """
        translate each morse code in the test dictionary and verify that the
        MorseCode class returns the correct translation
        """
        for morse, word in test_dict.items():
            correct = "Correctly translated {morse} into {word}"
            incorrect = """ERROR: Incorrectly translated {morse}.\r\n
            Expected: {expected} but instead got {actual}"""
            if morsecode1.translate(morse) != word:
                print(incorrect.format(morse = morse, \
                                       expected = word, \
                                       actual = morsecode1.translate(morse)))
            else:
                print(correct.format(morse = morse, word = word))
    except InvalidMorseCode:
        print("ERROR: Invalid morse code exception raised!")

    """
    Verify that the InvalidMorseCode exception is raised when an invalid
    morse code sequence is provided
    """
    try:
        invalid_morse_code = '----'
        morsecode1.translate(invalid_morse_code)
        print("ERROR: invalid morse code exception not raised!")
    except InvalidMorseCode:
        print("Invalid morse code exception raised correctly")
        
# execute main function only if this code is run as a script
if __name__ == "__main__":
    main()

