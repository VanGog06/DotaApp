import { commentConstants, appConstants } from '../constants';

import { commentService } from '../services';

import { alertActions } from '../actions';

const addCommentRequest = _ => { return { type: commentConstants.ADD_COMMENT_REQUEST }};
const addCommentSuccess = comment => { return { type: commentConstants.ADD_COMMENT_SUCCESS, comment }};
const addCommentFailure = _ => { return { type: commentConstants.ADD_COMMENT_FAILURE }};

const addComment = comment => {
  return dispatch => {
    dispatch(addCommentRequest());

    commentService.addComment(comment)
      .then(commentId => {
        dispatch(addCommentSuccess({...comment, id: commentId}));
        dispatch(alertActions.success(appConstants.commentSubmitted));

        setTimeout(() => {
          dispatch(alertActions.clear());
        }, 3000);
      }, error => {
        dispatch(addCommentFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

const allCommentsRequest = _ => { return { type: commentConstants.ALL_COMMENTS_REQUEST }};
const allCommentsSuccess = comments => { return { type: commentConstants.ALL_COMMENTS_SUCCESS, comments }};
const allCommentsFailure = _ => { return { type: commentConstants.ALL_COMMENTS_FAILURE }};

const getAll = itemId => {
  return dispatch => {
    dispatch(allCommentsRequest());

    commentService.all(itemId)
      .then(comments => {
        dispatch(allCommentsSuccess(comments));
      }, error => {
        dispatch(allCommentsFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const commentActions = {
  addComment,
  getAll
};