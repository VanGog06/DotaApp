import React from 'react';

import { Link } from 'react-router-dom';

import Card from 'react-bootstrap/Card';

const Hero = ({ id, name, imageUrl, attackType }) => (
  <Card className="p-3 m-3 col-sm-2" key={id}>
    <Card.Img variant="top" src={`https://api.opendota.com${imageUrl}`} />
    <Card.Body>
      <Card.Title>
        <Link to={`/heroes/${id}`}>{name}</Link>
      </Card.Title>
      <Card.Text>{attackType}</Card.Text>
    </Card.Body>
  </Card>
);

export default Hero;