import { combineReducers } from 'redux';

import { alert } from './alertReducer';
import { user } from './userReducer';
import { heroes } from './heroReducer';
import { items } from './itemReducer';

const rootReducer = combineReducers({
  alert,
  user,
  heroes,
  items
});

export default rootReducer;