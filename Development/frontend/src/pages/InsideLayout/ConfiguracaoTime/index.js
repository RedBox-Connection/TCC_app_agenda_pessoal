import React from 'react';
import { Link } from 'react-router-dom';

import { Container, Content, InputWrapper, IntegrantesBox, Integrante, Save, Delete } from './styles';

import ApiTime from '../../../services/Time/services'
import { ToastContainer , toast} from 'react-toastify';

const api = new ApiTime();

function ConfiguracaoTime(props) {

    const idTime = props.location.state.idTipo;

    function copiarTexto(){
        const input = document.getElementById("link-para-convite");
        input.select();
        document.execCommand('copy')
    }
  
    const deletarTimeClick = async () => {
        try {
            const resp = await api.deletarTime(idTime);
            return resp;
        } catch (e) {
            toast.error(e.response.data.erro)
        }
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

              <Save>
                  Salvar alterações
              </Save>

              <button id="deletar" onClick={deletarTimeClick}>
                  Deletar time
              </button>
          </Content>
          <ToastContainer/>
      </Container>
  );
}

export default ConfiguracaoTime;