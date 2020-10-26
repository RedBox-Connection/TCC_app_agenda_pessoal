import React from 'react';
import { Route, Switch } from 'react-router-dom';

import CabecalhoLayout from '../CabecalhoLayout';
import MenuLateral from '../MenuLateral';

import { Container, Main } from './styles';

// import NotFound from '../../pages/NotFound';

//Configuração de usuário
import ConfiguracaoUsuario from '../../pages/InsideLayout/ConfiguracaoUsuario';


//Agenda 
import Agenda from '../../pages/Agenda';
// import Feitos from '../../pages/Agenda/Feitos';
// import Atrasados from '../../pages/Agenda/Atrasados';

function Layout() {
  return (
      <Container>
          <CabecalhoLayout />
          <Main>
              <MenuLateral />
                <Switch>
                  <Route path="/Configurações" component={ConfiguracaoUsuario} />

                  <Route path="/Agenda" component={Agenda} />
                  {/* <Route path="/Agenda/Feitos" component={Feitos} />
                  <Route path="/Agenda/Atrasados" component={Atrasados} /> */}
                </Switch>
          </Main>
      </Container>
  );
}

export default Layout;