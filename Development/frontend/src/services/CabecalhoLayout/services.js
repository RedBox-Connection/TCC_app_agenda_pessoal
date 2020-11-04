import axios from 'axios';

const apiCabecalhoLayout = axios.create({
    baseURL: 'http://localhost:5000/usuario' 
});

export default class ApiCabecalhoLayout{

    buscarImagem(foto) {
        const urlFoto = `${apiCabecalhoLayout.defaults.baseURL}/foto/${foto}`;
        console.log(urlFoto);
        return urlFoto;
    }

}