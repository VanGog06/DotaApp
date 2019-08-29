import {
  authHeader,
  handleResponse
} from '../helpers';

import { appConstants } from '../constants';

const deleteComment = id => {
  const requestOptions = {
    method: 'DELETE',
    headers: authHeader()
  };

  return fetch(`${appConstants.apiUrl}/admin/comments/delete/${id}`, requestOptions)
    .then(handleResponse);
};

const review = _ => {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  };

  return fetch(`${appConstants.apiUrl}/admin/review`, requestOptions)
    .then(handleResponse);
};

export const adminService = {
  deleteComment,
  review
};