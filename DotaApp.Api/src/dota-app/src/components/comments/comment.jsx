import React from 'react';
import styles from './comment.module.css';

import Row from 'react-bootstrap/Row';

const Comment = ({ id, comment, username, createdOn }) => (
  <Row className={`${styles.row} mt-2`}>
    <h3 className={`${styles.name} col-sm-12`}>{username}</h3>
    <h6 className={`${styles.createdOn} col-sm-12`}>{new Date(createdOn).toLocaleString()}</h6>
    <p className={`${styles.comment} col-sm-12`}>{comment}</p>
  </Row>
);

export default Comment;