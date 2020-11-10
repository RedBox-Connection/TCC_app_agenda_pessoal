import React, { useEffect, useState } from 'react';
import { Link, useHistory } from 'react-router-dom';

import { Container, Content, InputWrapper, IntegrantesBox, Integrante } from './styles';

import ApiTime from '../../../services/Time/services'
import { ToastContainer , toast} from 'react-toastify';

const api = new ApiTime();

function ConfiguracaoTime(props) {
    
    console.log(props)

    const navigation = useHistory();

    const idTime = props.location.state.idTipo;
    const idLogin = props.location.state.idLogin;
    const nomeUsuario = props.location.state.nomeUsuario;

    const [descricaoTime, setDescricaoTime] = useState(props.location.state.descricaoTime);
    const [nomeTime, setNomeTime] = useState(props.location.state.nomeTime);

    const reqTime={
        idLogin,
        descricaoTime,
        nomeTime
    }

    console.log(reqTime);

    function copiarTexto(){
        const input = document.getElementById("link-para-convite");
        input.select();
        document.execCommand('copy')
    }
  
    const consultarTime = async () => {
        const resp = await api.consultarTimesAsync(idLogin);

        setNomeTime(resp.nomeTime);
        setDescricaoTime(resp.descricaoTime);

        return resp;
    }

    useEffect(() => {
        consultarTime();
      // eslint-disable-next-line react-hooks/exhaustive-deps
      }, [])

    const deletarTimeClick = async () => {
        try {
            const resp = await api.deletarTime(idTime);
            
            navigation.push({
                pathname:"/Meus-quadros", 
                state:{
                    idLogin ,
                    nomeUsuario
                }
            })

            window.location.reload(false);

            return resp;
        } catch (e) {
            toast.error(e.response.data.erro)
        }
    }

    const alterarTimeClick = async () => {
        try {
            const resp = await api.alterarTime(reqTime);
            return resp;
        } catch (e) {
            toast.error(e.response.data.erro)
        }
    }

  return (
      <Container>
          <h1>Configurar {nomeTime}</h1>
          <Content>
              <InputWrapper>
                <span>Nome do time:</span>
                <input type="text" value={nomeTime}  onChange={(e) => {setNomeTime(e.target.value)}} />
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

                </IntegrantesBox>
              </InputWrapper>

              <InputWrapper>
                <span>Descrição:</span>
                <textarea onChange={(e) => {setDescricaoTime(e.target.value)}}>{descricaoTime}</textarea>
              </InputWrapper>

              <InputWrapper>
                <span>Link para convite:</span>
                <div>
                    <input type="text" value="hgdfjkghkfdjgidf" id="link-para-convite"/>
                    <button onClick={copiarTexto}>Copiar</button>
                </div>
              </InputWrapper>

              <button id="salvar" onClick={alterarTimeClick}>
                  Salvar alterações
              </button>

              <button id="deletar" onClick={deletarTimeClick}>
                  Deletar time
              </button>
          </Content>
          <ToastContainer/>
      </Container>
  );
}

export default ConfiguracaoTime;