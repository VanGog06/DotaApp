import React from 'react';

import { useSelector } from 'react-redux';

import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';

import { IndexLinkContainer } from 'react-router-bootstrap';

const Header = () => {
  const userData = useSelector(state => state.user);

  return (
    <Navbar bg="dark" variant="dark">
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