import React from 'react';

import { Container, Title, Content } from './styles';

function InfoQuadro() {

    return(
        <Container>
            <Title>
                <h1>Alterar Nome do Quadro</h1>
            </Title>
            <Content>
                <input type="text" placeholder="'Nome do quadro'"/>
                <button id="Update">Alterar Nome do Quadro</button>
                <button id="Delete">Deletar Quadro</button>
            </Content>
        </Container>
    )
}
export default InfoQuadro;