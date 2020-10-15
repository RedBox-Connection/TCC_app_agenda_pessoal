import { createGlobalStyle } from 'styled-components';

const GlobalStyle = createGlobalStyle`
    :root{
        --gelo: #fcfcfc;
        --verde: #5dd39e;
        --azul-primario: #489FB5;
        --azul-claro: #cae9ff;
        --cinza: #2b2d42;
        --bege: #EDE7E3;
        --vermelho: #ef233c;
    }

    *{
        padding:0;
        margin:0;
        box-sizing:border-box;
    }

    html, body, #root{
        height:100%;
        max-width:100vw;
    }

    body{
        font-family: 'Nunito', sans-serif;
        font-weight:400;
        -webkit-font-smoothing: antialiased !important;
    }

    h1, h2, h3{
        font-family: 'Sora', sans-serif;
        font-weight:700;
    }

    button{
        cursor:pointer;
    }
`;

export default GlobalStyle ;