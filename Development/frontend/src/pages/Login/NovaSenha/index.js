import React, { useState } from 'react';

import nova_senha from '../../../images/nova_senha.svg'

import { Loader, Container, Left, Rigth, InputBox, InputWrapper } from './styles';

import ApiRecSenha from '../../../services/Login/RecuperacaoSenha/services';
import { useHistory } from 'react-router-dom';
import { toast, ToastContainer } from 'react-toastify';
import ClipLoader from "react-spinners/ClipLoader";

const apiRecSenha = new ApiRecSenha();

function NovaSenha(props) {

  const idLogin = props.location.state.idLogin;

  const navegation = useHistory();
  const [loading, setLoading] = useState(false);

  const [senha, setSenha] = useState('');
  const [confirmarSenha, setConfirmarSenha] = useState('');
  const req = {
    senha,
    confirmarSenha
  }

  const alterarSenhaClick = async () => {
    try {
      setLoading(true);

      const resp = await apiRecSenha.alterarSenha(idLogin, req);

      navegation.push('/');

      setLoading(false);

      return resp;
    } catch (e) {
      setLoading(false);
      toast.error(e.response.data.erro);
    }
  }

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
                <input type="password" onChange={e => setSenha(e.target.value)}/>
                <p>
                    A senha deve conter pelo menos 8 caracteres, <br/> 
                    2 números, <br/>
                    1 letra maiuscula, <br/>
                    1 minuscula e<br/>
                    1 caracterer especial.        
                </p>
              </InputWrapper>

              <InputWrapper>
                <span>Confirme a nova Senha</span>
                <input type="password" onChange={(e) => {setConfirmarSenha(e.target.value)}}/>
              </InputWrapper>
            
            </InputBox>

            <button onClick={alterarSenhaClick}>Salvar</button>
            <Loader>
              <ClipLoader loading={loading}/>
            </Loader>
          </Rigth>
          <ToastContainer/>
      </Container>
  );
}

export default NovaSenha;