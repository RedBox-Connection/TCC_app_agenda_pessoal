import React from 'react';

import { Header } from '../LoginInicial/styles';
import { InputBox } from '../../CadastrarUsuario/styles';

import { Container, InputWrapper } from './styles';

function AutenticacaoSenha() {
  return (
    <Container>
        <Header>
            <h1>Organizer</h1>
            <span>Insira o código de segurança aqui</span>
        </Header>

        <InputBox>
            <InputWrapper>
                <span>Código</span>
                <input type="number" 
                       min="0"
                       max="999999" 
                />
            </InputWrapper>
        </InputBox>
    
        <button>
            Prosseguir
        </button>
    </Container>
  );
}

export default AutenticacaoSenha;