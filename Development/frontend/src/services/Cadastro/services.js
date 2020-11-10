import axios from 'axios';

const apiCadastro = axios.create({
    //baseURL: 'http://54.152.237.245:5000/usuario'
    baseURL: 'http://localhost:5000/usuario' 
});

export default class ApiCadastro{

    async cadastroCliente(req){
        const res = await apiCadastro.post('/cadastrar', req);
        return res.data;
    }

}