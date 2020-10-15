import React from 'react';
import { BrowserRouter , Switch , Route } from 'react-router-dom';

// Inicial
import Inicial from './pages/Inicial';

//Cadastrar Usuário
import CadastrarUsuario from './pages/CadastrarUsuario';

// Login
import Login from './pages/Login';
import EsqueciSenha from './pages/Login/EsqueciSenha';
import AutenticacaoSenha from './pages/Login/AutenticacaoSenha';

function Routes() {
  return(
    <BrowserRouter>
        <Switch>
            <Route path="/" component={Inicial} exact/>
            <Route path="/Criar-uma-conta" component={CadastrarUsuario} />

            <Route path="/Entrar" component={Login} exact/>
            <Route path="/Entrar/esqueci-a-senha" component={EsqueciSenha} />
            <Route path="/Entrar/autenticacao" component={AutenticacaoSenha} />
            
        </Switch>
    </BrowserRouter>
  );
}

export default Routes;