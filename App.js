import React from 'react';
import ErrorBoundary from "./components/ErrorBoundary";
import MainScreen from './components/MainScreen';

export default function App() {
  return (
    <ErrorBoundary>
      <MainScreen />
    </ErrorBoundary>
  );
}
