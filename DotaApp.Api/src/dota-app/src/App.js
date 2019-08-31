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

import { PrivateRoute } from './components/privateRoute';
import Header from './components/common/header';
import Footer from './components/common/footer';
import Home from './components/home/home';
import Login from './components/login/login';
import Register from './components/register/register';
import Heroes from './components/heroes/heroes';
import HeroDetails from './components/heroes/heroDetails';
import Items from './components/items/items';
import ItemDetails from './components/items/itemDetails';
import Profile from './components/profile/profile';
import Review from './components/comments/review';
import Teams from './components/teams/teams';
import NotFound from './components/notFound';

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
          <Alert className='alertComponent' variant={alert.type}>
            {alert.message}
          </Alert>
        }

        <Switch>
          <Route exact path='/' component={Home} />
          <Route path='/login' component={Login} />
          <Route path='/register' component={Register} />
          <PrivateRoute path='/profile' component={Profile} />
          <PrivateRoute path='/review' component={Review} />
          <Route path='/heroes/:id' component={HeroDetails} />
          <Route path='/heroes' component={Heroes} />
          <Route path='/items/:id' component={ItemDetails} />
          <Route path='/items' component={Items} />
          <Route path='/teams' component={Teams} />
          <Route component={NotFound} />
        </Switch>

        <Footer />
      </Router>
    </div>
  );
}

export default App;