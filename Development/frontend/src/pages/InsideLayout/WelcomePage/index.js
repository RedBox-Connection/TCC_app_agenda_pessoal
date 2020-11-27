import React from 'react';
import { Link, useHistory } from 'react-router-dom';

import { Voltar, Container, Main } from './styles';

function WelcomePage(props) {

    const navegation = useHistory();

    const retornarClick = () => {
        navegation.push({
            pathname: '/Meus-quadros',
            state: {
                idLogin,
                nomeUsuario
            }
        });

        window.location.reload(false);
    }

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

            <Voltar>
                <button onClick={retornarClick}>
                    <p>
                    Voltar aos quadros
                    </p>
                </button>
            </Voltar>
          </Main>
      </Container>
    );
}

export default WelcomePage;