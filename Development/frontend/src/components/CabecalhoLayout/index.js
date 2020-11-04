import React from 'react';
import { Link } from 'react-router-dom';

import { Container, Profile } from './styles';

import ApiCabecalhoLayout from '../../services/CabecalhoLayout/services';

const apiCabecalhoLayout = new ApiCabecalhoLayout();

function CabecalhoLayout(props) {

    const nome = props.nomeUsuario;

    return (
        <Container>
            <h1>Organizer</h1>
            <Profile>
                <Link to="/inicial/Configurações">{nome}</Link>
                <img src={apiCabecalhoLayout.buscarImagem("user.png")} alt='fotoPerfil'/>
            </Profile>
        </Container>
    );
}

export default CabecalhoLayout;