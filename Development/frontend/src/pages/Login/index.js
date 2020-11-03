import React, {useState} from 'react';
import { Link, useHistory } from 'react-router-dom';

import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import { Header, Form, Cadastro, Container, ImageContainer, Content} from './styles';
import { InputBox, InputWrapper } from '../CadastrarUsuario/styles';


import loginimage from '../../images/login.svg';


import ApiLogin from '../../services/Login/services';
const api = new ApiLogin();

function Login() {

  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');

  const navegation = useHistory();

  const efetuarLogin = async () => {
    try {
      const resp = await api.loginUsuario({
        email,
        senha
      })

      navegation.push({
        pathname:"/Meus-quadros", 
        state:{
            idlogin:resp.idlogin,
            nomeUsuario:resp.nomeUsuario
        }        
      })

      return resp;
      
    } catch (e) {
      const erro = e.response.data.erro;

      if(erro === "Object reference not set to an instance of an object."){
        toast.error("Conta inexistente")
      }
      else if(erro !== ''){
        toast.error(erro);
      }
      else{
        toast.error("coisas ruins ocorreram :(")
      }

    }
  }


  return(
      <Container>
        <ImageContainer>
          <h1>Organizer</h1>
          <img src={loginimage} alt="loginimage" draggable={false}/>
        </ImageContainer>
        <Content>
          <Header>
            <span>Olá quem é?</span>
            </Header>

            <Form>
              <InputBox>
                    <InputWrapper>
                    <span>Email</span>
                        <input type="email" placeholder="Bruce.Wayne@gmail.com" onChange={e => setEmail(e.target.value) } /> 
                    </InputWrapper>

                    <InputWrapper>
                    <span>Senha</span>
                    <input type="password" placeholder="Pelo menos 8 caracteres" onChange={e => setSenha(e.target.value)} /> 
                        <Link to="/Esqueci-a-senha">
                        Esqueci minha senha
                        </Link>
                    </InputWrapper>
              </InputBox>
                  <button onClick={efetuarLogin}>
                    Entrar
                  </button>
            </Form>

            <Cadastro>
              <span>Não tem uma conta?</span>
              <Link to="/Criar-uma-conta">Crie uma!</Link>
            </Cadastro>
            <ToastContainer />
        </Content>
      </Container>
  );
}

export default Login;