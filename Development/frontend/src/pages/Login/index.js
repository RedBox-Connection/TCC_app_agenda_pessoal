import React from 'react';
import { Switch, Route } from 'react-router-dom';

import { Container, ImageContainer, Content} from './styles';

import loginimage from '../../images/login.svg';


import LoginInicial from './LoginInicial';
import EsqueciSenha from './EsqueciSenha';
import AutenticacaoSenha from './AutenticacaoSenha';

function Login() {
  return(
      <Container>
        <ImageContainer>
          <h1>Organizer</h1>
          <img src={loginimage} alt="loginimage" draggable={false}/>
        </ImageContainer>
        <Content>
          <Switch>
            <Route path="/Entrar" component={LoginInicial} exact/>
            <Route path="/Entrar/esqueci-a-senha" component={EsqueciSenha} exact />
            <Route path="/Entrar/esqueci-a-senha/autenticacao" component={AutenticacaoSenha} />
          </Switch>
        </Content>
      </Container>
  );
}

export default Login;