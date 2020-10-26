import React from 'react';
import { Link } from 'react-router-dom';

import { Container, Main } from './styles';

function WelcomePage() {
  return(
      <Container>
          <Main>
              <h1>Bem-vindo(a) ao Organizer :)</h1>
              <p>Clique em <Link to="/inicial/Agenda">Agenda</Link> para continuar e deixar o seu dia mais fácil!</p>
          </Main>
      </Container>
  );
}

export default WelcomePage;