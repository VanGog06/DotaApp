import { combineReducers } from 'redux';

import { alert } from './alertReducer';
import { user } from './userReducer';

const rootReducer = combineReducers({
  alert,
  user
});

export default rootReducer;