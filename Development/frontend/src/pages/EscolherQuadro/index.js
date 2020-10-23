import React from 'react';
import { Link } from 'react-router-dom';

import CabecalhoSimples from '../../components/CabecalhoSimples';
import QuadroButton from '../../components/QuadroButton';

import { Container, Content, QuadrosContainer,Divider ,AddTeam } from './styles';

function EscolherQuadro() {

    let times = [];
    for(var i = 1; i <= 50; i++){
        times.push(i);
    }
    let frase = "Time";


  return (
      <Container>
          <CabecalhoSimples />
          <Content>
              <h1>Escolha um quadro pra entrar</h1>
              <QuadrosContainer>
                <Link to="*" >
                  <AddTeam>
                       Criar um time
                  </AddTeam>
                </Link>
                  {times.map(x => (
                     <QuadroButton nome={frase + x} />
                  ))}
              </QuadrosContainer>
              <Divider />
              <QuadrosContainer>
                  <QuadroButton nome="Agenda Pessoal" />
              </QuadrosContainer>
          </Content>
      </Container>
  );
}

export default EscolherQuadro;