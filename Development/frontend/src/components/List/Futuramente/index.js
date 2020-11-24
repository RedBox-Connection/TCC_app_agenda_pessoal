import React, { useEffect, useState } from 'react';

import { Container } from "./styles";

import Card from '../../Card';

import cardApi from '../../../services/Cards/services';
import { toast } from 'react-toastify';

const apiCard = new cardApi();

export default function ListFuturamente(props) {
    const idQuadro = props.idQuadro;

    const [cards, setCards] = useState([]);

    const consultarClick = async () => {
        try {
            const resp = await apiCard.consultarCartaoTarefa(idQuadro);

            setCards([...resp]);

            return resp;
        } catch (e) {
            toast.error(e.response.data.erro);
        }
    }

    useEffect(() => {
        consultarClick();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return(
        <Container>
            <header>
                <h3>Futuramente</h3>
            </header>

            <ul>
                {cards.filter(card => card.status === 'Aguardando' && card.statusDia === 'futuramente').map(card => 
                    <li key={card.idCard}>
                        <Card card={card} idQuadro={idQuadro}/>
                    </li>
                )}
            </ul>
        </Container>
    )
}