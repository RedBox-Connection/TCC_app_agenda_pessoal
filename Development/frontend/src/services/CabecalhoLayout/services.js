import axios from 'axios';

const apiCabecalhoLayout = axios.create({
    //baseURL: 'http://54.152.237.245:5000/usuario'
    baseURL: 'http://localhost:5000/usuario' 
});

export default class ApiCabecalhoLayout{

    buscarImagem(idLogin) {
        const urlFoto = `${apiCabecalhoLayout.defaults.baseURL}/foto/imagem/${idLogin}`;
        return urlFoto;
    }

}