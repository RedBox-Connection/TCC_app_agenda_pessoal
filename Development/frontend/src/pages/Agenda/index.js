import React from 'react';

import CabecalhoLayout from '../../components/CabecalhoLayout';
import MenuLateral from '../../components/MenuLateral';

import { Cards, Container, Main } from './styles';

export default function Agenda() {

    return(
        <Container>
            <CabecalhoLayout />
            <Main>
                <MenuLateral />
                <Cards>
                    
                </Cards>
            </Main>
        </Container>
    )
}