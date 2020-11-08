import React, { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { ClipLoader } from 'react-spinners';
import { toast, ToastContainer } from 'react-toastify';

import CabecalhoSimples from '../../components/CabecalhoSimples';

import { Loader, Container, Content, InputBox, InputWrapper, ButtonBox } from './styles';

import TimeApi from '../../services/Time/services';

const apiTime = new TimeApi();

function NewTeam(props) {

  const navegation = useHistory();

  const idLogin = props.location.state.idLogin;
  const nomeUsuario = props.location.state.nomeUsuario;

  const [loading, setLoading] = useState(false);

  const [nomeTime, setNomeTime] = useState('');
  const [descricaoTime, setDescricaoTime] = useState('');

  const req = {
    idLogin,
    nomeTime,
    descricaoTime
  }

  const cadastrarTimeClick = async () => {
    try {
      setLoading(true);

      const resp = await apiTime.cadastrarTimeAsync(req);

      setLoading(false);

      navegation.push({
        pathname: '/Meus-quadros',
        state: {
          idLogin,
          nomeUsuario
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
          <CabecalhoSimples />
          <Content>
              <h1>Criar um novo time</h1>

              <InputBox>
                <InputWrapper>
                  <span>Nome do time</span>
                  <input type="text" placeholder="Liga da justiça" onChange={(e) => {setNomeTime(e.target.value)}}/>
                </InputWrapper>
                <InputWrapper>
                  <span>Descrição</span>
                  <textarea placeholder="Os maiores heróis da terra, designados a proteger os fracos e combater os vilões que juram destruir a terra"
                            onChange={(e) => {setDescricaoTime(e.target.value)}}>
                  </textarea>
                </InputWrapper>
              </InputBox>

              <ButtonBox>
                  <button onClick={cadastrarTimeClick}>Criar time</button>
                  <Link to={
                    {
                      pathname: "/Meus-quadros",
                      state: {
                        idLogin,
                        nomeUsuario
                      }
                    }
                  }>Cancelar</Link>
              </ButtonBox>

              <Loader>
                <ClipLoader loading={loading} />
              </Loader>

              <ToastContainer />
          </Content>
      </Container>
  );
}

export default NewTeam;