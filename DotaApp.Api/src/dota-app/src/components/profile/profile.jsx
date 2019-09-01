import React from 'react';
import styles from './profile.module.css';

import {
  useDispatch,
  useSelector
} from 'react-redux';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import { useForm } from '../../hooks/useForm';

import {
  userActions,
  alertActions
} from '../../actions';

const Profile = _ => {
  const user = useSelector(state => state.user.user);
  const dispatch = useDispatch();

  const stateSchema = {
    id: { value: user.id, error: '' },
    username: { value: user.username, error: '' },
    currentPassword: { value: '', error: '' },
    newPassword: { value: '', error: '' },
    confirmPassword: { value: '', error: '' },
  };

  const validationStateSchema = {
    id: {
      required: true,
      validator: {
        regEx: /.+/,
        error: ''
      }
    },
    username: {
      required: true,
      validator: {
        regEx: /.+/,
        error: 'Username is required'
      }
    },
    currentPassword: {
      required: true,
      validator: {
        regEx: /.+/,
        error: 'Current password is required'
      }
    },
    newPassword: {
      required: true,
      validator: {
        regEx: /.+/,
        error: 'New password is required'
      }
    },
    confirmPassword: {
      required: true,
      validator: {
        regEx: /.+/,
        error: 'Confirm password is required'
      }
    }
  };

  const handleSubmit = state => {
    const profile = {
      id: state.id.value,
      username: state.username.value,
      currentPassword: state.currentPassword.value,
      newPassword: state.newPassword.value
    };

    if (profile.newPassword.localeCompare(state.confirmPassword.value) !== 0) {
      dispatch(alertActions.error('Passwords do not match'));
      return;
    }

    dispatch(userActions.update(profile));
  };

  const { state, handleOnChange, handleOnSubmit, disable } = useForm(
    stateSchema,
    validationStateSchema,
    handleSubmit
  );

  return (
    <div className={styles.container}>
      <h1 className='text-center mt-3 text-white'>Profile</h1>

      <Form onSubmit={handleOnSubmit} className='col-sm-10 offset-sm-1 mt-5'>
        <Form.Group as={Row} controlId="formHorizontalUsername">
          <Form.Label column sm={5} md={{span: 4, offset: 1}} xl={{span: 2, offset: 3}} className='text-white'>
            Username
          </Form.Label>
          <Col md={6} xl={4}>
            <Form.Control
              placeholder="Username"
              name='username'
              value={state.username.value}
              required
              isValid={state.username.value.length > 0}
              isInvalid={state.username.value.length === 0}
              disabled
            />
          </Col>
          {state.username.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.username.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} controlId="formHorizontalcurrentPassword">
          <Form.Label column sm={5} md={{span: 4, offset: 1}} xl={{span: 2, offset: 3}} className='text-white'>
            Current password
          </Form.Label>
          <Col md={6} xl={4}>
            <Form.Control
              type="password"
              placeholder="Current password"
              name='currentPassword'
              value={state.currentPassword.value}
              onChange={handleOnChange}
              required
              isValid={state.currentPassword.value.length > 0}
              isInvalid={state.currentPassword.value.length === 0}
            />
          </Col>
          {state.currentPassword.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.currentPassword.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} controlId="formHorizontalNewPassword">
          <Form.Label column sm={5} md={{span: 4, offset: 1}} xl={{span: 2, offset: 3}} className='text-white'>
            New password
          </Form.Label>
          <Col md={6} xl={4}>
            <Form.Control
              type="password"
              placeholder="New password"
              name='newPassword'
              value={state.newPassword.value}
              onChange={handleOnChange}
              required
              isValid={state.newPassword.value.length > 0 && state.newPassword.value.localeCompare(state.confirmPassword.value) === 0}
              isInvalid={state.newPassword.value.length === 0 || state.newPassword.value.localeCompare(state.confirmPassword.value) !== 0}
            />
          </Col>
          {state.newPassword.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.newPassword.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} controlId="formHorizontalConfirmPassword">
          <Form.Label column sm={5} md={{span: 4, offset: 1}} xl={{span: 2, offset: 3}} className='text-white'>
            Confirm password
          </Form.Label>
          <Col md={6} xl={4}>
            <Form.Control
              type="password"
              placeholder="Confirm password"
              name='confirmPassword'
              value={state.confirmPassword.value}
              onChange={handleOnChange}
              required
              isValid={state.confirmPassword.value.length > 0 && state.newPassword.value.localeCompare(state.confirmPassword.value) === 0}
              isInvalid={state.confirmPassword.value.length === 0 || state.newPassword.value.localeCompare(state.confirmPassword.value) !== 0}
            />
          </Col>
          {state.confirmPassword.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.confirmPassword.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} className='mt-5'>
          <Col>
            <Button className='col-sm-6 offset-sm-3 col-md-4 offset-md-4 col-lg-3 offset-lg-4 col-xl-2 offset-xl-5' type="submit" disabled={disable}>Update</Button>
          </Col>
        </Form.Group>
      </Form>
    </div>
  );
};

export default Profile;