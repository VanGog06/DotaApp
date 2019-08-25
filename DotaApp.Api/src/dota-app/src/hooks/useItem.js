import { useEffect } from 'react';

import {
  useSelector,
  shallowEqual,
  useDispatch
} from 'react-redux';

import { itemActions } from '../actions';

export const useItem = id => {
  const items = useSelector(state => state.items, shallowEqual);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(itemActions.getById(id));
  }, [dispatch, id]);

  return items ? items.item : null;
};