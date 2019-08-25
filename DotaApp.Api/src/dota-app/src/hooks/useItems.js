import { useEffect } from 'react';

import {
  useSelector,
  shallowEqual,
  useDispatch
} from 'react-redux';

import { itemActions } from '../actions';

export const useItems = () => {
  const items = useSelector(state => state.items.all, shallowEqual);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(itemActions.getAll());
  }, [dispatch]);

  return items;

};