import React from 'react';
import styles from './teams.module.css';

import Table from 'react-bootstrap/Table'
import Image from 'react-bootstrap/Image'

import { useTeams } from '../../hooks/useTeams';

const Teams = _ => {
  const teams = useTeams();

  return (
    <div className={styles.container}>
      <h1 className='text-white text-center pt-4 pb-3'>Teams</h1>

      <Table striped bordered hover variant="dark" className={`${styles.table} col-sm-8 offset-sm-2`}>
        <thead>
          <tr>
            <th>Rank</th>
            <th>Name</th>
            <th>Rating</th>
            <th>Wins</th>
            <th>Losses</th>
          </tr>
        </thead>
        <tbody>
          {teams.map((team, index) =>
            <tr key={team.id}>
              <td>{index + 1}</td>
              <td className={styles.nameContainer}>
                <Image className={styles.image} src={team.logoUrl} rounded alt='Logo' />
                <div className={styles.name}>
                  <h4>{team.name}</h4>
                  <h6>Last played: {new Date(team.lastMatchTime).toLocaleDateString()}</h6>
                </div>
              </td>
              <td>{team.rating}</td>
              <td>{team.wins}</td>
              <td>{team.losses}</td>
            </tr>
          )}
        </tbody>
      </Table>
    </div>
  );
};

export default Teams;