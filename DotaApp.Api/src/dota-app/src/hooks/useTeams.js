import { useEffect } from 'react';

import {
  useSelector,
  shallowEqual,
  useDispatch
} from 'react-redux';

import { teamActions } from '../actions';

export const useTeams = _ => {
  const teams = useSelector(state => state.teams.all, shallowEqual);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(teamActions.all());
  }, [dispatch]);

  return teams;
};