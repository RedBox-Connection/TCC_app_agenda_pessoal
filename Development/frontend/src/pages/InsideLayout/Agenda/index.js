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
import { CardContainer, Container } from './styles';
import { Calendar2Plus } from 'react-bootstrap-icons';

export default function Agenda() {

    const [isModalVisible,setIsModalVisible] = useState(false);

    return(  
        <DndProvider backend={HTML5Backend}> 
            <Container>
                <CardContainer>
                    <button id="Add" type="button" onClick={() => setIsModalVisible(true)}>
                        <Calendar2Plus height="25px" width="25px"/>
                    </button>

                    <ListHoje />
                    <ListAmanha />
                    <ListDepoisDeAmanha />
                    <ListFuturamente />

                    {isModalVisible ? <CreateCardModal onClose={() => setIsModalVisible(false)}/> : null}
                </CardContainer>
            </Container>
        </DndProvider>
    )
}