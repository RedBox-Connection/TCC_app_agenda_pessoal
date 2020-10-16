import React, { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';

import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import cadastrar from '../../images/cadastrar.svg';

import { Container, Left, Rigth, Login, Content, InputBox, InputWrapper, ButtonBox } from './styles';


import ApiCadastro from '../../services/Cadastro/services';

const api = new ApiCadastro();

function CadastrarUsuario() {

    const [nomeCompleto , setNomeCompleto] = useState('');
    const [nomeUsuario, setNomeUsuario] = useState('');
    const [email , setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const navegation = useHistory();

    const cadastrarUsuario = async () =>{
        try {

            const resp = await api.cadastroCliente({
                nomeCompleto,
                nomeUsuario,
                email,
                senha
            })

            navegation.push({
                pathname:"/", 
                state:{
                    idlogin:resp.idlogin,
                    nomeUsuario:resp.nomeUsuario
                }
            })

            return resp;
        } catch (e) {
            toast.error("coisas ruins ocorreram :(")
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
                        <input type="email" placeholder="Bruce.Wayne@gmail.com" onChange={e => setEmail(e.target.value)} />
                    </InputWrapper>

                    <InputWrapper>
                        <span>Senha</span>
                        <input type="password" placeholder="Pelo menos 8 caracteres" onChange={e => setSenha(e.target.value)}/>
                    </InputWrapper>

                </InputBox>

                <ButtonBox>
                    <button onClick={cadastrarUsuario}>Criar minha conta!</button>
                    <Link to="/">Cancelar</Link>
                </ButtonBox>

            </Content>

        </Rigth>
        <ToastContainer />
    </Container>
  );
}

export default CadastrarUsuario;