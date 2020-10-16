import axios from 'axios';

const apiLogin = axios.create({
    baseURL: 'http://localhost:5000/usuario'
})

export default class ApiLogin{

    async loginUsuario(req){
        const res = await apiLogin.post('/login' , req)
        return res;
    }

}