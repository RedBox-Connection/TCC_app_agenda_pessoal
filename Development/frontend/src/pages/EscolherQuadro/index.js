import React, { useEffect, useRef, useState } from 'react';
import { Link } from 'react-router-dom';

import CabecalhoSimples from '../../components/CabecalhoSimples';
import QuadroButton from '../../components/QuadroButton';

import { Divider, Container, Content, QuadrosContainer, AddTeam, AddBoard } from './styles';

import ApiQuadro from '../../services/Quadro/services';
import ApiTime from '../../services/Time/services';
import { toast, ToastContainer } from 'react-toastify';
import LoadingBar from 'react-top-loading-bar'
const apiQuadro = new ApiQuadro();
const apiTime = new ApiTime();

function EscolherQuadro(props) {

  const ref = useRef(null);

  const idLogin = props.location.state.idLogin;
  const nomeUsuario = props.location.state.nomeUsuario;

  const [quadros, setQuadros] = useState([]);
  const [times, setTimes] = useState([]);

  const consultarQuadrosClick = async () => {
    try {
      ref.current.continuousStart();

      const respQuadros = await apiQuadro.consultarQuadrosAsync(idLogin);

      setQuadros([...respQuadros]);

      ref.current.complete();

      return {respQuadros};
    } catch (e) {
      ref.current.complete();
      toast.error(e.response.data.erro);
    }
  }

  const consultarTimesClick = async () => {
    try {
      ref.current.continuousStart();

      const respTimes = await apiTime.consultarTimesAsync(idLogin);

      setTimes([...respTimes]);

      ref.current.complete();

      return respTimes;
    } catch (e) {
      ref.current.complete();
      if(quadros === []) {
        toast.error(e.response.data.erro);
      }
    }
  }

  const consultarTudoClick = async () => {
    consultarQuadrosClick();
    consultarTimesClick();
  }

  useEffect(() => {
    consultarTudoClick();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  return (
      <Container>
        <LoadingBar color="#489FB5" height={5} ref={ref}/>
          <CabecalhoSimples />
          <Content>
              <h1>Olá {nomeUsuario}, escolha o quadro que deseja entrar:</h1>
              <QuadrosContainer>
                <Link to={{
                  pathname: "/Novo-quadro",
                  state: {
                    idLogin,
                    nomeUsuario
                  }  
                }}>
                  <AddBoard>
                       Criar um quadro
                  </AddBoard>
                </Link>
                {quadros.map(quadro => (
                    <QuadroButton 
                      key={quadro.nomeQuadro}
                      descricao={quadro.descricao} 
                      nomeQuadro={quadro.nomeQuadro} 
                      nomeUsuario={nomeUsuario}
                      idLogin={idLogin} idTipo={quadro.idQuadro}/>
                ))}
                <Divider />
                <Link to={{
                  pathname: "/Novo-time",
                  state: {
                    idLogin,
                    nomeUsuario
                  }  
                }}>
                  <AddTeam>
                       Criar um time
                  </AddTeam>
                </Link>
                {times.map(time => (
                     <QuadroButton 
                        key={time.nomeTime}
                        descricao={time.descricao} 
                        nomeQuadro={time.nomeTime} 
                        nomeUsuario={nomeUsuario}
                        idLogin={idLogin} idTipo={time.idTime}/>
                  ))}
              </QuadrosContainer>
          </Content>
          <ToastContainer />
      </Container>
  );
}

export default EscolherQuadro;