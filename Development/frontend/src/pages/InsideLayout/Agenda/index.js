import React from 'react';

import List from '../../../components/List';

import { CardContainer, Container } from './styles';

export default function Agenda() {

    return(  
            <Container>
                <CardContainer>
                    <List />
                    <List />
                    <List />
                    <List />
                </CardContainer>
            </Container>
    )
}