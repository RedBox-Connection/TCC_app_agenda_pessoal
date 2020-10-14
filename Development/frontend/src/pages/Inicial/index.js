import React from 'react';
import { Link } from 'react-router-dom';

import hero from '../../images/hero.svg';
import notes from '../../images/notes.svg';

import { GeoAlt } from 'react-bootstrap-icons';

import {Container, Header, ButtonBox, FaixaUm , Apresentation , FaixaDois , Footer, Location } from './styles';

function Inicial() {
  return (
      <Container>

        <Header>

            <h1>Organizer</h1>

            <ButtonBox>

                <Link to="/Criar-uma-conta">
                    Entrar
                </Link>

                <Link to="/Criar-uma-conta">
                    Cadastrar-se
                </Link>

            </ButtonBox>

        </Header>

        <FaixaUm>

            <img src={hero} alt="heroimage" />

            <Apresentation>
                <h1>Agenda Pessoal</h1>
                <p>O melhor jeito de se organizar</p>
            </Apresentation>


        </FaixaUm>

        <FaixaDois>
            <img src={notes} alt="notesimage" />

            <Apresentation>

                <p>
                    O jeito mais fácil de definir lembretes, tarefas e obrigações
                </p>

                {/* {/* <a href="#"> Começar agora </a> */}
            </Apresentation>

        </FaixaDois>

        <Footer>
            <span>Copyrigth &copy; by RedBox Connection</span>

            <Location>
                <GeoAlt /> São Paulo, Brasil
            </Location>
        </Footer>

      </Container>
  );
}

export default Inicial;