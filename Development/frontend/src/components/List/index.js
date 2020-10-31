import React from 'react';

import { JournalPlus } from 'react-bootstrap-icons';
import { Container } from "./styles";

import Card from '../Card';
import TeamCard from '../TeamCard';

export default function List() {

    return(
        <Container>
            <header>
                <h3>Tarefas</h3>
                <button id="Add" type="button">
                    <JournalPlus height="25px" width="25px"/>
                </button>
            </header>

            <ul>
                <Card />
                <TeamCard />
                <Card />
                <TeamCard />
            </ul>
        </Container>
    )
}