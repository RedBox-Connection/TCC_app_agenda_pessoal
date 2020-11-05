import React from 'react';
import { Link } from 'react-router-dom';

import { Container } from './styles';

function QuadroButton(props) {

  return (
    <Link to={{
      pathname: '/Inicial',
      state: {
        idLogin: props.idLogin,
        nomeUsuario: props.nomeUsuario
      }
    }}>
      <Container>
          {props.nomeQuadro}
      </Container>
    </Link>
  );
}

export default QuadroButton;