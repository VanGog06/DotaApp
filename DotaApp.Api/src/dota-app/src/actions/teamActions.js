import { teamConstants } from '../constants';

import { teamService } from '../services';

import { alertActions } from '../actions';

const teamsRequest = _ => { return { type: teamConstants.TEAMS_REQUEST }};
const teamsSuccess = teams => { return { type: teamConstants.TEAMS_SUCCESS, teams }};
const teamsFailure = _ => { return { type: teamConstants.TEAMS_FAILURE }};

const all = _ => {
  return dispatch => {
    dispatch(teamsRequest());

    teamService.all()
      .then(teams => {
        dispatch(teamsSuccess(teams));
      }, error => {
        dispatch(teamsFailure());
        dispatch(alertActions.error(error.toString()));
      });
  };
};

export const teamActions = {
  all
};