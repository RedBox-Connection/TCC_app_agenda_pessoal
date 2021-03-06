using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace backend.Business
{
    public class UsuarioBusiness
    {
        Database.UsuarioDatabase usuarioDb = new Database.UsuarioDatabase();

        public bool SenhaForte(string senha)
        {
            int numeros = 0;
            int caractersEspecial = 0;
            int letraMaiuscula = 0;

            foreach(char letra in senha)
            {
                if(letra == '0' || letra == '1' || letra == '2' ||
                   letra == '3' || letra == '4' || letra == '5' ||
                   letra == '6' || letra == '7' || letra == '8' || letra == '9')
                    numeros++;
                else if(letra == '!' || letra == '@' || letra == '#' ||
                        letra == '$' || letra == '&')
                         caractersEspecial++;
                else if(letra.ToString() == letra.ToString().ToUpper())
                    letraMaiuscula++;
            }

            bool resp = numeros >= 2 &&
                        caractersEspecial >= 1 &&
                        letraMaiuscula >= 1 &&
                        senha.Length >= 8;

            return resp;
        }

        private async Task<bool> ValidarNomeUsuario(string nomeUsuario)
        {
            List<string> nomesUsuario = await usuarioDb.ConsultarNomesUsuario();

            if(nomesUsuario == null || nomesUsuario.Count <= 0)
                return false;

            bool resp = nomesUsuario.Contains(nomeUsuario);

            if(resp)
                throw new Exception("Nome de usuário já existe. Por favor insira um novo nome.");

            return resp;
        }

        private async Task<bool> ValidarAlterarNomeUsuario(string nomeUsuarioAtual, string nomeUsuarioNovo, int idUsuarioNovo)
        {
            if(nomeUsuarioAtual == nomeUsuarioNovo)
                return false;

            List<Models.TbUsuario> usuarios = await usuarioDb.ConsultarUsuariosAsync();

            if(usuarios.Any(x => x.IdUsuario == idUsuarioNovo && x.NmUsuario == nomeUsuarioNovo))
                return true;
            else
            {
                bool nomeUsuarioOk = await this.ValidarNomeUsuario(nomeUsuarioNovo);
                if(nomeUsuarioOk)
                    throw new Exception("Nome de usuário já existe. Por favor insira um novo nome.");
            }

            return false;
        }
        
        private async Task<bool> ValidarEmailUsuario(string emailUsuario)
        {
            List<string> emailsUsuario = await usuarioDb.ConsultarEmailsUsuario();

            if(emailsUsuario == null || emailsUsuario.Count <= 0)
                return false;

            bool resp = emailsUsuario.Contains(emailUsuario);

            if(resp)
                throw new Exception("Email já cadastrado, por favor insira outro email.");

            return resp;
        }

        private async Task<bool> ValidarEmailLogin(string emailUsuario)
        {
            List<string> emailsUsuario = await usuarioDb.ConsultarEmailsUsuario();

            if(emailsUsuario == null || emailsUsuario.Count <= 0)
                return false;

            bool resp = emailsUsuario.Contains(emailUsuario);

            if(!resp)
                throw new Exception("Email não cadastrado, por favor insira outro email ou cadastre-se.");

            return resp;
        }

        private async Task<bool> ValidarEmailAlterarUsuario(string emailUsuario)
        {
            List<string> emailsUsuario = await usuarioDb.ConsultarEmailsUsuario();

            if(emailsUsuario == null || emailsUsuario.Count <= 0)
                return false;

            bool resp = emailsUsuario.Contains(emailUsuario);

            return resp;
        }

        private void ValidarUsuarioRequest(Models.TbUsuario req)
        {            
            if(req.NmUsuario == string.Empty || req.NmUsuario.Count(x => x != ' ') <=0)
                throw new Exception("Nome de usuário não pode estar vazio.");

            if(req.NmPerfil == string.Empty || req.NmPerfil.Count(x => x != ' ') <=0)
                throw new Exception("Nome não pode estar vazio.");
        }

        private void ValidarLoginRequest(Models.TbLogin req)
        {
            if(req.DsEmail == string.Empty)
                throw new Exception("Email não pode ser vazio.");

            if(!req.DsEmail.Contains('@'))
                throw new Exception("Email inválido, insira a empresa de seu email.");

            if(req.DsSenha == string.Empty)
                throw new Exception("A senha não pode ser vazia.");

            if(!this.SenhaForte(req.DsSenha))
                throw new Exception("A senha deve conter pelo menos um caracter especial, " + 
                                    "uma letra maiúscula, dois números e oito digitos.");
        }

        public async Task<Models.TbLogin> ConsultarLoginPorEmailAsync(string email)
        {
            if(email == string.Empty)
                throw new Exception("Email não pode ser vazio.");

            if(!email.Contains('@'))
                throw new Exception("Email inválido, insira a empresa de seu email.");

            bool emailOk = await this.ValidarEmailAlterarUsuario(email);

            if(emailOk == false)
                throw new Exception("Email não cadastrado, por favor insira outro email.");

            Models.TbLogin resp = await usuarioDb.ConsultarLoginPorEmailAsync(email);

            if(resp == null)
                throw new Exception("Usuário não existe.");

            return resp;
        }

        public async Task<Models.TbUsuario> ConsultarUsuarioPorIdLoginAsync(int idLogin)
        {
            if(idLogin <= 0)
                throw new Exception("Usuário não existe.");

            Models.TbUsuario resp = await usuarioDb.ConsultarUsuarioPorIdLoginAsync(idLogin);

            if(resp == null)
                throw new Exception("Usuário não encontrado.");

            return resp;
        }  

        public async Task<Models.TbUsuario> CadastrarUsuarioAsync(Models.TbUsuario req)
        {
            req = await usuarioDb.CadastrarUsuarioAsync(req);

            return req;
        }

        public async Task<Models.TbUsuario> CadastrarUsuarioLoginAsync(Models.TbUsuario semLogin, int idLogin)
        {
            if(idLogin <= 0)
                throw new Exception("Usuário não pode ser cadastrado, tente novamente.");

            semLogin = await usuarioDb.CadastrarUsuarioLoginAsync(semLogin, idLogin);

            return semLogin;
        }

        public async Task<Models.TbUsuario> AlterarUsuarioAsync(Models.TbUsuario atual, Models.TbUsuario novo)
        {
            this.ValidarUsuarioRequest(novo);

            await this.ValidarAlterarNomeUsuario(atual.NmUsuario, novo.NmUsuario, novo.IdUsuario);

            atual = await usuarioDb.AlterarUsuarioAsync(atual, novo);

            return atual;
        }

        public async Task<Models.TbUsuario> AlterarFotoUsuarioAsync(Models.TbUsuario atual, Models.TbUsuario novo)
        {
            if(novo.DsFoto == string.Empty)
                throw new Exception("A foto não pode ser vazia, por favor insira um arquivo.");

            atual = await usuarioDb.AlterarFotoUsuarioAsync(atual, novo);

            return atual;
        }

        public async Task<Models.TbLogin> CadastrarLoginAsync(Models.TbLogin req)
        {
            req = await usuarioDb.CadastrarLoginAsync(req);

            return req;
        }

        public async Task<Models.TbLogin> AlterarLoginAsync(Models.TbLogin atual, Models.TbLogin novo)
        {
            this.ValidarLoginRequest(novo);

            atual = await usuarioDb.AlterarLoginAsync(atual, novo);

            return atual;
        }

        public async Task<Models.TbLogin> LoginAsync(Models.TbLogin req)
        {
            if(req.DsEmail == string.Empty || !req.DsEmail.Contains('@'))
                throw new Exception("Email Invalido.");

            if(req.DsSenha == string.Empty)
                throw new Exception("Senha Invalida.");

            bool ignore = await this.ValidarEmailLogin(req.DsEmail);

            req = await usuarioDb.LoginAsync(req);

            if(req == null || req.IdLogin <= 0)
                throw new Exception("Email ou senha inválido, verifique suas credênciais.");
            
            return req;
        }

        public async Task<Models.TbLogin> AtualizarLoginAsync(Models.TbLogin loginAntigo, Models.TbLogin loginAtual)
        {
            loginAntigo = await usuarioDb.AtualizarLoginAsync(loginAntigo, loginAtual);

            return loginAntigo;
        }

        public async Task<bool> ValidarCadastroUsuarioLogin(Models.TbUsuario tbUsuario, Models.TbLogin tbLogin)
        {
            this.ValidarUsuarioRequest(tbUsuario);

            bool ignore = await this.ValidarNomeUsuario(tbUsuario.NmUsuario);

            this.ValidarLoginRequest(tbLogin);

            bool ignore2 = await this.ValidarEmailUsuario(tbLogin.DsEmail);

            return true;
        }

        public async Task<Models.TbLogin> ConsultarLoginPorIdLogin(int idLogin)
        {
            if(idLogin <= 0)
                throw new Exception("Usuário não encontrado.");

            Models.TbLogin resp = await usuarioDb.ConsultarLoginPorIdLogin(idLogin);

            if(resp == null)
                throw new Exception("Usuário não encontrado.");

            return resp;
        }

        public async Task<Models.TbLogin> DeletarLoginAsync(Models.TbLogin req)
        {
            return await usuarioDb.DeletarLoginAsync(req);
        }
    }
}