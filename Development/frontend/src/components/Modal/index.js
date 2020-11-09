import React from 'react';

import { Calendar2Check, X, PencilSquare, Trash } from 'react-bootstrap-icons';

import TodoList from '../Checked-List/ToDoList';

import { ModalContent, Container, InputTitle, InputWrapper, InputDescription, End } from './styles';

const Modal = ({id = 'Modal', onClose = () => {}}) => {

    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }
    
    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container color="lightgreen">
                    
                    <button onClick={onClose}>
                        <X width="30px" height="30px"/>
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
                        <button> <Trash width="30px" height="50px"/> </button>
                        <button> <PencilSquare width="30px" height="50px"/> </button>
                        <button> <Calendar2Check width="30px" height="30px"/> </button>
                    </End>
                </Container>

            </ModalContent>
    ) 
}

export default Modal;