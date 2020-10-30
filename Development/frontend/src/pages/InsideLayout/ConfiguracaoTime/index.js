import React from 'react';

import { Container, Content, InputWrapper, IntegrantesBox, Integrante } from './styles';

function ConfiguracaoTime() {
  return (
      <Container>
          <h1>Configurar 'Nome do time'</h1>
          <Content>
              <InputWrapper>
                <span>Nome do time</span>
                <input type="text" placeholder="Liga da justiça" />
              </InputWrapper>
              <InputWrapper>
                <span>Integrantes</span>
                <IntegrantesBox>

                    <Integrante>
                      <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                      <span>Zezinho 1</span>
                    </Integrante>

                    <Integrante>
                      <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                      <span>Zezinho 2</span>
                    </Integrante>

                    <Integrante>
                      <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                      <span>Zezinho 3</span>
                    </Integrante>

                    <Integrante>
                      <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                      <span>Zezinho 4</span>
                    </Integrante>

                </IntegrantesBox>
              </InputWrapper>

              <InputWrapper>
                <span>Descrição</span>
                <textarea>bla bla bla bla bla bla bla bla bla bla bla bla</textarea>
              </InputWrapper>

              <InputWrapper>
                <span>Link para convite</span>
                <div>
                    <input type="text" value="hgdfjkghkfdjgidf" />
                    <button>Copiar</button>
                </div>
              </InputWrapper>
          </Content>
      </Container>
  );
}

export default ConfiguracaoTime;