import React, { useEffect, useState } from 'react';
import { Link, useHistory } from 'react-router-dom';

import { Loader, Container, Content, InputWrapper, IntegrantesBox, Integrante } from './styles';

import ApiTime from '../../../services/Time/services'
import { ToastContainer , toast} from 'react-toastify';

import ApiTimeIntegrante from '../../../services/Time/Integrantes/services';
import FotoApi from '../../../services/CabecalhoLayout/services';
import { ClipLoader } from 'react-spinners';

const apiIntegrante = new ApiTimeIntegrante();
const api = new ApiTime();
const apiFoto = new FotoApi();

function ConfiguracaoTime(props) {

    const navigation = useHistory();

    const [loading, setLoading] = useState(false);

    const descricao = props.location.state.quadroType;
    const idTime = props.location.state.idTipo;
    const [nomeTime, setNomeTime] = useState(props.location.state.nomeQuadro);
    const idLogin = props.location.state.idLogin;
    const nomeUsuario = props.location.state.nomeUsuario;
    const [descricaoTime, setDescricaoTime] = useState('');

    const [nomeTimeNovo, setNomeTimeNovo] = useState('');
    const [novoDescricaoTime, setNovoDescricaoTime] = useState('');

    const [integrantes, setIntegrantes] = useState([]);

    const reqTime={
        idLogin,
        nomeTime: nomeTimeNovo,
        descricaoTime: novoDescricaoTime
    }

    console.log(reqTime);

    function copiarTexto(){
        const input = document.getElementById("link-para-convite");
        input.select();
        document.execCommand('copy')
    }
  
    const consultarTime = async () => {
        try {
            const resp = await api.consultarTimeAsync(idTime);

            setNomeTime(resp.nomeTime);
            setDescricaoTime(resp.descricao);
            setNomeTimeNovo(nomeTime);
            setNovoDescricaoTime(descricaoTime);

            return resp;
        } catch(e) {
            toast.error(e.response.data.erro);
        }
    }

    const consultarIntegrantes = async () => {
        try {
            const resp = await apiIntegrante.consultarTimeIntegrantesAsync(idTime);

            setIntegrantes(resp.integrantes);

            return resp;
        } catch(e) {
            toast.error(e.response.data.erro);
        }
    }

    useEffect(() => {
        consultarTime();
        consultarIntegrantes();
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
            console.log(reqTime)

            setLoading(true);

            const resp = await api.alterarTime(reqTime, idTime);

            setLoading(false);

            navigation.push({
                pathname: '/Inicial',
                state: {
                    idLogin,
                    nomeUsuario,
                    descricao,
                    idTipo: idTime
                }
            });

            return resp;


        } catch (e) {
            setLoading(false);
            toast.error(e.response.data.erro)
        }
    }

  return (
      <Container>
          <h1>Configurar {nomeTime}</h1>
          <Content>
              <InputWrapper>
                <span>Nome do time:</span>
                <input type="text" placeholder={nomeTime}  onChange={(e) => {setNomeTimeNovo(e.target.value)}} />
              </InputWrapper>
              <InputWrapper>
                <span>Integrantes:</span>
                <IntegrantesBox>

                    {integrantes.map(integrante => 
                        <Integrante key={integrante.idIntegrante}>
                            <img src={apiFoto.buscarImagem(integrante.idLogin)} alt="userphoto" draggable={false}/>
                            <span>{integrante.nomeUsuario}</span>
                        </Integrante>
                    )}

                </IntegrantesBox>
              </InputWrapper>

              <InputWrapper>
                <span>Descrição:</span>
                <textarea placeholder={descricaoTime} onChange={(e) => {setNovoDescricaoTime(e.target.value)}}></textarea>
              </InputWrapper>

              <InputWrapper>
                <span>Link para convite:</span>
                <div>
                    <input type="text" value="link/em/desenvolvimento" id="link-para-convite"/>
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
          <Loader>
              <ClipLoader loading={loading}/>
          </Loader>
      </Container>
  );
}

export default ConfiguracaoTime;