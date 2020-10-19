import React from 'react';

import { Container, Profile } from './styles';

function CabecalhoLayout() {
  return (
      <Container>
          <h1>Organizer</h1>
          <Profile>
              <span>Bruce Wayne</span>
              <strong>foto</strong>
          </Profile>
      </Container>
  );
}

export default CabecalhoLayout;