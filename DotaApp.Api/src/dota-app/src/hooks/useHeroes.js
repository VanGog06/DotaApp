import { useEffect } from 'react';

import {
  useSelector,
  shallowEqual,
  useDispatch
} from 'react-redux';

import { heroActions } from '../actions';

export const useHeroes = () => {
  const heroes = useSelector(state => state.heroes, shallowEqual);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(heroActions.getAll());
  }, [dispatch]);

  return heroes;
};