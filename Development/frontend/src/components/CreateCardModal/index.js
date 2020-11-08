import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

import { ModalContent, Container, InputTitle, InputWrapper, InputDescription, End } from './styles';
import { toast } from 'react-toastify';

import ApiCards from '../../services/Cards/services';
const apiCards = new ApiCards();

const Modal = ({id = 'Modal', onClose = () => {}}) => {

    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }

    //const navegation = useHistory();
    //const idQuadro = 1; 
    //const [nomeCartao,setNomeCartao] = useState('');
    //const [hora,setHora] = useState();
    //const [data,setData] = useState();
    //const cor = '#ffffff';
    //const [descricao,setDescricao] = useState('');
    //const req = {
        //NomeCartao,
        //Hora,
        //Data,
        //Descricao,
        //Cor,
        //IdQuadro
    //}

    //const criarCartaoTarefaClick = async() => {
        //try {
            //const resp = await apiCards.cadastrarCartaoTarefa(req);

            //navegation.push({
                //pathname: '/Inicial/Agenda',
                //state: {
                    //idQuadro
                //}
            //});

            //toast.dark("ebaaaa");
            
            //return resp;
        //} catch (e) {
            //toast.error(e.response.data.erro);
        //}
    //} 


    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container color="white">

                    <h3>Criar Tarefa</h3>
                    
                    <InputTitle>
                        <input type="text" 
                               placeholder="Tarefa"
                               //value={nomeCartao}
                               //onChange={e => setNomeCartao(e.target.value)}
                               />
                    </InputTitle>

                    <InputWrapper>
                        <input type="time" 
                               //value={hora}
                               //onChange={e => setHora(e.target.value)}
                               />

                        <input type="date" 
                               //value={data}
                               //onChange={e => setData(e.target.value)}
                               />

                        <button>Cor</button>
                    </InputWrapper>

                    <InputDescription>
                        <textarea placeholder="Descrição"
                                  //value={descricao}
                                  //onChange={e => setDescricao(e.target.value)}
                                  />
                    </InputDescription>

                    <End>
                        <button id="AddTarefa" //onClick={criarCartaoTarefaClick}
                        >Criar Tarefa</button>
                        <button onClick={onClose} id="Cancel">Cancelar</button>
                    </End>
                </Container>

            </ModalContent>
    ) 
}

export default Modal;