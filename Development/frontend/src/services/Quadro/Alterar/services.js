import axios from 'axios';

const alterarQuadroApi = axios.create({
    //baseURL: 'http://54.152.237.245:5000/quadro'
    baseURL: 'http://localhost:5000/quadro'
})

export default class ApiAlterarQuadro{
    async alterarNomeQuadro(req, idQuadro){
        const resp = await alterarQuadroApi.put(`/alterar/${idQuadro}`, req);
        return resp.data;
    }

    async deletarQuadro(idQuadro){
        const resp = await alterarQuadroApi.delete(`/deletar/${idQuadro}`)
        return resp.data;
    }
}