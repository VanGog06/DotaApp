import React, {useState} from 'react';
import styles from './comments.module.css';

import {
  useSelector,
  useDispatch
} from 'react-redux';

import Nav from 'react-bootstrap/Nav';

import AddComment from './addComment';
import Comment from './comment';

import { useComments } from '../../hooks/useComments';

import { adminActions } from '../../actions';

const Comments = ({ itemId }) => {
  const [selectedKey, setSelectedKey] = useState('all');
  const comments = useComments(itemId);
  const dispatch = useDispatch();

  const isLoggedIn = useSelector(state => state.user.isLoggedIn);

  const handleCommentAdded = _ => {
    setSelectedKey('all');
  };

  const handleDeleteComment = id => {
    dispatch(adminActions.deleteComment(id));
  };

  return (
    <div className={styles.container}>
      {isLoggedIn ?
        <Nav justify className='col-sm-6 offset-sm-3 pr-0' variant='tabs' activeKey={selectedKey} onSelect={(selectedKey) => setSelectedKey(selectedKey)}>
          <>
            <Nav.Item>
              <Nav.Link className={styles.link} eventKey='all'>Comments</Nav.Link>
            </Nav.Item>

            <Nav.Item>
              <Nav.Link className={styles.link} eventKey='add'>Add new comment</Nav.Link>
            </Nav.Item>
          </>
        </Nav>
      : null}

      {selectedKey === 'all' ?
        <div className='col-sm-6 offset-sm-3'>
          {
            comments ? comments.all
              .map((comment, index) => <Comment key={index} {...comment} handleDeleteComment={handleDeleteComment} />)
            : null
          }
        </div>
      :
        <AddComment handleCommentAdded={handleCommentAdded} />
      }
    </div>
  );
};

export default Comments;