import React, {useState} from 'react';
import styles from './comments.module.css';

import Nav from 'react-bootstrap/Nav';

import AddComment from './addComment';

const Comments = _ => {
  const [selectedKey, setSelectedKey] = useState('all')

  return (
    <div className={styles.container}>
      <Nav justify className='col-sm-6 offset-sm-3 pr-0' variant='tabs' activeKey={selectedKey} onSelect={(selectedKey) => setSelectedKey(selectedKey)}>
        <Nav.Item>
          <Nav.Link className={styles.link} eventKey='all'>Comments</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link className={styles.link} eventKey='add'>Add new comment</Nav.Link>
        </Nav.Item>
      </Nav>

      {selectedKey === 'all' ?
        <div>All</div>
      :
        <AddComment />
      }
    </div>
  );
};

export default Comments;