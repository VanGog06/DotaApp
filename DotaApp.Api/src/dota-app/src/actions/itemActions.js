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
        dispatch(getAllFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

const getItemRequest = _ => { return { type: itemConstants.GET_ITEM_REQUEST }};
const getItemSuccess = item => { return { type: itemConstants.GET_ITEM_SUCCESS, item }};
const getItemFailure = _ => { return { type: itemConstants.GET_ITEM_FAILURE }};

const getById = id => {
  return dispatch => {
    dispatch(getItemRequest());

    itemService.getById(id)
      .then(item => {
        dispatch(getItemSuccess(item));
      }, error => {
        dispatch(getItemFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const itemActions = {
  getAll,
  getById
};