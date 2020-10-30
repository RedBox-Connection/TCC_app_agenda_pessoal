import React from 'react';
import { Link } from 'react-router-dom';

import { Container, Content, InputWrapper, IntegrantesBox, Integrante } from './styles';

function ConfiguracaoTime() {

    function copiarTexto(){
        const input = document.getElementById("link-para-convite");
        input.select();
        document.execCommand('copy')
    }
  
  return (
      <Container>
          <h1>Configurar 'Nome do time'</h1>
          <Content>
              <InputWrapper>
                <span>Nome do time:</span>
                <input type="text" placeholder="Liga da justiça" />
              </InputWrapper>
              <InputWrapper>
                <span>Integrantes:</span>
                <IntegrantesBox>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 1</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 2</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 3</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 4</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 1</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 2</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 3</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 4</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 1</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 2</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 3</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 4</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 1</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 2</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 3</span>
                        </Integrante>
                    </Link>

                    <Link to="*">
                        <Integrante>
                            <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                            <span>Zezinho 4</span>
                        </Integrante>
                    </Link>

                </IntegrantesBox>
              </InputWrapper>

              <InputWrapper>
                <span>Descrição:</span>
                <textarea>bla bla bla bla bla bla bla bla bla bla bla bla</textarea>
              </InputWrapper>

              <InputWrapper>
                <span>Link para convite:</span>
                <div>
                    <input type="text" value="hgdfjkghkfdjgidf" id="link-para-convite"/>
                    <button onClick={copiarTexto}>Copiar</button>
                </div>
              </InputWrapper>
          </Content>
      </Container>
  );
}

export default ConfiguracaoTime;