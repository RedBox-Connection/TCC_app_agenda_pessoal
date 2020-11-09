import React from 'react';
import { Link } from 'react-router-dom';

import { Journal, CheckCircle, Alarm, Sliders, Calendar2Week } from 'react-bootstrap-icons';

import { Container, ItemLink } from './styles';


function MenuLateral() {
  return (
      <Container>
          <ItemLink>
              <Journal />
              <Link to="/Inicial/Agenda">Agenda</Link>
          </ItemLink>
          <ItemLink>
              <CheckCircle />
              <Link to="/Inicial/Feitos">Feitos</Link>
          </ItemLink>
          <ItemLink>
              <Alarm />
              <Link to="/Inicial/Atrasados">Atrasados</Link>
          </ItemLink>
          <ItemLink>
              <Calendar2Week />
              <Link to="/Inicial/InfoQuadro">Info Quadro</Link>
          </ItemLink>
          <ItemLink>
              <Sliders />
              <Link to="/Inicial/ConfigurarTime">Configurações</Link>
          </ItemLink>
      </Container>
  );
}

export default MenuLateral;