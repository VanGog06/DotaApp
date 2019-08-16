import React from 'react';
import styles from './home.module.css';

import Image from 'react-bootstrap/Image'

import background from '../../assets/background.jpg';

const HomePage = () => (
  <div className={styles.container}>
    <Image className={styles.background} src={background} fluid />
  </div>
);

export default HomePage;