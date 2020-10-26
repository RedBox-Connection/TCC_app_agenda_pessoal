import React, {useState} from 'react';

import CabecalhoLayout from '../../components/CabecalhoLayout';
import Card from '../../components/Card';
import MenuLateral from '../../components/MenuLateral';

import { CardContainer, Container, Main } from './styles';

export default function Agenda() {

    return(  
        <Container>
            <CabecalhoLayout />
            <Main>
                <MenuLateral />
                <CardContainer>
                    <Card />
                </CardContainer>
            </Main>

        </Container>
    )
}