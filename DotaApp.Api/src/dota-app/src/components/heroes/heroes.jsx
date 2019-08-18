import React from 'react';
import styles from './heroes.module.css';

import Hero from './hero';

import { useHeroes } from '../../hooks/useHeroes';

const Heroes = () => {
  const heroes = useHeroes();

  return (
    <div className={styles.container}>
        {heroes.all.map(hero =>
          <Hero {...hero} />
        )}
    </div>
  );
};

export default Heroes;