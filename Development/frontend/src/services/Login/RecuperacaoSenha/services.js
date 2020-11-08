import axios from 'axios';

const apiRecuperacaoSenha = axios.create({
    //baseURL: 'http://54.152.237.245:5000/esquecisenha'
    baseURL: 'http://localhost:5000/esquecisenha'
})

export default class ApiRecSenha{

    async envioDeEmail(req) {
        const res = await apiRecuperacaoSenha.post('/recuperar-senha-email', req)
        return res.data;
    }

    async validarCodigo(req) {
        const res = await apiRecuperacaoSenha.put('/recuperar-senha-codigo', req)
        return res.data;
    }

    async deletarCodigoPorTempo(req) {
        const res = await apiRecuperacaoSenha.delete('/recuperar-senha-deletar-tempo', req)
        return res.data;
    }

    async alterarSenha(idLogin, req) {
        const res = await apiRecuperacaoSenha.patch(`/recuperar-senha-deletar/${idLogin}`, req)
        return res.data;
    }
}