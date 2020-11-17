import React, { useState } from 'react';

import CabecalhoSimples from '../../components/CabecalhoSimples';

import { Loader, Container, Content, Main, InputWrapper } from './styles';
import ClipLoader from "react-spinners/ClipLoader";
import QuadroApi from '../../services/Quadro/services';
import { useHistory } from 'react-router-dom';
import { toast, ToastContainer } from 'react-toastify';

const quadrApi = new QuadroApi();

function CriarQuadro(props) {

  const navegation = useHistory();
  const [loading, setLoading] = useState(false);
  const idLogin = props.location.state.idLogin;
  const nomeUsuario = props.location.state.nomeUsuario;
  const [nomeQuadro, setNomeQuadro] = useState('');
  const req = {
    idLogin,
    nomeQuadro
  }

  const cadastrarQuadrClick = async () => {
    try {
      setLoading(true);

      const resp = await quadrApi.cadastrarQuadrosAsync(req);

      navegation.push({
        pathname: '/Meus-quadros',
        state: {
          idLogin,
          nomeUsuario
        }
      })

      setLoading(false);

      return resp;
    } catch (e) {
      setLoading(false);
      toast.error(e.response.data.erro);
    }
  }

  return (
      <Container>
          <CabecalhoSimples />
          <Content>
              <h1>Criar novo quadro</h1>
              <Main>
                <InputWrapper>
                    <span>Nome do quadro</span>
                    <input type="text" placeholder="Nome do Quadro" onChange={(e) => {setNomeQuadro(e.target.value)}}/>
                  </InputWrapper>
                  <Loader>
                    <ClipLoader loading={loading}/>
                  </Loader>
                  <button onClick={cadastrarQuadrClick}>Criar Quadro</button>
              </Main>
          </Content>
          <ToastContainer />
      </Container>
  );
}

export default CriarQuadro;