import { commentConstants } from '../constants';

const initialState = {
  all: []
};

export const comments = (state = initialState, action) => {
  switch(action.type) {
    case commentConstants.ADD_COMMENT_REQUEST:
      return { ...state, all: [ ...state.all ]};
    case commentConstants.ADD_COMMENT_SUCCESS:
      return { ...state, all: [ ...state.all, action.comment ]};
    case commentConstants.ADD_COMMENT_FAILURE:
      return { ...state, all: [ ...state.all ]};
    default:
      return { ...state, all: [ ...state.all ]};
  }
};