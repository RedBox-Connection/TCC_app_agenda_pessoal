import React from 'react';
import { Link } from 'react-router-dom';

import NotFoundImage from '../../images/not_found.svg'

import { Container, Main, Content } from './styles';

function NotFound() {
  return (
    <Container>
      <Main>
        <img src={NotFoundImage} alt="NotFoundImage" />
        <Content>
          <h1>Oops!</h1>
          <p>Parece que essa página não existe</p>
          <Link to="/">Voltar para inicial</Link>
        </Content>
      </Main>
    </Container>
  );
}

export default NotFound;