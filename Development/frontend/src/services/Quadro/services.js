import axios from 'axios';

const quadroApi = axios.create({
    baseURL: 'http://54.152.237.245:5000/quadro'
    // baseURL: 'http://localhost:5000/quadro'
})

export default class ApiQuadro{

    async consultarQuadrosAsync(idLogin) {
        const resp = await quadroApi.get(`/consultar/${idLogin}`)
        return resp.data.quadros;
    }

    async consultarQuadroAsync(idQuadro) {
        const resp = await quadroApi.get(`/consultarQuadro/${idQuadro}`);
        return resp.data;
    }

    async cadastrarQuadrosAsync(req) {
        const resp = await quadroApi.post('/cadastrar', req)
        return resp.data;
    }
}