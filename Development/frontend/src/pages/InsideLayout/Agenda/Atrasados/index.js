import React from 'react';

import { Voltar, CardContainer, Container } from './styles';
import Card from '../../../../components/Card';

import cardApi from '../../../../services/Cards/services';
import { toast, ToastContainer } from 'react-toastify';
import { useState } from 'react';
import { useEffect } from 'react';
import { useHistory } from 'react-router-dom';

const apiCard = new cardApi();

export default function Atrasados(props) {

  const idLogin = props.location.state.idLogin;
  const nomeUsuario = props.location.state.nomeUsuario;

  const navegation = useHistory();

  const retornarClick = () => {
      navegation.push({
          pathname: '/Meus-quadros',
          state: {
              idLogin,
              nomeUsuario
          }
      });

      window.location.reload(false);
  }

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

    return(
        <Container>
            <h1>Tarefas Atrasadas</h1>
            <CardContainer>
                <ul>
                    {cards.filter(card => card.status === 'Atrasado').map(card => 
                        <li key={card.idCard}>
                            <Card card={card} idQuadro={idQuadro}/>
                        </li>
                    )}
                </ul>
            </CardContainer>
            <ToastContainer />
            <Voltar>
                <button onClick={retornarClick}>
                    <p>
                    Voltar aos quadros
                    </p>
                </button>
            </Voltar>
        </Container>
    )
}