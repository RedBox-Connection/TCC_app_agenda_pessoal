import React from 'react';
import { Link } from 'react-router-dom';

import CabecalhoSimples from '../../components/CabecalhoSimples';
import QuadroButton from '../../components/QuadroButton';

import { Container, Content, QuadrosContainer, AddTeam } from './styles';

function EscolherQuadro() {
  return (
      <Container>
          <CabecalhoSimples />
          <Content>
              <h1>Escolha um quadro pra entrar</h1>
              <QuadrosContainer>
                  <QuadroButton nome="Time legal" />
                  <QuadroButton nome="Time legal" />
                  <QuadroButton nome="Time legal" />
                  <QuadroButton nome="Time legal" />
                  <QuadroButton nome="Time legal" />
                  <QuadroButton nome="Time legal" />
                  <QuadroButton nome="Time legal" />
                  <QuadroButton nome="Time legal" />
                  <QuadroButton nome="Time legal" />
                  <QuadroButton nome="Time legal" />
              </QuadrosContainer>
              <QuadrosContainer>
                  <QuadroButton nome="Agenda Pessoal" />
              </QuadrosContainer>
          </Content>
          <AddTeam> <Link to="*">+</Link></AddTeam> 
      </Container>
  );
}

export default EscolherQuadro;