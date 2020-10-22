import React from 'react';
import { DoorOpenFill, PencilFill } from 'react-bootstrap-icons';

import { Container, Title, Content,UserProfile ,UserPhoto, UserInfo, InputWrapper,ButtonBox , Logout, LogoutBox } from './styles';

function ConfiguracaoUsuario() {
  return (
      <Container>
          <Title>
              <h1>Configuração de Usuário</h1>
          </Title>
          <Content>
              <UserProfile>
                  <UserPhoto>
                    <img src="https://avatars1.githubusercontent.com/u/56550863?s=460&u=ef549fa73dea75355c40e6004fcc062fa0925e6e&v=4" alt="userphoto" draggable={false}/>
                    <button>
                      <PencilFill />
                    </button>
                  </UserPhoto>
                  <span>Bruce.Wayne@gmail.com</span>
              </UserProfile>

              <UserInfo>

                <InputWrapper>
                  <span>Nome :</span>
                  <input type="text" value="Bruce Wayne" />
                </InputWrapper>

                <InputWrapper>
                  <span>Nome de Usuário :</span>
                  <input type="text" value="Bruce Wayne" />
                </InputWrapper>

                <InputWrapper>
                  <span>Senha :</span>
                  <input type="password" value="********" />
                </InputWrapper>

                <InputWrapper>
                  <span>Deseja rebecer emails do Organizer?</span>
                  <input type="checkbox" className="exc"/>
                </InputWrapper>

              </UserInfo>

              <ButtonBox>
                <button>
                  Salvar Alterações
                </button>
              </ButtonBox>

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