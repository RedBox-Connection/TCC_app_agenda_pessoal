import React from 'react';
import { BrowserRouter,Route, Switch } from 'react-router-dom';

import CabecalhoLayout from '../CabecalhoLayout';
import MenuLateral from '../MenuLateral';

import { Container, Main,Content } from './styles';

import NotFound from '../../pages/NotFound';

//Configuração de usuário
import ConfiguracaoUsuario from '../../pages/InsideLayout/ConfiguracaoUsuario/index';


//inicial
import WelcomePage from '../../pages/InsideLayout/WelcomePage';


//Agenda 
import Agenda from '../../pages/InsideLayout/Agenda';
import Feitos from '../../pages/InsideLayout/Agenda/Feitos';
// import Atrasados from '../../pages/Agenda/Atrasados';

function Layout() {
  return (
      <Container>
        <BrowserRouter>
            <CabecalhoLayout />
            <Main>
              
            <MenuLateral />
              <Content>
                <Switch>

                  <Route path="/inicial" component={WelcomePage} exact />

                  <Route path="/inicial/Agenda" component={Agenda} />
                  <Route path="/inicial/Feitos" component={Feitos} />

                  <Route path="/inicial/Configurações" component={ConfiguracaoUsuario} />

                  <Route path="*" component={NotFound} />
                </Switch>
              </Content>
              </Main>
          </BrowserRouter>
          
      </Container>
  );
}

export default Layout;