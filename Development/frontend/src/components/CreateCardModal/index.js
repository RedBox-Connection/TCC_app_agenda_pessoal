import React, { useState } from 'react';

import { ModalContent, Container, InputTitle, InputWrapper, InputDescription, End } from './styles';

import { toast, ToastContainer } from 'react-toastify';

import ApiCards from '../../services/Cards/services';
import { useHistory } from 'react-router-dom';

const api = new ApiCards();

const Modal = ({id = 'Modal', onClose = () => {}}, props) => {

    //const [loading, setLoading] = false;

    const idQuadro = props.idQuadro;
    const [nomeCartao, setNomeCartao] = useState('');
    const [hora, setHora] = useState('');
    const [data, setData] = useState(''); 
    const [descricao, setDescricao] = useState('');
    const [cor, setCor] = useState();
    const req = {
        nomeCartao,
        hora,
        data,
        descricao,
        cor,
        idQuadro
    }

    const navegation = useHistory();

    const adicionarCardClick = async () =>{
        try {
            //setLoading(true);

            const resp = await api.cadastrarCartaoTarefa(req)

            navegation.push({
                pathname:"/Meus-quadros"
            })

            //setLoading(false);

            return resp;
        } catch (e) {
            //setLoading(false);
            toast.error(e.response.data.erro);
        }
    }


    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }

    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container color="white">

                    <h3>Criar Tarefa</h3>

                    <InputTitle>
                        <input type="text" placeholder="Tarefa" onChange={e => setNomeCartao(e.target.value)}/>
                    </InputTitle>

                    <InputWrapper>
                        <input type="time"onChange={e => setHora(e.target.value)}/>

                        <input type="date" onChange={e => setData(e.target.value)}/>
                    </InputWrapper>

                    <InputDescription>
                        <textarea placeholder="Descrição" onChange={e => setDescricao(e.target.value)}/>
                    </InputDescription>

                    <End>
                        <button id="AddTarefa" onClick={adicionarCardClick}>Criar Tarefa</button>
                        <button onClick={onClose} id="Cancel">Cancelar</button>
                    </End>
                </Container>

            </ModalContent>
    ) 
}

export default Modal;