import {
  commentConstants,
  adminConstants
} from '../constants';

const initialState = {
  all: [],
  reviewComments: []
};

export const comments = (state = initialState, action) => {
  switch(action.type) {
    case commentConstants.ADD_COMMENT_REQUEST:
      return { ...state, all: [ ...state.all ], reviewComments: [ ...state.reviewComments ]};
    case commentConstants.ADD_COMMENT_SUCCESS:
      return { ...state, all: [ ...state.all ], reviewComments: [ ...state.reviewComments ]};
    case commentConstants.ADD_COMMENT_FAILURE:
      return { ...state, all: [ ...state.all ], reviewComments: [ ...state.reviewComments ]};
    case commentConstants.ALL_COMMENTS_REQUEST:
      return { ...state, all: [ ...state.all ], reviewComments: [ ...state.reviewComments ]};
    case commentConstants.ALL_COMMENTS_SUCCESS:
      return { ...state, all: action.comments, reviewComments: [ ...state.reviewComments ]};
    case commentConstants.ALL_COMMENTS_FAILURE:
      return { ...state, all: [ ...state.all ], reviewComments: [ ...state.reviewComments ]};
    case adminConstants.DELETE_COMMENT_REQUEST:
      return { ...state, all: [ ...state.all ], reviewComments: [ ...state.reviewComments ]};
    case adminConstants.DELETE_COMMENT_SUCCESS:
      return { ...state, all: [ ...state.all.filter(comment => comment.id !== action.id) ], reviewComments: [ ...state.reviewComments ]};
    case adminConstants.DELETE_COMMENT_FAILURE:
      return { ...state, all: [ ...state.all ], reviewComments: [ ...state.reviewComments ]};
    case adminConstants.COMMENTS_REVIEW_REQUEST:
      return { ...state, all: [ ...state.all ], reviewComments: [ ...state.reviewComments ]};
    case adminConstants.COMMENTS_REVIEW_SUCCESS:
      return { ...state, all: [ ...state.all ], reviewComments: action.reviewComments };
    case adminConstants.COMMENTS_REVIEW_FAILURE:
      return { ...state, all: [ ...state.all ], reviewComments: [ ...state.reviewComments ]};
    default:
      return { ...state, all: [ ...state.all ]};
  }
};