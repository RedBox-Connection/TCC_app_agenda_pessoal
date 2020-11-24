import axios from 'axios';

const timeApi = axios.create({
    //baseURL: 'http://54.152.237.245:5000/time'
     baseURL: 'http://localhost:5000/time'
})

export default class ApiTime{

    async cadastrarTimeAsync(req) {
        const resp = await timeApi.post('/cadastrar', req)
        return resp.data;
    }

    async consultarTimeAsync(idTime) {
        const resp = await timeApi.get(`/consultar-info/${idTime}`)
        return resp.data;
    }

    async consultarTimesAsync(idLogin) {
        const resp = await timeApi.get(`/consultar/${idLogin}`);
        return resp.data.times;
    }

    async deletarTime(idTime){
        const resp = await timeApi.delete(`/deletar/${idTime}`);
        return resp.data;
    }

    async alterarTime(req, idTime){
        const resp = await timeApi.patch(`/alterar/${idTime}`, req);
        return resp.data;
    }
}