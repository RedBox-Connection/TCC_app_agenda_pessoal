import axios from 'axios';

const alterarQuadroApi = axios.create({
    // baseURL: 'http://54.152.237.245:5000/quadro'
    baseURL: 'http://localhost:5000/quadro'
})

export default class ApiAlterarQuadro{
    async alterarNomeQuadro(){
        const resp = await alterarQuadroApi.put();
        return resp
    }
}