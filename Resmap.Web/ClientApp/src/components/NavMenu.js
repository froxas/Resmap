import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>Resmap</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Home
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/counter'}>
              <NavItem>
                <Glyphicon glyph='education' /> Counter
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/fetchdata'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Data
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/fetchemp'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Employees
              </NavItem>
            </LinkContainer>     
            <LinkContainer to={'/scheduler'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Scheduler
              </NavItem>
            </LinkContainer>     
            <LinkContainer to={'/relation'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Relation
              </NavItem>
            </LinkContainer>     
           
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
