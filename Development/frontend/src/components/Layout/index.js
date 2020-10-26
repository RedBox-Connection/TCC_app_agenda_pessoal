import React from 'react';
import { BrowserRouter,Route, Switch } from 'react-router-dom';

import CabecalhoLayout from '../CabecalhoLayout';
import MenuLateral from '../MenuLateral';

import { Container, Main,Content } from './styles';

import NotFound from '../../pages/NotFound';

//Configuração de usuário
// import ConfiguracaoUsuario from '../../pages/InsideLayout/ConfiguracaoUsuario/index';


//Agenda 
import Agenda from '../../pages/InsideLayout/Agenda';
import Feitos from '../../pages/InsideLayout/Agenda/Feitos';
// import Atrasados from '../../pages/Agenda/Atrasados';

function Layout() {
  return (
      <Container>
          <CabecalhoLayout />
          <Main>
              <BrowserRouter>
                <MenuLateral />
               <Content>
                <Switch>
                  <Route path="/inicial/Agenda" component={Agenda} />
                  <Route path="/inicial/Feitos" component={Feitos} />
                </Switch>
                </Content>
              </BrowserRouter>
          </Main>
      </Container>
  );
}

export default Layout;