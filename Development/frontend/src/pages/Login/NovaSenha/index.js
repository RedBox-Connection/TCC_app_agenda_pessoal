import React from 'react';

import nova_senha from '../../../images/nova_senha.svg'

import { Container, Left, Rigth, InputBox, InputWrapper } from './styles';

function NovaSenha() {

    // Alterar senha deletar codigo async                 rota: recupar-senha-deletar/{idlogin}
    // para o usuário criar a nova senha

  return (
      <Container>
          <Left>
            <img src={nova_senha} alt="forgotImage" draggable={false}/>
          </Left>
          <Rigth>
            <h1>Defina sua nova senha</h1>

            <InputBox>
            
              <InputWrapper>
                <span>Nova Senha</span>
                <input type="password" placeholder="Pelo menos 8 caracteres" />
              </InputWrapper>

              <InputWrapper>
                <span>Confirme a nova Senha</span>
                <input type="password" />
              </InputWrapper>
            
            </InputBox>

            <button>Salvar</button>
          </Rigth>
      </Container>
  );
}

export default NovaSenha;