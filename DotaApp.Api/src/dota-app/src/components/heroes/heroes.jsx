import React from 'react';
import styles from './heroes.module.css';

import { Link } from 'react-router-dom';

import Card from 'react-bootstrap/Card';

import { useHeroes } from '../../hooks/useHeroes';

const Heroes = () => {
  const heroes = useHeroes();

  return (
    <div className={styles.container}>
        {heroes.all.map((hero, index) =>
          <Card className="p-3 m-3 col-sm-2" key={index}>
            <Card.Img variant="top" src={`https://api.opendota.com${hero.imageUrl}`} />
            <Card.Body>
              <Card.Title>
                <Link to={`/heroes/${hero.id}`}>{hero.name}</Link>
              </Card.Title>
              <Card.Text>{hero.attackType}</Card.Text>
            </Card.Body>
          </Card>
        )}
    </div>
  );
};

export default Heroes;