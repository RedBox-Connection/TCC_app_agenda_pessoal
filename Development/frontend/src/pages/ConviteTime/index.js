import React from 'react';

import convite from '../../images/convite.svg';

import { Container, Left, ButtonBox, Rigth } from './styles';

function ConviteTime() {
  return (
      <Container>
          <Left>
              <h1>Convite de 'Nome do time aqui'</h1>
              <p>'Tal pessoa' convidou você para colaborar em 'Nome do time'</p>
              <ButtonBox>
                  <button>Aceitar</button>
                  <button>Recusar</button>
              </ButtonBox>
          </Left>
          <Rigth>
            <img src={convite} alt="conviteImage"/>
          </Rigth>
      </Container>
  );
}

export default ConviteTime;