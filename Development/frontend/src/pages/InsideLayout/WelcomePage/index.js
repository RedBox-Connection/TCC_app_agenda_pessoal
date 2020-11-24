import React from 'react';
import { Link } from 'react-router-dom';

import { Container, Main } from './styles';

function WelcomePage(props) {

    const nomeUsuario = props.location.state.nomeUsuario;
    const quadroType = props.location.state.quadroType;
    const idTipo = props.location.state.idTipo;
    const nomeQuadro = props.location.state.nomeQuadro;   
    const idLogin = props.location.state.idLogin;
  return(
      <Container>
          <Main>
              <h1>Bem-vindo(a) ao Organizer :)</h1>
              <p>Clique em <Link to={
                        {
                            pathname: "/Inicial/Agenda",
                            state: {
                                idTipo,
                                nomeQuadro,
                                idLogin,
                                nomeUsuario,
                                quadroType
                            }
                        }
                    }>Agenda</Link> para continuar e deixar o seu dia mais fácil!</p>
          </Main>
      </Container>
    );
}

export default WelcomePage;