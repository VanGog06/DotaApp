import {
  authHeader,
  handleResponse
} from '../helpers';

import { appConstants } from '../constants';

const getAll = _ => {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  };

  return fetch(`${appConstants.apiUrl}/items`, requestOptions)
    .then(handleResponse);
};

const getById = id => {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  };

  return fetch(`${appConstants.apiUrl}/items/${id}`, requestOptions)
  .then(handleResponse);
};

export const itemService = {
  getAll,
  getById
};