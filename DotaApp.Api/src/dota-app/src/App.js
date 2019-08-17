import React, { useEffect } from 'react';
import './App.css';

import {
  Router,
  Switch,
  Route
} from 'react-router-dom';

import {
  useSelector,
  useDispatch
} from 'react-redux';

import Alert from 'react-bootstrap/Alert';

import Header from './components/common/header';
import Footer from './components/common/footer';
import Home from './components/home/home';
import Login from './components/login/login';
import Register from './components/register/register';

import { history } from './helpers';

import { alertActions } from './actions';

function App() {
  const alert = useSelector(state => state.alert);
  const dispatch = useDispatch();
  
  useEffect(() => {
    const unlisten = history.listen(_ => {
      dispatch(alertActions.clear());
    });

    return () => unlisten();
  }, [dispatch]);

  return (
    <div className='full_screen_parent full_screen_child'>
      <Router history={history}>
        <Header />
          {alert.message &&
            <Alert variant={alert.type}>
              {alert.message}
            </Alert>
          }

          <Switch>
            <Route exact path='/' component={Home} />
            <Route path='/login' component={Login} />
            <Route path='/register' component={Register} />
          </Switch>

        <Footer />
      </Router>
    </div>
  );
}

export default App;