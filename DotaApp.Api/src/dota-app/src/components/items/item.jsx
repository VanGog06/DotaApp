import React from 'react';

import { Link } from 'react-router-dom';

import Card from 'react-bootstrap/Card';

const Item = ({ id, name, image }) => (
  <Card className="p-2 m-2" style={{width: '10%'}} key={id}>
    <Card.Img variant="top" src={`https://api.opendota.com${image}`} />
    <Card.Body>
      <Card.Title>
        <Link to={`/items/${id}`} style={{fontSize: '16px'}}>{name}</Link>
      </Card.Title>
    </Card.Body>
  </Card>
);

export default Item;