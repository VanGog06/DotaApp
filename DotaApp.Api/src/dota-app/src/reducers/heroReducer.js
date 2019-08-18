import { heroConstants } from '../constants';

const initialState = {
  all: []
};

export const heroes = (state = initialState, action) => {
  switch (action.type) {
    case heroConstants.GET_HEROES_REQUEST:
      return { ...state };
    case heroConstants.GET_HEROES_SUCCESS:
      return { ...state, all: action.heroes };
    case heroConstants.GET_HEROES_FAILURE:
      return { ...state };
    default:
      return { ...state };
  }
};