import { combineReducers } from 'redux';

import { alert } from './alertReducer';
import { user } from './userReducer';
import { heroes } from './heroReducer';
import { items } from './itemReducer';
import { comments } from './commentReducer';
import { teams } from './teamReducer';

const rootReducer = combineReducers({
  alert,
  user,
  heroes,
  items,
  comments,
  teams
});

export default rootReducer;