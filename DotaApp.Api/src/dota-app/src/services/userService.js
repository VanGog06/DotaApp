import {
  authHeader,
  handleResponse
} from '../helpers';

import { appConstants } from '../constants';

const login = (username, password) => {
  const requestOptions = {
    method: 'POST',
    headers: authHeader(),
    body: JSON.stringify({username, password})
  };

  return fetch(`${appConstants.apiUrl}/users/authenticate`, requestOptions)
    .then(handleResponse)
    .then(user => {
      if (user.token) {
        localStorage.setItem('user', JSON.stringify(user));
      }

      return user;
    });
};

const register = user => {
  const requestOptions = {
    method: 'POST',
    headers: authHeader(),
    body: JSON.stringify(user)
  };

  return fetch(`${appConstants.apiUrl}/users/register`, requestOptions)
    .then(handleResponse);
};

const logout = _ => {
  localStorage.removeItem('user');
};

const update = profile => {
  const requestOptions = {
    method: 'POST',
    headers: authHeader(),
    body: JSON.stringify(profile)
  };

  return fetch(`${appConstants.apiUrl}/users/update/${profile.id}`, requestOptions)
    .then(handleResponse);
};

export const userService = {
  login,
  register,
  logout,
  update
};