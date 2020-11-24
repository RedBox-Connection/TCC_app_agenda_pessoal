import React from 'react';

import { CardContainer, Container } from './styles';
import Card from '../../../../components/Card';

import cardApi from '../../../../services/Cards/services';
import { toast, ToastContainer } from 'react-toastify';
import { useState } from 'react';
import { useEffect } from 'react';

const apiCard = new cardApi();

function Feitos(props) {

  const idQuadro = props.location.state.idTipo;

  const [cards, setCards] = useState([]);

  const consultarFeitos = async () => {
    try {
      const resp = await apiCard.consultarCartaoTarefa(idQuadro);

      setCards([...resp]);

      return resp;
    } catch (e) {
      console.log(e);
      toast.error(e.response.data.erro);
    }
  }

  useEffect(() => {
    consultarFeitos();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  return (
      <Container>
        <h1>Tarefas Feitas</h1>
        <CardContainer>
          <ul>
            {cards.filter(card => card.status === 'Concluido').map(card => 
                <li key={card.idCard}>
                    <Card card={card} idQuadro={idQuadro}/>
                </li>
            )}
          </ul>
        </CardContainer>
        <ToastContainer />
      </Container>
  );
}

export default Feitos;