import React from 'react';

import { useSelector } from 'react-redux';

import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';

import { IndexLinkContainer } from 'react-router-bootstrap';

import { appConstants } from '../../constants';

const Header = () => {
  const userData = useSelector(state => state.user);

  return (
    <Navbar bg="dark" expand="lg" variant="dark">
      <IndexLinkContainer to='/'>
        <Navbar.Brand href="/">
          {`<DotaApp />`}
        </Navbar.Brand>
      </IndexLinkContainer>

      <Navbar.Toggle aria-controls="basic-navbar-nav" />

      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-auto">
          <IndexLinkContainer to='/'>
            <Nav.Link>Home</Nav.Link>
          </IndexLinkContainer>

          <IndexLinkContainer to='/heroes'>
            <Nav.Link>Heroes</Nav.Link>
          </IndexLinkContainer>

          <IndexLinkContainer to='/items'>
            <Nav.Link>Items</Nav.Link>
          </IndexLinkContainer>

          <IndexLinkContainer to='/teams'>
            <Nav.Link>Teams</Nav.Link>
          </IndexLinkContainer>

          {userData.user && userData.user.username && userData.user.username.localeCompare(appConstants.adminUsername) === 0 ?
            <IndexLinkContainer to='/review'>
              <Nav.Link>Review</Nav.Link>
            </IndexLinkContainer>
          : null}
        </Nav>

        {userData.isLoggedIn ?
          <Nav>
            <IndexLinkContainer to='/profile'>
              <Nav.Link>{userData.user.username}</Nav.Link>
            </IndexLinkContainer>

            <IndexLinkContainer to='/login'>
              <Nav.Link>Logout</Nav.Link>
            </IndexLinkContainer>
          </Nav>
        :
          <Nav>
            <IndexLinkContainer to='/login'>
              <Nav.Link>Login</Nav.Link>
            </IndexLinkContainer>

            <IndexLinkContainer to='/register'>
              <Nav.Link>Register</Nav.Link>
            </IndexLinkContainer>
          </Nav>
        }
      </Navbar.Collapse>
    </Navbar>
  );
};

export default Header;