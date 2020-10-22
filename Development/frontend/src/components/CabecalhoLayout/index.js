import React from 'react';
import { Link } from 'react-router-dom';

import { Container, Profile } from './styles';

function CabecalhoLayout() {
  return (
      <Container>
          <h1>Organizer</h1>
          <Profile>
              <Link to="/Inicial">Bruce Wayne</Link>
              <strong>foto</strong>
          </Profile>
      </Container>
  );
}

export default CabecalhoLayout;