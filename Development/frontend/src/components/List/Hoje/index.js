import React, { useState } from 'react';

import { Container } from "./styles";

import Card from '../../Card';

import ApiCards from '../../../services/Cards/services';
const apiCards = new ApiCards();

export default function ListHoje() {

    //const [cards,setCards] = useState([]);
    //const consultarCartaoTarefaClick = async() => {
        //const cct = await apiCards.consultarCartaoTarefa
        //setCards([...cct])
    //};

    return(
        <Container>
            <button >Consultar</button>

            <header>
                <h3>Hoje</h3>
            </header>

            <ul>
                <Card />
            </ul>
        </Container>
    )
}