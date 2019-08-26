import { commentConstants } from '../constants';

import { commentService } from '../services';

import { alertActions } from '../actions';

const addCommentRequest = _ => { return { type: commentConstants.ADD_COMMENT_REQUEST }};
const addCommentSuccess = comment => { return { type: commentConstants.ADD_COMMENT_SUCCESS, comment }};
const addCommentFailure = _ => { return { type: commentConstants.ADD_COMMENT_FAILURE }};

const addComment = comment => {
  return dispatch => {
    dispatch(addCommentRequest());

    commentService.addComment(comment)
      .then(_ => {
        dispatch(addCommentSuccess(comment));
      }, error => {
        dispatch(addCommentFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const commentActions = {
  addComment
};