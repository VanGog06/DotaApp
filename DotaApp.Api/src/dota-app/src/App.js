import React from 'react';
import './App.css';

import {
  BrowserRouter as Router,
  Switch,
  Route
} from 'react-router-dom';

import Header from './components/common/header';
import HomePage from './components/home/home';

import Home from './components/home/home';
import Login from './components/login/login';
import Register from './components/register/register';

import { history } from './helpers';

function App() {
  return (
    <Router history={history}>
      <Header />
      <HomePage />

      <Switch>
        <Route exact path='/' component={Home} />
        <Route path='/login' component={Login} />
        <Route path='/register' component={Register} />
      </Switch>
    </Router>
  );
}

export default App;