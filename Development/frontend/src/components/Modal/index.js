import React from 'react';

import { Check, JournalX, Trash } from 'react-bootstrap-icons'

import { ModalContent, Container, Color, InputTitle, InputWrapper, InputDescription, CheckBox, End } from './styles';

const Modal = ({id = 'Modal', onClose = () => {}}) => {

    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }

    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container>
                    <Color />
                    <button onClick={onClose}>
                        <JournalX width="30px" height="30px"/>
                    </button>
                    <InputTitle>
                        <input type="text" placeholder="Limpar a Bat caverna"/>
                    </InputTitle>

                    <InputWrapper>
                        <input type="time" />
                        <input type="date" />
                        <button>Cor</button>
                    </InputWrapper>

                    <InputDescription>
                        <label>Decrição:</label>
                        <input type="text" placeholder="Deixar bem limpo."/>
                    </InputDescription>

                    <CheckBox>
                        <button>Adicionar Item</button>
                    </CheckBox>

                    <End>
                        <button> <Trash width="30px" height="50px"/> </button>
                        <button> <Check width="30px" height="30px"/> </button>
                    </End>
                </Container>

            </ModalContent>
    ) 
}

export default Modal;