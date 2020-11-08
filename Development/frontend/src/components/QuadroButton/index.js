import React from 'react';
import { Link } from 'react-router-dom';

import { Container } from './styles';

function QuadroButton(props) {

  return (
    <Link to={{
      pathname: '/Inicial',
      state: {
        idLogin: props.idLogin,
        nomeUsuario: props.nomeUsuario,
        descricao: props.descricao,
        idTipo: props.idTipo
      }
    }}>
      <Container>
          {props.nomeQuadro}
      </Container>
    </Link>
  );
}

export default QuadroButton;