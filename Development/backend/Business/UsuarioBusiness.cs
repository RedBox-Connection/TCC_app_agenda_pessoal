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
            List<char> numeros = new List<char>();
            List<char> caractersEspecial = new List<char>();
            List<char> letraMaiuscula = new List<char>();

            foreach(char letra in senha)
            {
                if(letra == '0' ||
                   letra == '1' ||
                   letra == '2' ||
                   letra == '3' ||
                   letra == '4' ||
                   letra == '5' ||
                   letra == '6' ||
                   letra == '7' ||
                   letra == '8' ||
                   letra == '9')
                    numeros.Add(letra);
                else if(letra == '!' ||
                        letra == '@' ||
                        letra == '#' ||
                        letra == '$' ||
                        letra == '&')
                         caractersEspecial.Add(letra);
                else if(letra.ToString() == letra.ToString().ToUpper())
                    letraMaiuscula.Add(letra);
            }

            bool numerosOk = numeros.Count >= 2;
            bool especialOk = caractersEspecial.Count >= 1;
            bool maiusculaOk = letraMaiuscula.Count >= 1;
            bool tamanhoOk = senha.Length >= 8;
            bool resp = numerosOk && especialOk && maiusculaOk && tamanhoOk;

            return resp;
        }

        public async Task<Models.TbUsuario> CadastrarUsuarioAsync(Models.TbUsuario req)
        {
            if(req.DsFoto == string.Empty)
                throw new Exception("Foto não encontrada.");
            
            if(req.NmUsuario == string.Empty)
                throw new Exception("Nome não pode estar vazio.");

            req = await usuarioDb.CadastrarUsuarioAsync(req);

            return req;

        }

        public async Task<Models.TbLogin> CadastrarLoginAsync(Models.TbLogin req)
        {
            if(req.DsEmail == string.Empty)
                throw new Exception("Email não pode ser vazio.");

            if(!req.DsEmail.Contains('@'))
                throw new Exception("Email inválido, insira a empresa de seu email.");

            if(req.DsSenha == string.Empty)
                throw new Exception("A senha não pode ser vazia.");

            if(this.SenhaForte(req.DsSenha))
                throw new Exception("A senha deve conter pelo menos um caracter especial, " + 
                                    "uma letra maiúscula, dois números e oito digitos.");

            req = await usuarioDb.CadastrarLoginAsync(req);

            return req;
        }
    }
}