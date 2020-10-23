import React from 'react';
import { Link } from 'react-router-dom';

import { Container } from './styles';

function QuadroButton(props) {
  return (
    <Link to="*">
      <Container>
          {props.nome}
      </Container>
    </Link>
  );
}

export default QuadroButton;