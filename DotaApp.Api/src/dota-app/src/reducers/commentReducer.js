import {
  commentConstants,
  adminConstants
} from '../constants';

const initialState = {
  all: []
};

export const comments = (state = initialState, action) => {
  switch(action.type) {
    case commentConstants.ADD_COMMENT_REQUEST:
      return { ...state, all: [ ...state.all ]};
    case commentConstants.ADD_COMMENT_SUCCESS:
      return { ...state, all: [ ...state.all ]};
    case commentConstants.ADD_COMMENT_FAILURE:
      return { ...state, all: [ ...state.all ]};
    case commentConstants.ALL_COMMENTS_REQUEST:
      return { ...state, all: [ ...state.all ]};
    case commentConstants.ALL_COMMENTS_SUCCESS:
      return { ...state, all: action.comments};
    case commentConstants.ALL_COMMENTS_FAILURE:
      return { ...state, all: [ ...state.all ]};
    case adminConstants.DELETE_COMMENT_REQUEST:
      return { ...state, all: [ ...state.all ]};
    case adminConstants.DELETE_COMMENT_SUCCESS:
      return { ...state, all: [ ...state.all.filter(comment => comment.id !== action.id) ]};
    case adminConstants.DELETE_COMMENT_FAILURE:
      return { ...state, all: [ ...state.all ]};
    default:
      return { ...state, all: [ ...state.all ]};
  }
};