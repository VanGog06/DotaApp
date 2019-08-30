import {
  authHeader,
  handleResponse
} from '../helpers';

import { appConstants } from '../constants';

const all = _ => {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  };

  return fetch(`${appConstants.apiUrl}/teams/all`, requestOptions)
    .then(handleResponse);
};

export const teamService = {
  all
};