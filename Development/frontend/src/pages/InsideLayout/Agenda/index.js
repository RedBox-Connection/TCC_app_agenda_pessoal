import React from 'react';

import { DndProvider } from 'react-dnd';
import HTML5Backend from 'react-dnd-html5-backend';

import List from '../../../components/List';

import { CardContainer, Container } from './styles';

export default function Agenda() {

    return(  
        <DndProvider backend={HTML5Backend}>
            <Container>
                <CardContainer>
                    <List /> 
                    <List />
                    <List />
                    <List />
                    <List />
                </CardContainer>
            </Container>
        </DndProvider>
    )
}