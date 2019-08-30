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

const approve = id => {
  const requestOptions = {
    method: 'POST',
    headers: authHeader()
  };

  return fetch(`${appConstants.apiUrl}/admin/approve/${id}`, requestOptions)
    .then(handleResponse);
};

const reject = id => {
  const requestOptions = {
    method: 'POST',
    headers: authHeader()
  };

  return fetch(`${appConstants.apiUrl}/admin/reject/${id}`, requestOptions)
    .then(handleResponse);
};

export const adminService = {
  deleteComment,
  review,
  approve,
  reject
};