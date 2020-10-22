import React from 'react';
import { Route, Switch } from 'react-router-dom';

import CabecalhoLayout from '../CabecalhoLayout';
import MenuLateral from '../MenuLateral';

import { Container, Main } from './styles';

// import NotFound from '../../pages/NotFound';

//Configuração de usuário
import ConfiguracaoUsuario from '../../pages/InsideLayout/ConfiguracaoUsuario';


function Layout() {
  return (
      <Container>
          <CabecalhoLayout />
          <Main>
              <MenuLateral />
                <Switch>
                  <Route path="/Inicial" component={ConfiguracaoUsuario} />
                  {/* <Route path="*" component={NotFound} /> */}
                </Switch>
          </Main>
      </Container>
  );
}

export default Layout;