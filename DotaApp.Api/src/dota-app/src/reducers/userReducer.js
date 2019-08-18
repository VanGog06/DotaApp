import { userConstants } from '../constants';

const userData = JSON.parse(localStorage.getItem('user'));
const initialState = {
  isLoggedIn: userData ? true : false,
  isLoggingIn: false,
  user: userData
};

export const user = (state = initialState, action) => {
  switch(action.type) {
    case userConstants.LOGIN_REQUEST:
      return {
        ...state,
        isLoggingIn: true,
        user: {
          ...state.user,
          username: action.username
        }
      };
    case userConstants.LOGIN_SUCCESS:
      return {
        ...state,
        isLoggedIn: true,
        isLoggingIn: false,
        user: action.user
      };
    case userConstants.LOGIN_FAILURE:
      return { ...state };
    case userConstants.REGISTER_REQUEST:
      return { ...state };
    case userConstants.REGISTER_SUCCESS:
      return { ...state };
    case userConstants.REGISTER_FAILURE:
      return { ...state };
    case userConstants.LOGOUT:
      return { ...state, isLoggedIn: false, user: null };
    default:
      return { ...state };
  }
};