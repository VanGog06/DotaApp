import React from 'react';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

const Register = () => (
  <>
    <h1 className='text-center mt-3 text-white'>Register</h1>

    <Form className='col-sm-10 offset-sm-1 mt-5'>
      <Form.Group as={Row} controlId="formHorizontalUsername">
        <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
          Username
        </Form.Label>
        <Col sm={4}>
          <Form.Control placeholder="Username" />
        </Col>
      </Form.Group>

      <Form.Group as={Row} controlId="formHorizontalPassword">
        <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
          Password
        </Form.Label>
        <Col sm={4}>
          <Form.Control type="password" placeholder="Password" />
        </Col>
      </Form.Group>

      <Form.Group as={Row} controlId="formHorizontalConfirmPassword">
        <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
          Confirm password
        </Form.Label>
        <Col sm={4}>
          <Form.Control type="password" placeholder="Confirm password" />
        </Col>
      </Form.Group>

      <Form.Group as={Row} controlId="formHorizontalFirstname">
        <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
          Firstname
        </Form.Label>
        <Col sm={4}>
          <Form.Control placeholder="Firstname" />
        </Col>
      </Form.Group>

      <Form.Group as={Row} controlId="formHorizontalLastname">
        <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
          Lastname
        </Form.Label>
        <Col sm={4}>
          <Form.Control placeholder="Lastname" />
        </Col>
      </Form.Group>

      <Form.Group as={Row} controlId="formHorizontalEmail">
        <Form.Label column sm={{span: 2, offset: 3}} className='text-white'>
          Email
        </Form.Label>
        <Col sm={4}>
          <Form.Control type="email" placeholder="Email" />
        </Col>
      </Form.Group>

      <Form.Group as={Row} className='mt-5'>
        <Col>
          <Button className='col-sm-2 offset-sm-5' type="submit">Register</Button>
        </Col>
      </Form.Group>
    </Form>
  </>
);

export default Register;