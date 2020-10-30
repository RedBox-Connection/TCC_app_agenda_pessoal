import React from 'react';
import { Link } from 'react-router-dom';

import { Journal, CheckCircle, Alarm, Sliders } from 'react-bootstrap-icons';

import { Container, ItemLink } from './styles';


function MenuLateral() {
  return (
      <Container>
          <ItemLink>
              <Journal />
              <Link to="/inicial/Agenda">Agenda</Link>
          </ItemLink>
          <ItemLink>
              <CheckCircle />
              <Link to="/inicial/Feitos">Feitos</Link>
          </ItemLink>
          <ItemLink>
              <Alarm />
              <Link to="/Inicial/Atrasados">Atrasados</Link>
          </ItemLink>
          <ItemLink>
              <Sliders />
              <Link to="/inicial/ConfigurarTime">Configurações</Link>
          </ItemLink>
      </Container>
  );
}

export default MenuLateral;