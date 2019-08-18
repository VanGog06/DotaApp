import React from 'react';
import styles from './register.module.css';

import { useDispatch } from 'react-redux';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import { useForm } from '../../hooks/useForm';

import {
  userActions,
  alertActions
} from '../../actions';

const Register = () => {
  const dispatch = useDispatch();

  const stateSchema = {
    username: { value: '', error: '' },
    password: { value: '', error: '' },
    confirmPassword: { value: '', error: '' },
    firstName: { value: '', error: '' },
    lastName: { value: '', error: '' },
    email: { value: '', error: '' }
  };

  const validationStateSchema = {
    username: {
      required: true,
      validator: {
        regEx: /.+/,
        error: 'Username is required'
      }
    },
    password: {
      required: true,
      validator: {
        regEx: /.+/,
        error: 'Password is required'
      }
    },
    confirmPassword: {
      required: true,
      validator: {
        regEx: /.+/,
        error: 'Confirm password is required'
      }
    },
    firstName: {
      required: true,
      validator: {
        regEx: /.+/,
        error: 'Firstname is required'
      }
    },
    lastName: {
      required: true,
      validator: {
        regEx: /.+/,
        error: 'Lastname is required'
      }
    },
    email: {
      required: true,
      validator: {
        regEx: /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/,
        error: 'Email is required'
      }
    }
  };

  const handleSubmit = (state) => {
    const user = {
      username: state.username.value,
      password: state.password.value,
      confirmPassword: state.confirmPassword.value,
      firstName: state.firstName.value,
      lastName: state.lastName.value,
      email: state.email.value
    };

    if (user.password.localeCompare(user.confirmPassword) !== 0) {
      dispatch(alertActions.error('Passwords do not match'));
      return;
    }

    dispatch(userActions.register(user));
  };

  const { state, handleOnChange, handleOnSubmit, disable } = useForm(
    stateSchema,
    validationStateSchema,
    handleSubmit
  );

  return (
    <div className={styles.container}>
      <h1 className='text-center mt-3 text-white'>Register</h1>

      <Form onSubmit={handleOnSubmit} className='col-sm-10 offset-sm-1 mt-5'>
        <Form.Group as={Row} controlId="formHorizontalUsername">
          <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
            Username
          </Form.Label>
          <Col sm={4}>
            <Form.Control
              placeholder="Username"
              name='username'
              value={state.username.value}
              onChange={handleOnChange}
              required
              isValid={state.username.value.length > 0}
              isInvalid={state.username.value.length === 0}
            />
          </Col>
          {state.username.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.username.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} controlId="formHorizontalPassword">
          <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
            Password
          </Form.Label>
          <Col sm={4}>
            <Form.Control
              type="password"
              placeholder="Password"
              name='password'
              value={state.password.value}
              onChange={handleOnChange}
              required
              isValid={state.password.value.length > 0 && state.password.value.localeCompare(state.confirmPassword.value) === 0}
              isInvalid={state.password.value.length === 0 || state.password.value.localeCompare(state.confirmPassword.value) !== 0}
            />
          </Col>
          {state.password.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.password.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} controlId="formHorizontalConfirmPassword">
          <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
            Confirm password
          </Form.Label>
          <Col sm={4}>
            <Form.Control
              type="password"
              placeholder="Confirm password"
              name='confirmPassword'
              value={state.confirmPassword.value}
              onChange={handleOnChange}
              required
              isValid={state.confirmPassword.value.length > 0 && state.password.value.localeCompare(state.confirmPassword.value) === 0}
              isInvalid={state.confirmPassword.value.length === 0 || state.password.value.localeCompare(state.confirmPassword.value) !== 0}
            />
          </Col>
          {state.confirmPassword.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.confirmPassword.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} controlId="formHorizontalFirstname">
          <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
            Firstname
          </Form.Label>
          <Col sm={4}>
            <Form.Control
              placeholder="Firstname"
              name='firstName'
              value={state.firstName.value}
              onChange={handleOnChange}
              required
              isValid={state.firstName.value.length > 0}
              isInvalid={state.firstName.value.length === 0}
            />
          </Col>
          {state.firstName.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.firstName.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} controlId="formHorizontalLastname">
          <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
            Lastname
          </Form.Label>
          <Col sm={4}>
            <Form.Control
              placeholder="Lastname"
              name='lastName'
              value={state.lastName.value}
              onChange={handleOnChange}
              required
              isValid={state.lastName.value.length > 0}
              isInvalid={state.lastName.value.length === 0}
            />
          </Col>
          {state.lastName.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.lastName.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} controlId="formHorizontalEmail">
          <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
            Email
          </Form.Label>
          <Col sm={4}>
            <Form.Control
              type="email"
              placeholder="Email"
              name='email'
              value={state.email.value}
              onChange={handleOnChange}
              required
              isValid={state.email.value.length > 0}
              isInvalid={state.email.value.length === 0}
            />
          </Col>
          {state.email.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.email.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} className='mt-5'>
          <Col>
            <Button className='col-sm-2 offset-sm-5' type="submit" disabled={disable}>Register</Button>
          </Col>
        </Form.Group>
      </Form>
    </div>
  );
};

export default Register;