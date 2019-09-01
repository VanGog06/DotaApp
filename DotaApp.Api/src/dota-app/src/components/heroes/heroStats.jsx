import React from 'react';
import styles from './heroStats.module.css';

const HeroStats = ({ hero }) => (
  <div className={`col-md-10 offset-md-1 col-lg-8 offset-lg-2 col-xl-6 offset-xl-3 text-white ${styles.heroStatsContainer}`}>
    <div className='col-sm-1 col-md-3'>
      <span className={styles.statLabel}>BASE ATTACK:</span>
      <span className={styles.statValue}>{hero.baseAttackMin} - {hero.baseAttackMax}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>ATTACK RANGE:</span>
      <span className={styles.statValue}>{hero.attackRange}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>ATTACK RATE:</span>
      <span className={styles.statValue}>{hero.attackRate}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>ATTACK TYPE:</span>
      <span className={styles.statValue}>{hero.attackType}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>HEALTH:</span>
      <span className={styles.statValue}>{hero.baseHealth}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>HEALTH REGEN:</span>
      <span className={styles.statValue}>{hero.baseHealthRegen}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>MANA:</span>
      <span className={styles.statValue}>{hero.baseMana}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>MANA REGEN:</span>
      <span className={styles.statValue}>{hero.baseManaRegen}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>BASE ARMOR:</span>
      <span className={styles.statValue}>{hero.baseArmor}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>MOVE SPEED:</span>
      <span className={styles.statValue}>{hero.moveSpeed}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>TURN SPEED:</span>
      <span className={styles.statValue}>{hero.turnRate}</span>
    </div>

    <div className='col-sm-2 col-md-3'>
      <span className={styles.statLabel}>NUMBER OF LEGS:</span>
      <span className={styles.statValue}>{hero.legs}</span>
    </div>
  </div>
);

export default HeroStats;