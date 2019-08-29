import React from 'react';
import styles from './review.module.css';

import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';

import { useReview } from '../../hooks/useReview';

const Review = _ => {
  const reviewComments = useReview();

  const handleApprove = id => {
    console.log(id);
  };

  const handleReject = id => {
    console.log(id);
  };

  return (
    <div className={styles.container}>
      <h1 className='text-white text-center pt-4 pb-3'>Comments review area</h1>

      {reviewComments.map((comment, index) =>
        <Card className={`${styles.card} p-3 m-3 col-sm-3`} key={index}>
          <h3 className='text-left'>{comment.username}</h3>
          <h6 className='text-left'>{new Date(comment.createdOn).toLocaleString()}</h6>
          <p className='text-left mb-3'>{comment.comment}</p>
          <div className='text-left'>
            <Button className='col-sm-3 mr-3' variant="success" onClick={() => handleApprove(comment.id)}>Approve</Button>
            <Button className='col-sm-3' variant="danger" onClick={() => handleReject(comment.id)}>Deny</Button>
          </div>
        </Card>
      )}
    </div>
  );
};

export default Review;