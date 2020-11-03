import React from 'react';
import { Link } from 'react-router-dom';

import { InputBox, InputWrapper } from '../../CadastrarUsuario/styles';
import {  Header } from '../styles';
import { Container, ButtonBox } from './styles';

function EsqueciSenha() {

  // Gerar codigo asysc recuperar-senha-email
  // envio de email para o usuário
  // backend recebe o email e envia


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
            <Link to="/Esqueci-a-senha/Autenticacao">Prosseguir</Link>
            <Link to="/">Cancelar</Link>
          </ButtonBox>
          
      </Container>
  );
}

export default EsqueciSenha;