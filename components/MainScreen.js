import React from 'react';
import { Button, StyleSheet, Text, TextInput, View } from 'react-native';
import AppHeading from './AppHeading';
import TranslationLogic from './TranslationLogic';

class MainScreen extends React.Component { 
    constructor() {
        super()
        this.state = {
            morseCodeText: '',
            translatedText: ''            
        }
    }

    Translate() {
      // Translate 
      var translatedMorseCode = TranslationLogic(this.state.morseCodeText);        

      // Update the result Text
      this.setState( {translatedText: translatedMorseCode});
    }

    render() { 
      return (
        <View style={styles.container}>

            {/* Custom Title Text Component */}
            <AppHeading customTitle="Morse Code Translator" />
            
            <View style={styles.instructions}>
              <Text>. = Dot</Text>
              <Text>- = Dash</Text>
              <Text>|| = Break</Text>
            </View>

            <View style={styles.inputSection}>

              <Text>Enter Morse Code into the textbox below</Text>

              <TextInput 
                onChangeText={(value) => this.setState({ morseCodeText: value})}
                placeholder="...||---||..."
                style={styles.textbox} 
                underlineColorAndroid='transparent' 
                />

              <Button 
                  titleStyle={styles.translateButton} 
                  type="outline"
                  onPress={this.Translate.bind(this)}
                  title="Translate">
              </Button>

              <Text style={styles.resultSection}>
                  {this.state.translatedText}
              </Text>

            </View>
        </View>    
      );
    }
  }

  // Styles
  const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#fff',
      alignItems: 'center',
      justifyContent: "flex-start",
      marginTop: 20
    },
    instructions: {
      marginTop: 10,
      justifyContent: "flex-start"
    },
    inputSection: {
      height: 100,
      marginTop: 15,
      
    },
    translateButton: {
        borderWidth: 1,
        borderColor: '#000',
        borderRadius: 8,
        marginTop: 15
    },
    textbox: {
        height: 40,
        width: 250,
        borderColor: 'gray',
        borderWidth: 1,
        backgroundColor: '#fff',
        marginBottom: 8,
        padding: 5
      },
      resultSection: {
          marginTop: 15,
          fontSize: 18
      }
  });

  export default MainScreen