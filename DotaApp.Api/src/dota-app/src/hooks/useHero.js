import { useEffect } from 'react';

import {
  useSelector,
  shallowEqual,
  useDispatch
} from 'react-redux';

import { heroActions } from '../actions';

export const useHero = id => {
  const heroes = useSelector(state => state.heroes, shallowEqual);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(heroActions.getById(id));
  }, [dispatch, id]);

  return heroes ? heroes.hero : null;
};