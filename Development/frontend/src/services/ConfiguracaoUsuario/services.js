import axios from 'axios';

const apiConfiguracaoUsuario = axios.create({
    baseURL: 'http://localhost:5000/usuario' 
});

export default class ApiConfiguracaoUsuario{

    async consultarUsuarioPorIdLogin(idLogin) {
        const resp = await apiConfiguracaoUsuario.get(`/consultar/${idLogin}`);
        return resp.data;
    }

    async alterarUsuarioAsync(req) {
        let formData = new FormData();
        formData.append('fotoPerfil', req.fotoPerfil);
        formData.append('nomePerfil', req.nomePerfil);
        formData.append('nomeUsuario', req.nomeUsuario);
        formData.append('senha', req.senha);
        formData.append('confirmarSenha', req.confirmarSenha);
        formData.append('email', req.email);
        formData.append('receberEmail', req.receberEmail);
        


        const resp = await apiConfiguracaoUsuario.put('/alterar', formData, {
            headers: {
                'content-type': 'multipart/form-data'
            }
        })
        return resp.data;
    }
}