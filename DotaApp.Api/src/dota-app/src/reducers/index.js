import { combineReducers } from 'redux';

import { alert } from './alertReducer';
import { user } from './userReducer';
import { heroes } from './heroReducer';

const rootReducer = combineReducers({
  alert,
  user,
  heroes
});

export default rootReducer;