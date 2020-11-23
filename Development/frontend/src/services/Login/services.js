import axios from 'axios';

const apiLogin = axios.create({
    baseURL: 'http://54.152.237.245:5000/usuario'
    // baseURL: 'http://localhost:5000/usuario'
})

export default class ApiLogin{

    async loginUsuario(req){
        const res = await apiLogin.post('/login' , req)
        return res.data;
    }
}