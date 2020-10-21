import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import CabecalhoLayout from '../CabecalhoLayout';
import MenuLateral from '../MenuLateral';

import { Container, Main } from './styles';

//Configuração de usuário
import ConfiguracaoUsuario from '../../pages/InsideLayout/ConfiguracaoUsuario';

function Layout() {
  return (
      <Container>
          <CabecalhoLayout />
          <Main>
              <MenuLateral />
              <BrowserRouter>
                <Switch>
                    <Route path="/Inicial/a" component={ConfiguracaoUsuario} />
                </Switch>
              </BrowserRouter>
          </Main>
      </Container>
  );
}

export default Layout;