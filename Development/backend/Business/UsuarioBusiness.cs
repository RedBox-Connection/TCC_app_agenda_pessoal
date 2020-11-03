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

            return resp;
        }

        private async Task<bool> ValidarAlterarNomeUsuario(string nomeUsuario, int idUsuario)
        {
            List<Models.TbUsuario> usuarios = await usuarioDb.ConsultarUsuariosAsync();

            if(usuarios.Any(x => x.IdUsuario == idUsuario && x.NmUsuario == nomeUsuario))
                return true;
            else
            {
                bool nomeUsuarioOk = await this.ValidarNomeUsuario(nomeUsuario);
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

            return resp;
        }

        private void ValidarUsuarioRequest(Models.TbUsuario req)
        {
            if(req.DsFoto == string.Empty)
                throw new Exception("Foto não encontrada.");
            
            if(req.NmUsuario == string.Empty)
                throw new Exception("Nome de usuário não pode estar vazio.");

            if(req.NmPerfil == string.Empty)
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

            bool emailOk = await this.ValidarEmailUsuario(email);

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
            this.ValidarUsuarioRequest(req);

            bool nomeUsuarioOk = await this.ValidarNomeUsuario(req.NmUsuario);

            if(nomeUsuarioOk)
                throw new Exception("Nome de usuário já existe. Por favor insira um novo nome.");

            req = await usuarioDb.CadastrarUsuarioAsync(req);

            return req;
        }

        public async Task<Models.TbUsuario> AlterarUsuarioAsync(Models.TbUsuario atual, Models.TbUsuario novo)
        {
            this.ValidarUsuarioRequest(novo);

            await this.ValidarAlterarNomeUsuario(novo.NmUsuario, novo.IdUsuario);

            atual = await usuarioDb.AlterarUsuarioAsync(atual, novo);

            return atual;
        }

        public async Task<Models.TbLogin> CadastrarLoginAsync(Models.TbLogin req)
        {
            this.ValidarLoginRequest(req);

            bool emailOk = await this.ValidarEmailUsuario(req.DsEmail);

            if(emailOk)
                throw new Exception("Email já cadastrado, por favor insira outro email.");

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

            req = await usuarioDb.LoginAsync(req);

            if(req == null || req.IdLogin <= 0)
                throw new Exception("Usuário não cadastrado.");
            
            return req;
        }
    }
}