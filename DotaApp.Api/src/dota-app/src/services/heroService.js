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

  return fetch(`${appConstants.apiUrl}/heroes`, requestOptions)
    .then(handleResponse);
};

export const heroService = {
  getAll
};