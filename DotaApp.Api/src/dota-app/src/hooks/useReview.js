import { useEffect } from 'react';

import {
  useSelector,
  shallowEqual,
  useDispatch
} from 'react-redux';

import { adminActions } from '../actions';

export const useReview = _ => {
  const reviewComments = useSelector(state => state.comments.reviewComments, shallowEqual);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(adminActions.review());
  }, [dispatch]);

  return reviewComments;
};