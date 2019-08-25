import { itemConstants } from '../constants';

import { itemService } from '../services';

import { alertActions } from '../actions';

const getAllRequest = _ => { return { type: itemConstants.GET_ITEMS_REQUEST }};
const getAllSuccess = items => { return { type: itemConstants.GET_ITEMS_SUCCESS, items }};
const getAllFailure = _ => { return { type: itemConstants.GET_ITEMS_FAILURE }};

const getAll = _ => {
  return dispatch => {
    dispatch(getAllRequest());

    itemService.getAll()
      .then(items => {
        dispatch(getAllSuccess(items));
      }, error => {
        dispatch(getAllFailure(error));
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const itemActions = {
  getAll
};