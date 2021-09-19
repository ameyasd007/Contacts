import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import HomePage from './pages/HomePage'

import './custom.css'
import ContactPage from './pages/ContactPage';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path='/' component={HomePage} />
        <Route path='/contact' component={ContactPage} />
      </Layout>
    );
  }
}
