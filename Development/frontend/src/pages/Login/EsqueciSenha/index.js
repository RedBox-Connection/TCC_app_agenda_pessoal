import React from 'react';
import { Link } from 'react-router-dom';

import { InputBox, InputWrapper } from '../../CadastrarUsuario/styles';
import {  Header } from '../LoginInicial/styles';
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
            <Link to="/Entrar/esqueci-a-senha/autenticacao">Prosseguir</Link>
            <button>Cancelar</button>
          </ButtonBox>
          
      </Container>
  );
}

export default EsqueciSenha;