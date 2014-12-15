#include <iostream>
#include <string>
#include <sstream>

std::string convertFromMorse(std::string morse, std::string const morseCode[]);

int main()
{
    std::string input = "";
    std::cout << "Enter a word to be converted to: ";
    std::getline(std::cin, input);
    
    std::string const morseCode[] = {".-", "-...", "-.-.", "-..", ".", "..-.",
    "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-",
    ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."};
    
    std::cout << convertFromMorse(input, morseCode) << std::endl;
    

    return 0;
}

std::string convertFromMorse(std::string morse, std::string const morseCode[])
{
    std::string output = "";
    std::string letter = "";
    std::istringstream ss(morse);
    
    std::size_t const characters = 26;
    
    while(ss >> letter)
    {
        std::size_t index = 0;
        while(letter != morseCode[index] && index < characters)
        {
            ++index;
        }
        
        output += 'A' + index;
    }
    
    return output;
}