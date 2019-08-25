import React from 'react';
import styles from './heroDetails.module.css';

import Image from 'react-bootstrap/Image';

import HeroStats from './heroStats'

import { useHero } from '../../hooks/useHero';

const HeroDetails = ({ match }) => {
  const hero = useHero(match.params.id);

  return (
    hero ? 
      <div className={styles.container}>
        <div className={`${styles.heroBanner} col-sm-8 offset-sm-2`}>
          <Image className={styles.heroBackground} src={`https://api.opendota.com${hero.image}`} fluid />

          <div className={styles.heroBannerDetails}>
            <Image className={`${styles.heroAvatar} col-sm-2`} src={`https://api.opendota.com${hero.image}`} fluid />

            <div className={`${styles.heroNameContainer} col-sm-5`}>
              <h2 className={styles.heroName}>{hero.name}</h2>
              <p className={styles.heroRoles}>
                <span>{hero.attackType}</span> - {hero.roles ? hero.roles.map(role => role.name).join(', ') : ''}
              </p>
            </div>

            <div className={'col-sm-5'}>
              <div className={`${styles.stats} col-sm-10 offset-sm-1`}>
                <div className='col-sm-4 text-center'>
                  <div className={`${styles.statCircle} ${styles.strengthBackground}`}></div>
                  <div className={`${styles.statText} ${styles.strengthTextColor}`}>{hero.baseStrength} + {hero.strengthGain}</div>
                </div>

                <div className='col-sm-4 text-center'>
                  <div className={`${styles.statCircle} ${styles.agilityBackground}`}></div>
                  <div className={`${styles.statText} ${styles.agilityTextColor}`}>{hero.baseAgility} + {hero.agilityGain}</div>
                </div>

                <div className='col-sm-4 text-center'>
                  <div className={`${styles.statCircle} ${styles.intellectBackground}`}></div>
                  <div className={`${styles.statText} ${styles.intellectTextColor}`}>{hero.baseIntellect} + {hero.intellectGain}</div>
                </div>
              </div>

              <div className={`col-sm-12 ${styles.abilityContainer}`}>
                {hero.abilities ?hero.abilities.map((ability, index) =>
                  <div className={styles.ability} key={index}>
                    <Image className={`${styles.abilityImage}`} src={`https://api.opendota.com${ability.image}`} fluid />
                  </div>
                ) : null}
              </div>
            </div>
          </div>
        </div>

        <HeroStats hero={hero}/>
      </div>
    :
      ''
  );
};

export default HeroDetails;