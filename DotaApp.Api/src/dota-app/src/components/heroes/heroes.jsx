import React, { useState, useEffect } from 'react';
import styles from './heroes.module.css';

import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';

import Hero from './hero';

import { useHeroes } from '../../hooks/useHeroes';

const Heroes = () => {
  const heroes = useHeroes();
  const [input, setInput] = useState('');
  const [filteredHeroes, setFilteredHeroes] = useState([]);

  useEffect(() => {
    const filterHeroes = (heroes, input) => {
      return heroes.all
        .filter(hero => hero.name.toLowerCase().indexOf(input) !== -1);
    }

    const filteredHeroes = filterHeroes(heroes, input);
    setFilteredHeroes(filteredHeroes);
  }, [heroes, input]);

  return (
    <div className={styles.container}>
      <Row className='ml-3 mr-3 mt-4'>
        <Col sm={8}>
          <h1 className='text-white text-center'>Heroes in game</h1>
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
      
      <div className={styles.heroContainer}>
        {filteredHeroes.map(hero =>
          <Hero key={hero.id} {...hero} />
        )}
      </div>
    </div>
  );
};

export default Heroes;