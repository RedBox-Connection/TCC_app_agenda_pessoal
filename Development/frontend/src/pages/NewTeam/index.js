import React from 'react';
import { Link } from 'react-router-dom';


import CabecalhoSimples from '../../components/CabecalhoSimples';

import { Container, Content, InputBox, InputWrapper, ButtonBox } from './styles';

// LinkWrapper

function NewTeam() {

  // function copiarTexto(){
  //     const input = document.getElementById("link-convite");
  //     input.select();
  //     document.execCommand('copy')
  // }

  return (
      <Container>
          <CabecalhoSimples />
          <Content>
              <h1>Criar um novo time</h1>

              <InputBox>
                <InputWrapper>
                  <span>Nome do time</span>
                  <input type="text" placeholder="Liga da justiça"/>
                </InputWrapper>
                <InputWrapper>
                  <span>Descrição</span>
                  <textarea placeholder="Os maiores heróis da terra, designados a proteger os fracos e combater os vilões que juram destruir a terra ">
                  </textarea>
                </InputWrapper>
                {/* <LinkWrapper>
                  <span>Link para convite</span>
                  <div>
                    <input type="text" value="o link do cara aqui" id="link-convite"/>
                    <button onClick={copiarTexto}>Copiar</button>
                  </div>
                </LinkWrapper> */}
              </InputBox>

              <ButtonBox>
                  <button>Criar time</button>
                  <Link to="/Meus-quadros">Cancelar</Link>
              </ButtonBox>

          </Content>
      </Container>
  );
}

export default NewTeam;