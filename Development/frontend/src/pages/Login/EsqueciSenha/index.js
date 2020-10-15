import React from 'react';

import { InputBox, InputWrapper } from '../../CadastrarUsuario/styles';
import {  Header } from '../styles';
import { Container, ButtonBox } from './styles';

function EsqueciSenha() {
  return (
      <Container>
          <Header>
            <h1>Organizer</h1>
            <span>Por favor nos informe seu email</span>
          </Header>
          <InputBox>
            <InputWrapper>
               <span>Email</span>
               <input type="email" placeholder="Email" />
            </InputWrapper>
            <p>Nós te enviaremos um código de segurança , para recebe-lo clique no botão de <strong>prosseguir</strong></p>
          </InputBox>

          <ButtonBox>
            <button>Prosseguir</button>
            <button>Cancelar</button>
          </ButtonBox>
          
      </Container>
  );
}

export default EsqueciSenha;