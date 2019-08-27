import {
  userConstants,
  appConstants
} from '../constants';

import { userService } from '../services';

import { history } from '../helpers';

import { alertActions } from '../actions';

const loginRequest = username => { return { type: userConstants.LOGIN_REQUEST, username}};
const loginSuccess = user => { return { type: userConstants.LOGIN_SUCCESS, user}};
const loginFailure = message => { return { type: userConstants.LOGIN_FAILURE, message}};

const login = (username, password) => {
  return dispatch => {
    dispatch(loginRequest(username));

    userService.login(username, password)
      .then(user => {
        dispatch(loginSuccess(user));
        history.push('/');
      },
      error => {
        dispatch(loginFailure(error.toString()));
        dispatch(alertActions.error(error.toString()));
      });
  };
};

const registerRequest = _ => { return { type: userConstants.REGISTER_REQUEST }};
const registerSuccess = _ => { return { type: userConstants.REGISTER_SUCCESS }};
const registerFailure = message => { return { type: userConstants.REGISTER_FAILURE, message }};

const register = user => {
  return dispatch => {
    dispatch(registerRequest());

    userService.register(user)
      .then(user => {
        dispatch(registerSuccess());
        dispatch(alertActions.success(appConstants.registrationCompleted));
      }, error => {
        dispatch(registerFailure(error.toString()));
        dispatch(alertActions.error(error.toString()));
      });
  };
};

const logout = _ => {
  userService.logout();
  return { type: userConstants.LOGOUT };
}

const updateProfileRequest = _ => { return { type: userConstants.UPDATE_PROFILE_REQUEST }};
const updateProfileSuccess = _ => { return { type: userConstants.UPDATE_PROFILE_SUCCESS }};
const updateProfileFailure = _ => { return { type: userConstants.UPDATE_PROFILE_FAILURE }};

const update = profile => {
  return dispatch => {
    dispatch(updateProfileRequest());

    userService.update(profile)
      .then(_ => {
        dispatch(updateProfileSuccess());
        dispatch(alertActions.success(appConstants.accountUpdated));

        setTimeout(() => {
          userService.logout();
        }, 1000);
      }, error => {
        dispatch(updateProfileFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const userActions = {
  login,
  register,
  logout,
  update
};