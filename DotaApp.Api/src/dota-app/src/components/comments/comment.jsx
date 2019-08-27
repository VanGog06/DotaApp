import React from 'react';
import styles from './comment.module.css';

import { useSelector } from 'react-redux';

import Row from 'react-bootstrap/Row';

import { appConstants } from '../../constants';

const Comment = ({ id, comment, username, createdOn, handleDeleteComment }) => {
  const currentUser = useSelector(state => state.user.user);

  return (
    <Row className={`${styles.row} mt-2`}>
      <h3 className={`${styles.name} col-sm-12`}>
        {username}
        {currentUser.username && currentUser.username.localeCompare(appConstants.adminUsername) === 0 ?
          <button type="button" className="close text-white" aria-label="Close" onClick={() => handleDeleteComment(id)}>
            <span aria-hidden="true">&times;</span>
          </button>
        : null}
      </h3>
      <h6 className={`${styles.createdOn} col-sm-12`}>{new Date(createdOn).toLocaleString()}</h6>
      <p className={`${styles.comment} col-sm-12`}>{comment}</p>
    </Row>
  );
};

export default Comment;