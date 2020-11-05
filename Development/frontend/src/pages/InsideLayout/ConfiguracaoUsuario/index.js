import React, { useEffect, useState } from 'react';
import { DoorOpenFill, PencilFill } from 'react-bootstrap-icons';

import { Loader, Container, Title, Content,UserProfile ,UserPhoto, UserInfo, InputWrapper,ButtonBox , Logout, LogoutBox } from './styles';
import ClipLoader from "react-spinners/ClipLoader";
import ConfiguracaoUsuarioApi from '../../../services/ConfiguracaoUsuario/services';
import FotoApi from '../../../services/CabecalhoLayout/services';
import { toast, ToastContainer } from 'react-toastify';
import { useHistory, Link } from 'react-router-dom';

const fotoApi = new FotoApi();
const configuracaoUsuarioApi = new ConfiguracaoUsuarioApi();

function ConfiguracaoUsuario(props) {

  const [idLogin, setIdLogin] = useState(props.location.state.idLogin);

  const [loading, setLoading] = useState(false);
  const navegation = useHistory();

  const [email, setEmail] = useState('');
  const [nomePerfil, setNomePerfil] = useState('');
  const [nomeUsuario, setNomeUsuario] = useState(props.location.state.nomeUsuario);
  const [senha, setSenha] = useState('');
  const [novaSenha, setNovaSenha] = useState('');
  const [receberEmail, setReceberEmail] = useState('');

  const [imagem, setImagem] = useState('');
  const [imagemPreview, setImagemPreview] = useState(fotoApi.buscarImagem(idLogin));
  const req = {
    fotoPerfil: imagem,
    nomePerfil,
    nomeUsuario,
    senha,
    confirmarSenha: novaSenha,
    email,
    receberEmail
  }

  const consultarUsuario = async () => {
    try {
      const resp = await configuracaoUsuarioApi.consultarUsuarioPorIdLogin(idLogin);

      setEmail(resp.email);
      setNomePerfil(resp.nomePerfil);
      setNomeUsuario(resp.nomeUsuario);
      setSenha(resp.senha);
      setNovaSenha(resp.senha);
      setReceberEmail(resp.receberEmail);
      setImagem(resp.fotoPerfil);

      return resp;
    } catch (e) {
      toast.error(e.response.data.erro);
    }
  }

  useEffect(() => {
    consultarUsuario();

  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  const alterarUsuarioClick = async () => {
    try {
      setLoading(true);

      const resp = await configuracaoUsuarioApi.alterarUsuarioAsync(req);

      setLoading(false);

      toast.success("Informações alteradas com sucesso.");

      navegation.push({
        pathname: '/Inicial',
        state: {
          idLogin,
          nomeUsuario
        }
      });

      return resp;
    } catch (e) {
      setLoading(false);
      toast.error(e.response.data.erro);
    }
  }

  const zerarTudo = () => {
    setLoading(false);
    setEmail('');
    setNomePerfil('');
    setNomeUsuario('');
    setSenha('');
    setNovaSenha('');
    setReceberEmail('');
    setIdLogin('');
    setImagem('');
    setImagemPreview('');
  }

  return (
      <Container>
          <Title>
              <h1>Configurações de Usuário</h1>
          </Title>
          <Content>
              <UserProfile>
                  <UserPhoto>
                    <img src={imagemPreview} alt="userphoto" draggable={false}/>
                    <label for='file-selector'> <PencilFill/> </label>
                      <input id='file-selector' type='file' 
                           onChange={(e) => {setImagemPreview(URL.createObjectURL(e.target.files[0]));
                                             setImagem(e.target.files[0])}}/>
                  </UserPhoto>
                  <span>{email}</span>
              </UserProfile>

              <UserInfo>

                <InputWrapper>
                  <span>Nome : </span>
                  <input type="text" placeholder={nomePerfil} onChange={(e) => {setNomePerfil(e.target.value)}}/>
                </InputWrapper>

                <InputWrapper>
                  <span>Nome de Usuário : </span>
                  <input type="text" placeholder={nomeUsuario} onChange={(e) => {setNomeUsuario(e.target.value)}}/>
                </InputWrapper>

                <InputWrapper>
                  <span>Senha : </span>
                  <input type="password" placeholder={senha} onChange={(e) => {setSenha(e.target.value)}}/>
                </InputWrapper>

                <InputWrapper>
                  <span>Confirmar senha : </span>
                  <input type="password" placeholder={senha} onChange={(e) => {setNovaSenha(e.target.value)}}/>
                </InputWrapper>

                <InputWrapper>
                  <span>Deseja rebecer emails do Organizer?</span>
                  <input type="checkbox" className="exc" checked={receberEmail} onChange={(e) => {setReceberEmail(e.target.checked ? true : false)}}/>
                </InputWrapper>

              </UserInfo>

              <ButtonBox>
                <button onClick={alterarUsuarioClick}>
                  Salvar Alterações
                </button>
                <Link to={{
                  pathname: '/Inicial',
                  state: {
                    idLogin,
                    nomeUsuario
                  }
                }}>
                  Cancelar
                </Link>
              </ButtonBox>

              <Loader>
                <ClipLoader loading={loading}/>
              </Loader>

          </Content>
          <Logout>
              <LogoutBox>
                <DoorOpenFill />
                <Link onClick={zerarTudo} to='/'>Sair</Link>
              </LogoutBox>
          </Logout>
          <ToastContainer />
      </Container>
  );
}

export default ConfiguracaoUsuario;