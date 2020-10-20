import React from 'react';
import { Link } from 'react-router-dom';

import { Container } from './styles';

function QuadroButton(props) {
  return (
      <Container>
          <Link to="*">{props.nome}</Link>
      </Container>
  );
}

export default QuadroButton;