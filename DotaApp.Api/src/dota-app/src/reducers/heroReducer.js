import { heroConstants } from '../constants';

const initialState = {
  all: [],
  hero: null
};

export const heroes = (state = initialState, action) => {
  switch (action.type) {
    case heroConstants.GET_HEROES_REQUEST:
      return { ...state };
    case heroConstants.GET_HEROES_SUCCESS:
      return { ...state, all: action.heroes };
    case heroConstants.GET_HEROES_FAILURE:
      return { ...state };
    case heroConstants.GET_HERO_REQUEST:
      return { ...state };
    case heroConstants.GET_HERO_SUCCESS:
      return { ...state, hero: action.hero };
    case heroConstants.GET_HERO_FAILURE:
      return { ...state };
    default:
      return { ...state };
  }
};