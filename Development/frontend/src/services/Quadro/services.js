import axios from 'axios';

const apiQuadro = axios.create({
    baseURL: 'http://localhost:5000/quadro'
})

export default class ApiQuadro{

    async consultarQuadrosAsync(idLogin){
        const res = await apiQuadro.get(`/consultar/${idLogin}`)
        return res.data.quadros;
    }
}