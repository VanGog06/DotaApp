import {
  authHeader,
  handleResponse
} from '../helpers';

import { appConstants } from '../constants';

const addComment = comment => {
  const requestOptions = {
    method: 'POST',
    headers: authHeader(),
    body: JSON.stringify(comment)
  };

  return fetch(`${appConstants.apiUrl}/comments/add`, requestOptions)
    .then(handleResponse);
};

export const commentService = {
  addComment
};