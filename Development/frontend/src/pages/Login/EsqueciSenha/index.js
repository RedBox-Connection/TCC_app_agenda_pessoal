import React, { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';

import { InputBox, InputWrapper } from '../../CadastrarUsuario/styles';
import {  Header } from '../styles';
import { Container, ButtonBox, Loader } from './styles';

import ClipLoader from "react-spinners/ClipLoader";
import { toast, ToastContainer } from 'react-toastify';

import ApiRecSenha from '../../../services/Login/RecuperacaoSenha/services';

const apiRecSenha = new ApiRecSenha();

function EsqueciSenha(props) {

  const [loading, setLoading] = useState(false);
  const navegation = useHistory();

  const [email, setEmail] = useState(props.location.state);
  const req = {
    email
  };

  const enviarEmailClick = async () => {
    try {
      setLoading(true);

      const resp = await apiRecSenha.envioDeEmail(req);

      setLoading(false);

      navegation.push({
        pathname: '/Esqueci-a-senha/Autenticacao',
        state: {
          idLogin: resp.idLogin,
          email: resp.email
        }
      });

      return resp;
    } catch (e) {
      setLoading(false);
      toast.error(e.response.data.erro);
    }
  }

  return (
      <Container>
          <Header>
            <h1>Organizer</h1>
            <span>Por favor nos informe seu email</span>
          </Header>
          <InputBox>
            <InputWrapper>
               <span>Email</span>
               <input type="email" placeholder="Email" value={email} onChange={(e) => {setEmail(e.target.value)}}/>
            </InputWrapper>
            <p>Nós te enviaremos um código de segurança , para recebe-lo clique no botão de <strong>prosseguir</strong></p>
          </InputBox>

          <ButtonBox>
            <button onClick={enviarEmailClick}>Prosseguir</button>
            <Link to="/Entrar">Cancelar</Link>
          </ButtonBox>

          <Loader>
            <ClipLoader loading={loading}/>
          </Loader>
          <ToastContainer />                    
      </Container>
  );
}

export default EsqueciSenha;