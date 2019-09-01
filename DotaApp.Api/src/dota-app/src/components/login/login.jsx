import React, { useEffect } from 'react';
import styles from './login.module.css';

import { useDispatch } from 'react-redux';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import { useForm } from '../../hooks/useForm';

import { userActions } from '../../actions';

const Login = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    // reset login status
    dispatch(userActions.logout());
  }, [dispatch]);

  const stateSchema = {
    username: { value: '', error: '' },
    password: { value: '', error: '' }
  };

  const validationStateSchema = {
    username: {
      required: true,
      validator: {
        //regEx: /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/,
        regEx: /.+/,
        error: 'Username is required'
      },
    },
    password: {
      required: true,
      validator: {
        //regEx: /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/,
        regEx: /.+/,
        error: 'Password is required'
      },
    }
  };

  const handleSubmit = (state) => {
    dispatch(userActions.login(state.username.value, state.password.value));
  };

  const { state, handleOnChange, handleOnSubmit, disable } = useForm(
    stateSchema,
    validationStateSchema,
    handleSubmit
  );

  return (
    <div className={styles.container}>
      <h1 className='text-center mt-3 text-white'>Login</h1>

      <Form onSubmit={handleOnSubmit} className='col-sm-10 offset-sm-1 mt-5'>
        <Form.Group as={Row} controlId="formHorizontalUsername">
          <Form.Label column sm={5} md={{span: 4, offset: 1}} xl={{span: 2, offset: 3}} className='text-white'>
            Username
          </Form.Label>
          <Col md={6} xl={4}>
            <Form.Control
              placeholder="Username"
              name="username"
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
          <Form.Label column sm={5} md={{span: 4, offset: 1}} xl={{span: 2, offset: 3}} className='text-white'>
            Password
          </Form.Label>
          <Col md={6} xl={4}>
            <Form.Control
              type="password"
              placeholder="Password"
              name='password'
              value={state.password.value}
              onChange={handleOnChange}
              required
              isValid={state.password.value.length > 0}
              isInvalid={state.password.value.length === 0}
            />
          </Col>
          {state.password.error && <Form.Label column sm={{span: 4, offset: 5}} className='text-danger text-bold'>{state.password.error}</Form.Label>}
        </Form.Group>

        <Form.Group as={Row} className='mt-5'>
          <Col>
            <Button className='col-sm-6 offset-sm-3 col-md-4 offset-md-4 col-lg-3 offset-lg-4 col-xl-2 offset-xl-5' type="submit" disabled={disable}>Login</Button>
          </Col>
        </Form.Group>
      </Form>
    </div>
  );
}

export default Login;