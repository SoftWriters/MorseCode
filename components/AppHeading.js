import React, { Component } from 'react';
import { StyleSheet, Text } from 'react-native';

class AppHeading extends Component {
    render(props) {
        return (
            <Text style={styles.header}>
                {this.props.customTitle}
            </Text>
        )
    }
}

const styles = StyleSheet.create({
    header: {
        marginTop: 15,
        fontSize: 26,
        fontWeight: 'bold',
        color: '#2580c0'
      }
});

export default AppHeading