import React from 'react';
import { Link } from 'react-router-dom';

import { Header, Form, Cadastro  } from './styles';
import { InputBox, InputWrapper } from '../../CadastrarUsuario/styles';

function LoginInicial() {
  return (
      <>
      <Header>
        <span>Olá quem é?</span>
        </Header>

        <Form>
          <InputBox>
                <InputWrapper>
                <span>Email</span>
                    <input type="email" placeholder="Bruce.Wayne@gmail.com" /> 
                </InputWrapper>

                <InputWrapper>
                <span>Senha</span>
                <input type="password" placeholder="Pelo menos 8 caracteres" /> 
                    <Link to="/Entrar/esqueci-a-senha">
                    Esqueci minha senha
                    </Link>
                </InputWrapper>
          </InputBox>
              <button>
                Entrar
              </button>
        </Form>

        <Cadastro>
          <span>Não tem uma conta?</span>
          <Link to="/Criar-uma-conta">Crie uma!</Link>
        </Cadastro>
      </>
  );
}

export default LoginInicial;