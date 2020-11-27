//Import React
import React, { useState } from 'react';

//Import Modal
import CreateCardModal from '../../../components/CreateCardModal';

//Import Drag N' Drop
import { DndProvider } from 'react-dnd';
import { HTML5Backend } from 'react-dnd-html5-backend';

//Import Components
import ListHoje from '../../../components/List/Hoje';
import ListAmanha from '../../../components/List/Amanha';
import ListDepoisDeAmanha from '../../../components/List/DepoisDeAmanha';
import ListFuturamente from '../../../components/List/Futuramente';

//Import Styles
import { Voltar, CardContainer, Container } from './styles';
import { Calendar2Plus } from 'react-bootstrap-icons';
import { ToastContainer } from 'react-toastify';
import { useHistory } from 'react-router-dom';

export default function Agenda(props) {

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

    const [isModalVisible,setIsModalVisible] = useState(false);

    return(
        <DndProvider backend={HTML5Backend}> 
            <Container>
                <CardContainer>
                    <button id="Add" type="button" onClick={() => {setIsModalVisible(true); }}>
                        <Calendar2Plus height="25px" width="25px"/>
                    </button>

                    <ListHoje idQuadro={idQuadro}/>
                    <ListAmanha idQuadro={idQuadro}/>
                    <ListDepoisDeAmanha idQuadro={idQuadro}/>
                    <ListFuturamente idQuadro={idQuadro}/>

                    {isModalVisible ? <CreateCardModal idQuadro={idQuadro} onClose={() => setIsModalVisible(false)}/> : null}
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
        </DndProvider>
    )
}