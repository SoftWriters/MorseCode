/*
    Takes a string of dots, dashes, and pipes and returns it's English equivalent.
    Patterns not found in the defined list (morseCode.json) will be ignored.
*/
function Translate(morseCodeText) {

    if (morseCodeText == null || morseCodeText == '')
    {
        return '';
    }

    const DELIMITER = '||'

    // Load the mapping
    var morseCode = require('../assets/morseCode.json');

    // Split the input string by the delimiter
    var splitParts = morseCodeText.trim().split(DELIMITER);
    var translatedTextValue = '';

    for(let i = 0; i < splitParts.length ; i++)
    {
        var morseCodeItem = splitParts[i];
        if (morseCodeItem != '')
        {
            // Look for a match
            var matchingTranslation = morseCode.KeyValuePairs.find(x=> x.key==morseCodeItem);
            if (matchingTranslation != null)
            {
                translatedTextValue += matchingTranslation.value;
            }
        }
        else
        {
            // Add a space
            translatedTextValue += ' ';
        }
    }
    return translatedTextValue;    
}

module.exports = Translate