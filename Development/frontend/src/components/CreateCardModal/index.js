import React from 'react';

import { ModalContent, Container, InputTitle, InputWrapper, InputDescription, End } from './styles';

const Modal = ({id = 'Modal', onClose = () => {}}) => {

    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }

    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container color="white">

                    <h3>Criar Tarefa</h3>
                    
                    <InputTitle>
                        <input type="text" placeholder="Tarefa"/>
                    </InputTitle>

                    <InputWrapper>
                        <input type="time"/>

                        <input type="date"/>

                        <button>Cor</button>
                    </InputWrapper>

                    <InputDescription>
                        <textarea placeholder="Descrição"/>
                    </InputDescription>

                    <End>
                        <button id="AddTarefa">Criar Tarefa</button>
                        <button onClick={onClose} id="Cancel">Cancelar</button>
                    </End>
                </Container>

            </ModalContent>
    ) 
}

export default Modal;