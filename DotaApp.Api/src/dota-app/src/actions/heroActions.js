import { heroConstants } from '../constants';

import { heroService } from '../services';

import { alertActions } from '../actions';

const getAllRequest = _ => { return { type: heroConstants.GET_HEROES_REQUEST }};
const getAllSuccess = heroes => { return { type: heroConstants.GET_HEROES_SUCCESS, heroes }};
const getAllFailure = _ => { return { type: heroConstants.GET_HEROES_FAILURE }};

const getAll = _ => {
  return dispatch => {
    dispatch(getAllRequest());

    heroService.getAll()
      .then(heroes => {
        dispatch(getAllSuccess(heroes));
      }, error => {
        dispatch(getAllFailure(error.toString()));
        dispatch(alertActions.error(error.toString()));
      });
  };
};

const getHeroRequest = _ => { return { type: heroConstants.GET_HERO_REQUEST }};
const getHeroSuccess = hero => { return { type: heroConstants.GET_HERO_SUCCESS, hero }};
const getHeroFailure = _ => { return { type: heroConstants.GET_HERO_FAILURE }};

const getById = id => {
  return dispatch => {
    dispatch(getHeroRequest());

    heroService.getById(id)
      .then(hero => {
        dispatch(getHeroSuccess(hero));
      }, error => {
        dispatch(getHeroFailure(error.toString()));
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const heroActions = {
  getAll,
  getById
};