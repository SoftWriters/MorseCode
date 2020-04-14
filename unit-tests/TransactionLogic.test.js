const Translate = require('../components/TranslationLogic');

test('Translate - Happy Path', () => {
    const morseCode = '...||---||...||||...||---||...';
    expect(Translate(morseCode)).toBe('SOS SOS');
});

test('Translate - Malformed Input', () => {
    const morseCode = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit,';
    expect(Translate(morseCode)).toBe('');
});

test('Translate - Spaces', () => {
    const morseCode = '.-||||||-...';
    expect(Translate(morseCode)).toBe('A  B');
});

test('Translate - Empty Input', () => {
    const morseCode = '';
    expect(Translate(morseCode)).toBe('');
});

test('Translate - NULL Input', () => {
    const morseCode = null;
    expect(Translate(morseCode)).toBe('');
});

test('Translate - Translate the Full Alphabet', () => {
    const morseCode = '.-||-...||-.-.||-..||.||..-.||--.||....||..||.---||-.-||.-..||--||-.||---||.--.||--.-||.-.||...||-||..-||...-||.--||-..-||-.--||--..';
    expect(Translate(morseCode)).toBe('ABCDEFGHIJKLMNOPQRSTUVWXYZ');
});

test('Translate - Translate Numbers', () => {
    const morseCode = '.----||..---||...--||....-||.....||-....||--...||---..||----.||-----';
    expect(Translate(morseCode)).toBe('1234567890');
});

test('Translate - Translate Long Input with a Space', () => {
    const morseCode = '.-||-...||-.-.||-..||.||..-.||--.||....||..||.---||-.-||.-..||--||-.||---||.--.||--.-||.-.||...||-||..-||...-||.--||-..-||-.--||--..||.----||..---||...--||....-||.....||-....||--...||---..||----.||-----||||.-||-...||-.-.||-..||.||..-.||--.||....||..||.---||-.-||.-..||--||-.||---||.--.||--.-||.-.||...||-||..-||...-||.--||-..-||-.--||--..||.----||..---||...--||....-||.....||-....||--...||---..||----.||-----'
    expect(Translate(morseCode)).toBe('ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890');
});