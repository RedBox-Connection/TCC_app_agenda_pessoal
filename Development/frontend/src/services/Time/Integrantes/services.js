import axios from 'axios';

const timeIntegranteApi = axios.create({
    baseURL: 'http://54.152.237.245:5000/timeIntegrante'
    // baseURL: 'http://localhost:5000/timeIntegrante'
})

export default class ApiTime{

    async consultarTimeIntegrantesAsync(idTime) {
        const resp = await timeIntegranteApi.get(`/consultar/${idTime}`)
        return resp.data;
    }
}