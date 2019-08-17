import { alertConstants } from '../constants';

const success = message => {
  return { type: alertConstants.SUCCESS, message };
};

const error = message => {
  return { type: alertConstants.ERROR, message };
};

const clear = _ => {
  return { type: alertConstants.CLEAR, message: '' };
};

export const alertActions = {
  success,
  error,
  clear
};