import React from 'react';
import { Link } from 'react-router-dom';

import { Journal, CheckCircle, Alarm } from 'react-bootstrap-icons';

import { Container, ItemLink } from './styles';


function MenuLateral() {
  return (
      <Container>
          <ItemLink>
              <Journal />
              <Link to="/Agenda">Agenda</Link>
          </ItemLink>
          <ItemLink>
              <CheckCircle />
              <Link to="/Agenda/Feitos">Feitos</Link>
          </ItemLink>
          <ItemLink>
              <Alarm />
              <Link to="/Agenda/Atrasados">Atrasados</Link>
          </ItemLink>
      </Container>
  );
}

export default MenuLateral;