import React, { useEffect, useState } from 'react';

import { Voltar, Loader, Container, Title, Content } from './styles';

import ApiAlterarQuadro from '../../../services/Quadro/Alterar/services';
import ApiQuadro from '../../../services/Quadro/services';
import { toast, ToastContainer } from 'react-toastify';
import { useHistory } from 'react-router-dom';
import { ClipLoader } from 'react-spinners';

const apiAlterarQuadro = new ApiAlterarQuadro();
const apiQuadro = new ApiQuadro();

function InfoQuadro(props) {

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

    const [loading, setLoading] = useState(false);
    const navegation = useHistory();    

    const idQuadro = props.location.state.idTipo;
    const idLogin = props.location.state.idLogin;
    const nomeUsuario = props.location.state.nomeUsuario;
    const descricao = props.location.state.quadroType;

    const [nomeQuadroAtual, setNomeQuadroAtual] = useState('');
    const [nomeQuadro, setNomeQuadro] = useState(nomeQuadroAtual);

    const reqQuadro = {
        idLogin,
        nomeQuadro
    }

    const alterarQuadro = async () => {
        try {
            setLoading(true);

            const resp = await apiAlterarQuadro.alterarNomeQuadro(reqQuadro, idQuadro);

            setLoading(false);

            navegation.push({
                pathname: '/Inicial',
                state: {
                    idLogin,
                    nomeUsuario,
                    descricao,
                    idTipo: idQuadro
                }
            })

            return resp;
        } catch (e) {
            setLoading(false);
            toast.error(e.response.data.erro);
        }
    }

    const deletarQuadro = async () => {
        try {
            setLoading(true);

            const resp = await apiAlterarQuadro.deletarQuadro(idQuadro);

            setLoading(false);

            navegation.push({
                pathname: '/Meus-quadros',
                state: {
                    idLogin,
                    nomeUsuario
                }
            });

            window.location.reload(false)

            return resp;
        } catch (e) {
            setLoading(false);
            toast.error(e.response.data.erro);
        }
    }

    const consultarInfoQuadro = async () => {
        try {
            const resp = await apiQuadro.consultarQuadroAsync(idQuadro);

            setNomeQuadroAtual(resp.nomeQuadro);

            return resp;
        } catch (e) {
            toast.error(e.response.data.erro);
        }
    }

    useEffect(() => {
        consultarInfoQuadro();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return(
        <Container>
            <Title>
                <h1>Alterando informações de {nomeQuadroAtual}</h1>
            </Title>
            <Content>
                <input type="text" placeholder={nomeQuadroAtual} onChange={(e) => {setNomeQuadro(e.target.value)}}/>
                <button id="Update" onClick={alterarQuadro}>Alterar Nome do Quadro</button>
                <button id="Delete" onClick={deletarQuadro}>Deletar Quadro</button>
                <Loader>
                    <ClipLoader loading={loading}/>
                </Loader>
            </Content>
            <ToastContainer />
            <Voltar>
                <button onClick={retornarClick}>
                    <p>
                        Voltar aos quadros
                    </p>
                </button>
            </Voltar>
        </Container>
    )
}
export default InfoQuadro;