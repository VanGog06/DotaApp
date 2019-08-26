import { useEffect } from 'react';

import {
  useSelector,
  shallowEqual,
  useDispatch
} from 'react-redux';

import { commentActions } from '../actions';

export const useComments = itemId => {
  const comments = useSelector(state => state.comments, shallowEqual);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(commentActions.getAll(itemId));
  }, [dispatch, itemId]);

  return comments;
};