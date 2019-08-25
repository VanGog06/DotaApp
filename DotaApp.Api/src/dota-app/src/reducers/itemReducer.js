import { itemConstants } from '../constants';

const initialState = {
  all: [],
  item: null
};

export const items = (state = initialState, action) => {
  switch(action.type) {
    case itemConstants.GET_ITEMS_REQUEST:
      return { ...state, all: [ ...state.all ], item: { ...state.item } };
    case itemConstants.GET_ITEMS_SUCCESS:
      return { ...state, all: action.items, item: { ...state.item } };
    case itemConstants.GET_ITEMS_FAILURE:
      return { ...state, all: [ ...state.all ], item: { ...state.item } };
    case itemConstants.GET_ITEM_REQUEST:
      return { ...state, all: [ ...state.all ], item: { ...state.item } };
    case itemConstants.GET_ITEM_SUCCESS:
      return { ...state, all: [ ...state.all ], item: action.item };
    case itemConstants.GET_ITEM_FAILURE:
      return { ...state, all: [ ...state.all ], item: { ...state.item } };
    default:
      return { ...state, all: [ ...state.all ], item: { ...state.item } };
  }
};