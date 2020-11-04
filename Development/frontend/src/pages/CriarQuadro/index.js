import React from 'react';

import CabecalhoSimples from '../../components/CabecalhoSimples';

import { Container, Content, Main, InputWrapper } from './styles';

function CriarQuadro() {
  return (
      <Container>
          <CabecalhoSimples />
          <Content>
              <h1>Criar novo quadro</h1>
              <Main>
                <InputWrapper>
                    <span>Nome do quadro</span>
                    <input type="text" placeholder="Quadro Legal" />
                  </InputWrapper>

                  <button>Criar Quadro</button>
              </Main>
          </Content>
      </Container>
  );
}

export default CriarQuadro;