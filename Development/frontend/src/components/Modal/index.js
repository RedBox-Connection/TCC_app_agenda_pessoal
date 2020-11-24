import React, { useState } from 'react';

import { Calendar2Check, X, PencilSquare, Trash } from 'react-bootstrap-icons';
import { toast, ToastContainer } from 'react-toastify';
import ClipLoader from "react-spinners/ClipLoader";

//import ListTodoList from '../Checked-List/List-TodoList';
//Fazer o Check List

import { Loader, ModalContent, Container, InputTitle, InputWrapper, InputDescription, End } from './styles';

import cardApi from '../../services/Cards/services';

const apiCard = new cardApi();

const Modal = (props, {id = 'Modal', onClose = () => {}}) => {

    const [loading, setLoading] = useState(false);

    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }

    const cardInfo = props.card;
    const idQuadro = props.idQuadro;
    const idCartao = cardInfo.idCartao;

    const [hora, setHora] = useState(cardInfo.hora);
    const [data, setData] = useState(cardInfo.dataCartao.substr(0, 10));
    const [nomeCartao, setNomeCartao] = useState(cardInfo.nomeCartao);
    const [descricao, setDescricao] = useState(cardInfo.descricao);
    const [cor, setCor] = useState('black');
    const [status, setStatus] = useState(cardInfo.status);

    const req = {
        idCartao,
        nomeCartao,
        hora,
        data,
        descricao,
        cor,
        idQuadro,
        status
    }

    const reqConcluir = {
        idCartao,
        nomeCartao,
        hora,
        data,
        descricao,
        cor,
        idQuadro,
        status: 'Concluido'
    }

    const alterarInfoClick = async () => {
        try {
            setLoading(true);

            const resp = await apiCard.alterarCartaoTarefa(req);

            setLoading(false);

            toast.success('Informações alteradas com sucesso!');

            return resp;
        } catch (e) {
            setLoading(false);
            toast.error(e.response.data.erro);
        }
    }
    const concluirTarefa = async () => {
        try {
            setLoading(true);

            const resp = await apiCard.alterarCartaoTarefa(reqConcluir);

            setLoading(false);

            toast.success('Concluído!');

            return resp;
        } catch (e) {
            setLoading(false);
            toast.error(e.response.data.erro);
        }
    }

    const deletarTarefa = async () => {
        try {
            setLoading(true);

            const resp = await apiCard.deletarCartaoTarefa(idCartao);

            setLoading(false);

            return resp;
        } catch (e) {
            setLoading(false);
            toast.error(e.response.data.erro);
        }
    }

    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container>

                    <button onClick={onClose}>
                        <X width="30px" height="30px"/>
                    </button>

                    <InputTitle>
                        <input type="text" placeholder={nomeCartao} onChange={e => setNomeCartao(e.target.value)}/>
                    </InputTitle>

                    <InputWrapper>
                        <input type="time" value={hora} onChange={e => setHora(e.target.value)}/>
                        <input type="date" value={data} onChange={e => setData(e.target.value)}/>
                    </InputWrapper>

                    <InputDescription>
                        <textarea placeholder="Descrição" onChange={e => setDescricao(e.target.value)}>{descricao}</textarea>
                    </InputDescription>

                    <End>
                        <button onClick={deletarTarefa}> <Trash width="30px" height="50px"/> </button>
                        <button onClick={alterarInfoClick}> <PencilSquare width="30px" height="50px"/> </button>
                        <button onClick={concluirTarefa}> <Calendar2Check width="30px" height="30px"/> </button>
                    </End>

                    <Loader>
                        <ClipLoader loading={loading}/>
                    </Loader>

                    <ToastContainer />

                </Container>

            </ModalContent>
    ) 
}

export default Modal;


export default Modal;