import React from 'react';

import { Calendar2Check, X, PencilSquare, Trash } from 'react-bootstrap-icons';

//import ListTodoList from '../Checked-List/List-TodoList';
//Fazer o Check List

import { ModalContent, Container, InputTitle, InputWrapper, InputDescription, End } from './styles';

const Modal = ({id = 'Modal', onClose = () => {}}) => {

    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }
    
    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container>
                    
                    <button onClick={onClose}>
                        <X width="30px" height="30px"/>
                    </button>
                    
                    <InputTitle>
                        <input type="text" placeholder="Tarefa"/>
                    </InputTitle>

                    <InputWrapper>
                        <input type="time" />
                        <input type="date" />
                    </InputWrapper>

                    <InputDescription>
                        <textarea placeholder="Descrição"/>
                    </InputDescription>

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