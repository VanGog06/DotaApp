import { teamConstants } from '../constants';

const initialState = {
  all: []
};

export const teams = (state = initialState, action) => {
  switch(action.type) {
    case teamConstants.TEAMS_REQUEST:
      return { ...state, all: [ ...state.all ] };
    case teamConstants.TEAMS_SUCCESS:
      return { ...state, all: action.teams };
    case teamConstants.TEAMS_FAILURE:
      return { ...state, all: [ ...state.all ] };
    default:
      return { ...state, all: [ ...state.all ] };
  }
};