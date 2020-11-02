import React from 'react';

import TodoList from '../Checked-List/ToDoList';

import { Check, JournalX, Trash } from 'react-bootstrap-icons'

import { ModalContent, Comment, Container, InputTitle, InputWrapper, InputDescription, End } from './styles';

const Modal = ({id = 'Modal', onClose = () => {}}) => {

    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }

    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container color="lightskyblue">
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

                    <Comment>
                        <input type="text" placeholder="Comentário" />
                        <button>Comentar</button>
                    </Comment>

                    <End>
                        <button> <Trash width="30px" height="50px"/> </button>
                        <button> <Check width="30px" height="30px"/> </button>
                    </End>
                </Container>

            </ModalContent>
    ) 
}

export default Modal;