import React, { useState } from 'react';

import { Check, JournalX, Pen, Trash } from 'react-bootstrap-icons';

import TodoList from '../Checked-List/ToDoList';

import { ModalContent, Container, InputTitle, InputWrapper, InputDescription, End } from './styles';

import ApiCards from '../../services/Cards/services';
const apiCards = new ApiCards();

const Modal = ({id = 'Modal', onClose = () => {}}) => {

    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }
    //const [registros, setRegistros] = useState([]);

    //const deletarCartaoTarefaClick = async (req) => {
        //const dct = await apiCards.deletarCartaoTarefa(req)
        //const cct = await apiCards.consultarCartaoTarefa()
        //setRegistros([...cct])
        
    //}

    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container color="lightgreen">
                    
                    <button onClick={onClose}>
                        <JournalX width="30px" height="30px"/>
                    </button>
                    <InputTitle>
                        <input type="text" placeholder="Tarefa"/>
                    </InputTitle>

                    <InputWrapper>
                        <input type="time" />
                        <input type="date" />
                        <button>Cor</button>
                    </InputWrapper>

                    <InputDescription>
                        <textarea placeholder="Descrição"/>
                    </InputDescription>

                    <TodoList />

                    <End>
                        <button //onClick={() => deletarCartaoTarefaClick}
                        > <Trash width="30px" height="50px"/> </button>
                        <button> <Pen width="30px" height="50px"/> </button>
                        <button> <Check width="30px" height="30px"/> </button>
                    </End>
                </Container>

            </ModalContent>
    ) 
}

export default Modal;