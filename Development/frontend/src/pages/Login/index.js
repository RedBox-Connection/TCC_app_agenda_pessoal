import React, {useState} from 'react';
import { Link, useHistory } from 'react-router-dom';

import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import { Voltar, Loader, Header, Form, Cadastro, Container, ImageContainer, Content} from './styles';
import { InputBox, InputWrapper } from '../CadastrarUsuario/styles';


import loginimage from '../../images/login.svg';
import ClipLoader from "react-spinners/ClipLoader";


import ApiLogin from '../../services/Login/services';
const api = new ApiLogin();

function Login() {

  const [loading, setLoading] = useState(false); 

  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const req = {
    email,
    senha
  }

  const navegation = useHistory();

  const efetuarLogin = async () => {
    try {
      setLoading(true);

      const resp = await api.loginUsuario(req);

      setLoading(false);

      navegation.push({
        pathname:"/Meus-quadros", 
        state:{
            idLogin: resp.idLogin,
            nomeUsuario: resp.nomeUsuario
        }        
      })

      return resp;
      
    } catch (e) {
      setLoading(false)
      toast.error(e.response.data.erro);
    }
  }


  return(
      <Container>
        <ImageContainer>
          <Link to='/'>
            <h1>Organizer</h1>
          </Link>
          <img src={loginimage} alt="loginimage" draggable={false}/>
        </ImageContainer>
        
        <Voltar>
          <Link to='/'>
            <p>
              Voltar
            </p>
          </Link>
        </Voltar>

        <Content>
          <Header>
            <span>Olá quem é?</span>
            </Header>

            <Form>
              <InputBox>
                    <InputWrapper>
                    <span>Email</span>
                        <input type="email" placeholder="bruce.wayne@gmail.com" onChange={e => setEmail(e.target.value) } /> 
                    </InputWrapper>

                    <InputWrapper>
                    <span>Senha</span>
                    <input type="password" placeholder="********" onChange={e => setSenha(e.target.value)} /> 
                        <Link to={{
                          pathname: '/Esqueci-a-senha',
                          state: email
                        }}>
                          Esqueci minha senha
                        </Link>
                    </InputWrapper>
              </InputBox>
                  <button onClick={efetuarLogin}>
                    Entrar
                  </button>
              <Loader>
                <ClipLoader loading={loading}/>
              </Loader>
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