import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import { Container, Profile } from './styles';

import ApiCabecalhoLayout from '../../services/CabecalhoLayout/services';
import { toast, ToastContainer } from 'react-toastify';

const apiCabecalhoLayout = new ApiCabecalhoLayout();

function CabecalhoLayout(props) {

    const nomeUsuario = props.nomeUsuario;
    const descricao = props.quadroType;
    const idTipo = props.idTipo;
    const nomeQuadro = props.nomeQuadro;   
    const idLogin = props.idLogin;

    const [fotoPerfil, setFotoPerfil] = useState(apiCabecalhoLayout.buscarImagem(idLogin));

    const buscarFotoPerfil = () => {
        try {
            const resp = apiCabecalhoLayout.buscarImagem(idLogin);

            setFotoPerfil(resp);

            return resp;
        } catch (e) {
            toast.error(e.response.data.erro);
        }
    }

    useEffect(() => {
        buscarFotoPerfil()
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    // useEffect(()=> { fetchData(); }, [data])

    return (
        <Container>
            <h1>Organizer</h1>
            <ToastContainer/>
            <Profile>
                <Link to={{
                    pathname: '/inicial/Configuracoes',
                    state: {
                        nomeUsuario,
                        idLogin,
                        descricao,
                        idTipo,
                        nomeQuadro
                    }
                }}>{nomeUsuario}</Link>
                <img src={fotoPerfil} alt='fotoPerfil'/>
            </Profile>
        </Container>
        
    );
}

export default CabecalhoLayout;