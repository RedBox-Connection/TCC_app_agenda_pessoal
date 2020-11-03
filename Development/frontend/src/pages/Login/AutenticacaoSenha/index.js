import React, { useState } from 'react';

import { Header } from '../styles';
import { InputBox } from '../../CadastrarUsuario/styles';

import { Loader, Container, InputWrapper } from './styles';

import ApiRecSenha from '../../../services/Login/RecuperacaoSenha/services';
import { toast, ToastContainer } from 'react-toastify';
import { useHistory } from 'react-router-dom';
import ClipLoader from "react-spinners/ClipLoader";

const apiRecSenha = new ApiRecSenha();

function AutenticacaoSenha() {

    const [loading, setLoading] = useState(false);
    const navegation = useHistory();

    const [codigo, setCodigo] = useState('000000');
    const req = {
        codigo
    };

    const validarCodigoClick = async () => {
        try {
            setLoading(true);

            const resp = await apiRecSenha.validarCodigo(req);

            setLoading(false);

            navegation.push({
                pathname: '/Esqueci-a-senha/Nova-senha',
                state: {
                    idLogin: resp.idLogin,
                    valido: resp.valido
                }
            });

            return resp;
        } catch (e) {
            setLoading(false);
            if(e.response.data.erro.includes('expirou')) {
                toast.error(e.response.data.erro);
                await apiRecSenha.deletarCodigoPorTempo(req);
            }
            toast.error(e.response.data.erro);
        }
    }

  return (
    <Container>
        <Header>
            <h1>Organizer</h1>
            <span>Insira o código de segurança aqui</span>
        </Header>

        <InputBox>
            <InputWrapper>
                <span>Código</span>
                <input type="number" 
                       min="111111"
                       max="999999"
                       onChange={(e) => {setCodigo(e.currentTarget.value)}} 
                />
            </InputWrapper>
        </InputBox>
    
        <button onClick={validarCodigoClick}>
            Prosseguir
        </button>

        <Loader>
            <ClipLoader loading={loading} />
        </Loader>

        <ToastContainer />
    </Container>
  );
}

export default AutenticacaoSenha;