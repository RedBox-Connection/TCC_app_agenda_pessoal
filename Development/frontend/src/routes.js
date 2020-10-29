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

//Not Found
import NotFound from './pages/NotFound';

//Home
import Layout from './components/Layout';
import EscolherQuadro from './pages/EscolherQuadro';

//Convite para time
import ConviteTime from './pages/ConviteTime';

function Routes() {
  return(
    <BrowserRouter>
        <Switch>
            <Route path="/" component={Inicial} exact/>
            <Route path="/Criar-uma-conta" component={CadastrarUsuario}/>

            <Route path="/Entrar" component={Login} />
            <Route path="/Esqueci-a-senha" component={EsqueciSenha} exact/>
            <Route path="/Esqueci-a-senha/Autenticacao" component={AutenticacaoSenha} />

            <Route path="/Meus-quadros" component={EscolherQuadro} />

            <Route path="/Convite" component={ConviteTime}/>

            <Route path="/Inicial" component={Layout} exact/>

            <Route path="*" component={NotFound} />
        </Switch>
    </BrowserRouter>
  );
}

export default Routes;