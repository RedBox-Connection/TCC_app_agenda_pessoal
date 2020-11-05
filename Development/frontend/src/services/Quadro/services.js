import axios from 'axios';

const quadroApi = axios.create({
    baseURL: 'http://localhost:5000/quadro'
})

export default class ApiQuadro{

    async consultarQuadrosAsync(idLogin) {
        const resp = await quadroApi.get(`/consultar/${idLogin}`)
        return resp.data.quadros;
    }
}