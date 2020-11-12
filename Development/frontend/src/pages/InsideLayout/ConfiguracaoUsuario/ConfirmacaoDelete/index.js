import React from 'react';

import { Link, useHistory } from 'react-router-dom';
import { toast, ToastContainer } from 'react-toastify';

import { Container, ButtonBox, Delete } from './styles';


import ConfiguracaoUsuarioApi from '../../../../services/ConfiguracaoUsuario/services';
const configuracaoUsuarioApi = new ConfiguracaoUsuarioApi();

function ConfirmacaoDelete(props) {

    const idLogin = props.location.state.idLogin;

    const navegation = useHistory();


    const deletarConta = async () => {
        try {
          const resp = await configuracaoUsuarioApi.deletarUsuarioAsync(idLogin);
    
          navegation.push('/');
    
          window.location.reload(false);
    
          return resp;
        } catch(e) {
          toast.error(e.response.data.erro);
        }
      }

  return (
      <Container>
          <h1>Deseja mesmo deletar sua conta para sempre?</h1>
          <ButtonBox>
              <Delete onClick={deletarConta}>Excluir conta</Delete>
              <Link to="/inicial/Configuracoes">Cancelar</Link>
          </ButtonBox>
          <ToastContainer />
      </Container>
  );
}

export default ConfirmacaoDelete;