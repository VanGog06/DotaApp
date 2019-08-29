import {
  adminConstants,
  appConstants
} from '../constants';

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
        dispatch(alertActions.success(appConstants.commentDeleted));

        setTimeout(() => {
          dispatch(alertActions.clear());
        }, 3000);
      }, error => {
        dispatch(deleteCommentFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

const commentsReviewRequest = _ => { return { type: adminConstants.COMMENTS_REVIEW_REQUEST }};
const commentsReviewSuccess = reviewComments => { return { type: adminConstants.COMMENTS_REVIEW_SUCCESS, reviewComments }};
const commentsReviewFailure = _ => { return { type: adminConstants.COMMENTS_REVIEW_FAILURE }};

const review = _ => {
  return dispatch => {
    dispatch(commentsReviewRequest());

    adminService.review()
      .then(reviewComments => {
        dispatch(commentsReviewSuccess(reviewComments));
      }, error => {
        dispatch(commentsReviewFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const adminActions = {
  deleteComment,
  review
};