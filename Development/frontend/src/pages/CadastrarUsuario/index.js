import React, { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';

import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import cadastrar from '../../images/cadastrar.svg';

import { Loader, Container, Left, Rigth, Login, Content, InputBox, InputWrapper, ButtonBox } from './styles';

import ClipLoader from "react-spinners/ClipLoader";

import ApiCadastro from '../../services/Cadastro/services';

const api = new ApiCadastro();

function CadastrarUsuario() {

    const [nomeCompleto , setNomeCompleto] = useState('');
    const [nomeUsuario, setNomeUsuario] = useState('');
    const [email , setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [confirmarSenha, setConfirmarSenha] = useState('');
    const req = {
        nomeCompleto,
        nomeUsuario,
        email,
        senha,
        confirmarSenha
    }

    const navegation = useHistory();
    const [loading, setLoading] = useState(false);

    const cadastrarUsuario = async () =>{
        try {
            setLoading(true);

            const resp = await api.cadastroCliente(req)

            navegation.push({
                pathname:"/Meus-quadros", 
                state:{
                    idLogin: resp.idLogin,
                    nomeUsuario: resp.nomeUsuario
                }
            })

            setLoading(false);

            return resp;
        } catch (e) {
            setLoading(false);
            toast.error(e.response.data.erro);
        }
    }

  return (
    <Container>

        <Left>
            <h1>Organizer</h1>
            <img src={cadastrar} alt="join" draggable={false}/>
        </Left>

        <Rigth>

            <Login>
                <span>Já tem uma conta?</span>
                <Link to="/Entrar">Entrar</Link>
            </Login>

            <Content>
                <h2>Planeje melhor o seu dia conosco!</h2>

                <InputBox>

                    <InputWrapper>
                        <span>Nome Completo</span>
                        <input type="text" placeholder="Bruce Wayne da Silva" onChange={e => setNomeCompleto(e.target.value)}/>
                    </InputWrapper>

                    <InputWrapper>
                        <span>Nome de Usuário</span>
                        <input type="text" placeholder="Batman" onChange={e => setNomeUsuario(e.target.value)}/>
                    </InputWrapper>

                    <InputWrapper>
                        <span>Email</span>
                        <input type="email" placeholder="bruce.wayne@gmail.com" onChange={e => setEmail(e.target.value)} />
                    </InputWrapper>

                    <InputWrapper>
                        <span>Senha</span>
                        <input type="password" placeholder="********" onChange={e => setSenha(e.target.value)}/>
                        <p>
                            A senha deve conter pelo menos 8 caracteres, <br/> 
                            2 números, <br/>
                            1 letra maiuscula, <br/>
                            1 minuscula e<br/>
                            1 caracterer especial.        
                        </p>
                    </InputWrapper>

                    <InputWrapper>
                        <span>Confirme sua Senha</span>
                        <input type="password" placeholder="********" onChange={(e) => {setConfirmarSenha(e.target.value)}}/>
                    </InputWrapper>

                </InputBox>

                <ButtonBox>
                    <button onClick={cadastrarUsuario}>Criar minha conta!</button>
                    <Link to="/">Cancelar</Link>
                </ButtonBox>

                <Loader>
                    <ClipLoader loading={loading}/>
                </Loader>

            </Content>

        </Rigth>
        <ToastContainer />
    </Container>
  );
}

export default CadastrarUsuario;