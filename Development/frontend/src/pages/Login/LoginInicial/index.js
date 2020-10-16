import React, { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';

import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import { Header, Form, Cadastro  } from './styles';
import { InputBox, InputWrapper } from '../../CadastrarUsuario/styles';


import ApiLogin from '../../../services/Login/services';
const api = new ApiLogin();

function LoginInicial() {

  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');

  const navegation = useHistory();

  const efetuarLogin = async () => {
    try {

      const resp = await api.loginUsuario({
        email,
        senha
      })

      navegation.push({
        pathname:"/", 
        state:{
            idlogin:resp.idlogin,
            nomeUsuario:resp.nomeUsuario
        }        
      })

      return resp;
      
    } catch (e) {
      toast.error("coisas ruins ocorreram :(")
    }
  }

  return (
      <>
      <Header>
        <span>Olá quem é?</span>
        </Header>

        <Form>
          <InputBox>
                <InputWrapper>
                <span>Email</span>
                    <input type="email" placeholder="Bruce.Wayne@gmail.com" onChange={e => setEmail(e.target.value) } /> 
                </InputWrapper>

                <InputWrapper>
                <span>Senha</span>
                <input type="password" placeholder="Pelo menos 8 caracteres" onChange={e => setSenha(e.target.value)} /> 
                    <Link to="/Entrar/esqueci-a-senha">
                    Esqueci minha senha
                    </Link>
                </InputWrapper>
          </InputBox>
              <button onClick={efetuarLogin}>
                Entrar
              </button>
        </Form>

        <Cadastro>
          <span>Não tem uma conta?</span>
          <Link to="/Criar-uma-conta">Crie uma!</Link>
        </Cadastro>
        <ToastContainer />
      </>
  );
}

export default LoginInicial;