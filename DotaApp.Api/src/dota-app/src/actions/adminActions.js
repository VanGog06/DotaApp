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

const approveCommentRequest = _ => { return { type: adminConstants.APPROVE_COMMENT_REQUEST }};
const approveCommentSuccess = reviewComments => { return { type: adminConstants.APPROVE_COMMENT_SUCCESS, reviewComments }};
const approveCommentFailure = _ => { return { type: adminConstants.APPROVE_COMMENT_FAILURE }};

const approve = id => {
  return dispatch => {
    dispatch(approveCommentRequest());

    adminService.approve(id)
      .then(reviewComments => {
        dispatch(approveCommentSuccess(reviewComments));

        dispatch(alertActions.success(appConstants.commentApproved));

        setTimeout(() => {
          dispatch(alertActions.clear());
        }, 3000);
      }, error => {
        dispatch(approveCommentFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

const rejectCommentRequest = _ => { return { type: adminConstants.REJECT_COMMENT_REQUEST }};
const rejectCommentSuccess = reviewComments => { return { type: adminConstants.REJECT_COMMENT_SUCCESS, reviewComments }};
const rejectCommentFailure = _ => { return { type: adminConstants.REJECT_COMMENT_FAILURE }};

const reject = id => {
  return dispatch => {
    dispatch(rejectCommentRequest());

    adminService.reject(id)
      .then(reviewComments => {
        dispatch(rejectCommentSuccess(reviewComments));

        dispatch(alertActions.success(appConstants.commentRejected));

        setTimeout(() => {
          dispatch(alertActions.clear());
        }, 3000);
      }, error => {
        dispatch(rejectCommentFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const adminActions = {
  deleteComment,
  review,
  approve,
  reject
};