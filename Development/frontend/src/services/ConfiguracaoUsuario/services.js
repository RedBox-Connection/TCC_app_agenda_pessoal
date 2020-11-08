import axios from 'axios';

const apiConfiguracaoUsuario = axios.create({
    baseURL: 'http://54.152.237.245:5000/usuario' 
});

export default class ApiConfiguracaoUsuario{

    async consultarUsuarioPorIdLogin(idLogin) {
        const resp = await apiConfiguracaoUsuario.get(`/consultar/${idLogin}`);
        return resp.data;
    }

    async alterarFotoUsuarioAsync(req) {
        let formData = new FormData();
        formData.append('idLogin', req.idLogin);
        formData.append('fotoPerfil', req.fotoPerfil);

        const resp = await apiConfiguracaoUsuario.patch('/alterar/foto', formData, {
            headers: {
                'content-type': 'multipart/form-data'
            }
        })
        return resp.data;
    }

    async alterarUsuarioInfoAsync(req) {
        const resp = await apiConfiguracaoUsuario.patch('/alterar/info', req);
        return resp.data;
    }
}