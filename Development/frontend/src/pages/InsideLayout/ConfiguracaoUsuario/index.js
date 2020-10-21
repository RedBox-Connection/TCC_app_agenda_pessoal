import React from 'react';
import { DoorOpenFill } from 'react-bootstrap-icons';

import { Container, Title, Content, Logout, LogoutBox } from './styles';

function ConfiguracaoUsuario() {
  return (
      <Container>
          <Title>
              <h1>Configuração de Usuário</h1>
          </Title>
          <Content>
              <p>Aoba</p>
          </Content>
          <Logout>
              <LogoutBox>
                <DoorOpenFill />
                <span>Sair</span>
              </LogoutBox>
          </Logout>
      </Container>
  );
}

export default ConfiguracaoUsuario;