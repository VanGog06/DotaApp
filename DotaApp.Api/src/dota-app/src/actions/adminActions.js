import { adminConstants } from '../constants';

import { adminService } from '../services';

import { alertActions } from '../actions';

const deleteCommentRequest = _ => { return { type: adminConstants.DELETE_COMMENT_REQUEST }};
const deleteCommentSuccess = id => { return { type: adminConstants.DELETE_COMMENT_SUCCESS, id }};
const deleteCommentFailure = _ => { return { type: adminConstants.DELETE_COMMENT_FAILURE }};

const deleteComment = id => {
  return dispatch => {
    dispatch(deleteCommentRequest());

    adminService.deleteComment(id)
      .then(_ => {
        dispatch(deleteCommentSuccess(id));
      }, error => {
        dispatch(deleteCommentFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const adminActions = {
  deleteComment
};