import React from 'react';
import { Link } from 'react-router-dom';

import cadastrar from '../../images/cadastrar.svg';

import { Container, Left, Rigth, Login, Content, InputBox, InputWrapper, ButtonBox } from './styles';

function CadastrarUsuario() {
  return (
    <Container>

        <Left>
            <h1>Organizer</h1>
            <img src={cadastrar} alt="join" draggable={false}/>
        </Left>

        <Rigth>

            <Login>
                <span>Já tem uma conta?</span>
                <Link to="/Entrar">Entrar</Link>
            </Login>

            <Content>
                <h2>Planeje melhor o seu dia conosco!</h2>

                <InputBox>

                    <InputWrapper>
                        <span>Nome Completo</span>
                        <input type="text" placeholder="Bruce Wayne da Silva" />
                    </InputWrapper>

                    <InputWrapper>
                        <span>Email</span>
                        <input type="email" placeholder="Bruce.Wayne@gmail.com" />
                    </InputWrapper>

                    <InputWrapper>
                        <span>Senha</span>
                        <input type="password" placeholder="Pelo menos 8 caracteres" />
                    </InputWrapper>

                </InputBox>

                <ButtonBox>
                    <button>Criar minha conta grátis</button>
                    <Link to="/">Cancelar</Link>
                </ButtonBox>

            </Content>

        </Rigth>

    </Container>
  );
}

export default CadastrarUsuario;