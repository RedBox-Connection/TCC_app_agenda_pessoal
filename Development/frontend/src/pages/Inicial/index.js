import React from 'react';

import hero from '../../images/hero.svg';
import notes from '../../images/notes.svg';

import { Container, Header, ButtonBox, FaixaUm , Apresentation , FaixaDois } from './styles';

function Inicial() {
  return (
      <Container>

        <Header>

            <h1>Organizer</h1>

            <ButtonBox>

                {/* <a href="#"> */}
                    Entrar
                {/* </a> */}

                {/* <a href="#"> */}
                    Cadastrar-se
                {/* </a> */}

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

      </Container>
  );
}

export default Inicial;