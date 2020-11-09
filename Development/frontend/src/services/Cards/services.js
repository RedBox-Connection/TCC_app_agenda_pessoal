import axios from 'axios';

const cardsApi = axios.create({
    baseURL: 'http://54.152.237.245:5000/cartaotarefa'
    //baseURL: 'http://localhost:5000/cartaotarefa'
});

export default class apiCards{

    async cadastrarCartaoTarefa(idQuadro) {
        const resp = await cardsApi.post(`/cadastrar-cartao-tarefa/${idQuadro}`)
        return resp.data;
    }

    async consultarCartaoTarefa(idQuadro) {
        const resp = await cardsApi.get(`/consultar-cartoes-tarefa/${idQuadro}`)
        return resp.data;
    }

    async alterarCartaoTarefa(req) {
        const resp = await cardsApi.put(`/alterar-cartao-terafa`, req)
        return resp.data;
    }

    async deletarCartaoTarefa(req) {
        const resp = await cardsApi.delete(`/deletar-cartao-tarefa`, req)
        return resp.data;
    }
}