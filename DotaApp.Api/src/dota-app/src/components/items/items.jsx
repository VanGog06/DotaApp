import React, { useState, useEffect } from 'react';
import styles from './items.module.css';

import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';

import Item from './item';

import { useItems } from '../../hooks/useItems';

const Items = _ => {
  const items = useItems();
  const [input, setInput] = useState('');
  const [filteredItems, setFilteredItems] = useState([]);

  useEffect(() => {
    const filterItems = (items, input) => {
      return items
        .filter(item => {
          console.log(item.name);
          return item && item.name.toLowerCase().indexOf(input) !== -1
        });
    }

    const filteredHeroes = filterItems(items, input);
    setFilteredItems(filteredHeroes);
  }, [items, input]);

  return (
    <div className={styles.container}>
      <Row className='ml-3 mr-3 mt-4'>
        <Col sm={8}>
          <h1 className='text-white text-center'>Items in game</h1>
        </Col>

        <Col sm={4}>
          <InputGroup className={styles.inputGroup}>
            <InputGroup.Prepend>
              <InputGroup.Text>
                <svg viewBox="0 0 24 24" style={{display: 'inline-block', color: 'rgba(0, 0, 0, 0.87)', fill: 'currentcolor', height: '24px', width: '24px', userSelect: 'none', transition: 'all 450ms cubic-bezier(0.23, 1, 0.32, 1) 0ms', marginRight: '6px', opacity: '0.6'}}>
                  <path d="M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z"></path>
                </svg>
              </InputGroup.Text>
            </InputGroup.Prepend>

            <FormControl
              placeholder='Search by name...'
              aria-label='Search'
              onChange={(event) => setInput(event.target.value)}
            />
          </InputGroup>
        </Col>
      </Row>
      
      <div className={`${styles.itemContainer}`}>
        {filteredItems.map(item =>
          <Item key={item.id} {...item} />
        )}
      </div>
    </div>
  );
};

export default Items;