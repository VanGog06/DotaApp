import React from 'react';
import styles from './itemDetails.module.css';

import Image from 'react-bootstrap/Image';
import Row from 'react-bootstrap/Row';

import Comments from '../comments/comments';

import { useItem } from '../../hooks/useItem';

const ItemDetails = ({ match }) => {
  const item = useItem(match.params.id);

  return (
    item.hasOwnProperty('image') ?
      <div className={styles.container}>
        <div className={`${styles.itemBanner} col-sm-6 offset-sm-3`}>
          <Image className={styles.itemBackground} src={`https://api.opendota.com${item.image}`} fluid />

          <Row>
            <div className={`${styles.itemBannerDetails} col-sm-3`}>
              <Image className={styles.itemAvatar} src={`https://api.opendota.com${item.image}`} fluid />
            </div>

            <div className={`${styles.itemDetails} col-sm-5`}>
              <h3 className='text-white'>{item.name}</h3>
              <div>
                <img src='https://api.opendota.com/apps/dota2/images/tooltips/gold.png' alt='Gold' /> {item.cost}
              </div>
              <div>{item.lore}</div>
            </div>

            <div className={`${styles.attributes} col-sm-3`}>
              {item.itemAttributes.map(attribute =>
                <div key={attribute.key}>
                  {attribute.header}<span className='text-white font-weight-bold'>{attribute.value}</span> {attribute.footer}
                </div>
              )}
            </div>
          </Row>
        </div>

        <Comments itemId={match.params.id} />
      </div>
    :
      ''
  );
};

export default ItemDetails;