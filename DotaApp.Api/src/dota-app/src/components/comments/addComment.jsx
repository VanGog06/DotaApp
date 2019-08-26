import React, { useState } from 'react';
import styles from './addComment.module.css';

import {
  useSelector,
  useDispatch
} from 'react-redux';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

import { commentActions } from '../../actions';

const AddComment = _ => {
  const [comment, setComment] = useState('');
  const user = useSelector(state => state.user);

  const dispatch = useDispatch();

  const handleAdd = _ => {
    const commentObject = {
      comment,
      userId: user.user.id 
    };

    dispatch(commentActions.addComment(commentObject));
  };

  return (
    <Form className={`${styles.form} col-sm-6 offset-sm-3`}>
      <Form.Group className='text-center mb-0' controlId="comment">
        <Form.Control as='textarea' rows='3' value={comment} onChange={(event) => setComment(event.target.value)} />
      </Form.Group>
        
      {comment.length < 10 ?
        <Form.Group>
          <Form.Label className={`${styles.errorMessage} text-left`}>The minimum length is 10</Form.Label>
        </Form.Group>
      : null}

      <Button
        className={`${styles.addBtn} col-sm-4 offset-sm-4`}
        variant='primary'
        type='submit'
        disabled={comment.length < 10}
        onClick={handleAdd}
        >
          Add
        </Button>
    </Form>
  );
};

export default AddComment;