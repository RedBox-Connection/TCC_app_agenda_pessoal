import React, { useEffect, useRef, useState } from 'react';
import { Link } from 'react-router-dom';

import CabecalhoSimples from '../../components/CabecalhoSimples';
import QuadroButton from '../../components/QuadroButton';

import { Container, Content, QuadrosContainer, AddTeam, AddBoard } from './styles';

import ApiQuadro from '../../services/Quadro/services';
import { toast } from 'react-toastify';
import LoadingBar from 'react-top-loading-bar'
const apiQuadro = new ApiQuadro();

function EscolherQuadro(props) {

  const ref = useRef(null);

  const idLogin = props.location.state.idLogin;
  const nomeUsuario = props.location.state.nomeUsuario;

  const [quadros, setQuadros] = useState([]);

  const consultarQuadrosClick = async () => {
    try {
      ref.current.continuousStart();

      const resp = await apiQuadro.consultarQuadrosAsync(idLogin);

      console.log(resp);

      setQuadros([...resp]);
      
      ref.current.complete();

      return resp;
    } catch (e) {
      console.log(e.response);
      ref.current.complete();
      toast.error(e.response.data.erro);
    }
  }

  useEffect(() => {
    consultarQuadrosClick();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  return (
      <Container>
        <LoadingBar color="#489FB5" height={5} ref={ref}/>
          <CabecalhoSimples />
          <Content>
              <h1>Olá {nomeUsuario}, escolha o quadro que deseja entrar:</h1>
              <QuadrosContainer>
                <Link to="/Novo-time" >
                  <AddTeam>
                       Criar um time
                  </AddTeam>
                </Link>
                  {quadros.map(quadro => (
                     <QuadroButton key={quadro.idQuadro} nomeQuadro={quadro.nomeQuadro} nomeUsuario={nomeUsuario}/>
                  ))}
                <Link to="/Novo-quadro">
                  <AddBoard>
                       Criar um quadro
                  </AddBoard>
                </Link>
              </QuadrosContainer>
          </Content>
      </Container>
  );
}

export default EscolherQuadro;