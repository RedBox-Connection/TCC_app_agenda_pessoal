import React, { useEffect, useRef, useState } from 'react';
import { Link, useHistory } from 'react-router-dom';

import CabecalhoSimples from '../../components/CabecalhoSimples';
import QuadroButton from '../../components/QuadroButton';

import { Container, Content, QuadrosContainer, AddTeam } from './styles';

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
  }, [])

  return (
      <Container>
        <LoadingBar ref={ref}/>
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
                     <QuadroButton key={quadro.idQuadro} nome={quadro.nomeQuadro}/>
                  ))}
              </QuadrosContainer>
          </Content>
      </Container>
  );
}

export default EscolherQuadro;