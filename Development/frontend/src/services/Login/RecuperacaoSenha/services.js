import axios from 'axios';

const apiRecuperacaoSenha = axios.create({
    baseURL: 'http://localhost:5000/esquecisenha'
})

export default class ApiRecSenha{

    async envioDeEmail(req) {
        const res = await apiRecuperacaoSenha.post('/recuperar-senha-email', req)
        return res;
    }

    async gerarCodigo(req) {
        const res = await apiRecuperacaoSenha.put('/recuperar-senha-codigo', req)
        return res;
    }
}