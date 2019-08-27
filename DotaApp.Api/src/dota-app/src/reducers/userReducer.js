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
      return { ...state, user: { ...state.user } };
    case userConstants.REGISTER_REQUEST:
      return { ...state, user: { ...state.user } };
    case userConstants.REGISTER_SUCCESS:
      return { ...state, user: { ...state.user } };
    case userConstants.REGISTER_FAILURE:
      return { ...state, user: { ...state.user } };
    case userConstants.LOGOUT:
      return { ...state, isLoggedIn: false, user: null };
    case userConstants.UPDATE_PROFILE_REQUEST:
      return { ...state, user: { ...state.user } };
    case userConstants.UPDATE_PROFILE_SUCCESS:
      return { ...state, user: { ...state.user } };
    case userConstants.UPDATE_PROFILE_FAILURE:
      return { ...state, user: { ...state.user } };
    default:
      return { ...state, user: { ...state.user } };
  }
};