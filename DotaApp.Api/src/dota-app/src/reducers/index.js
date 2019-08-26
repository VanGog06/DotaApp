import { combineReducers } from 'redux';

import { alert } from './alertReducer';
import { user } from './userReducer';
import { heroes } from './heroReducer';
import { items } from './itemReducer';
import { comments } from './commentReducer';

const rootReducer = combineReducers({
  alert,
  user,
  heroes,
  items,
  comments
});

export default rootReducer;