import React from 'react';
import { BrowserRouter,Route, Switch } from 'react-router-dom';

import CabecalhoLayout from '../CabecalhoLayout';
import MenuLateral from '../MenuLateral';

import { Container, Main,Content } from './styles';

import NotFound from '../../pages/NotFound';

//Configurações
import ConfiguracaoUsuario from '../../pages/InsideLayout/ConfiguracaoUsuario/index';
import ConfiguracaoTime from '../../pages/InsideLayout/ConfiguracaoTime';
import ConfirmacaoDelete from '../../pages/InsideLayout/ConfiguracaoUsuario/ConfirmacaoDelete';


//inicial
import WelcomePage from '../../pages/InsideLayout/WelcomePage';


//Agenda 
import Agenda from '../../pages/InsideLayout/Agenda';
import Feitos from '../../pages/InsideLayout/Agenda/Feitos';
import Atrasados from '../../pages/InsideLayout/Agenda/Atrasados';

//Quadro
import InfoQuadro from '../../pages/InsideLayout/InformacaoQuadro';

function Layout(props) {

  const nomeUsuario = props.location.state.nomeUsuario;
  const idLogin = props.location.state.idLogin;
  const quadroType = props.location.state.descricao;
  const idTipo = props.location.state.idTipo;
  const nomeQuadro = props.location.state.nomeQuadro;

  return (
      <Container>
        <BrowserRouter>
            <CabecalhoLayout idLogin={idLogin} quadroType={quadroType}
                         idTipo={idTipo} nomeQuadro={nomeQuadro}
                         nomeUsuario={nomeUsuario}
                         />
            <Main>
              
            <MenuLateral idLogin={idLogin} quadroType={quadroType}
                         idTipo={idTipo} nomeQuadro={nomeQuadro}
                         nomeUsuario={nomeUsuario}
                         />
              <Content>
                <Switch>

                  <Route path="/inicial" component={WelcomePage} exact />

                  <Route path="/inicial/Agenda" component={Agenda} />
                  <Route path="/inicial/Feitos" component={Feitos} />
                  <Route path="/Inicial/Atrasados" component={Atrasados} />

                  <Route path="/inicial/Configuracoes" component={ConfiguracaoUsuario} exact/>
                  <Route path="/inicial/Configuracoes/deletar-conta" component={ConfirmacaoDelete} />

                  <Route path="/inicial/ConfigurarTime" component={ConfiguracaoTime} />

                  <Route path="/inicial/InfoQuadro" component={InfoQuadro} />

                  <Route path="*" component={NotFound} />
                </Switch>
              </Content>
              </Main>
          </BrowserRouter>
          
      </Container>
  );
}

export default Layout;