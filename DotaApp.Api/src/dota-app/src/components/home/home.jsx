import React from 'react';
import styles from './home.module.css';

const HomePage = () => (
  <div className={styles.container}>
    <h1 className='text-center text-white mt-3'>{`Welcome to <DotaApp />`}</h1>
  </div>
);

export default HomePage;