import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Trainings } from './components/Trainings';
import { store } from "./actions/store";
import { Provider } from "react-redux";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Provider store={store}>
        <Layout>
            <Route exact path='/' component={Trainings} />
        </Layout>
      </Provider>

    );
  }
}
