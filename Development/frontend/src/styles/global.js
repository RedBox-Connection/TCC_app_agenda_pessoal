import { createGlobalStyle } from 'styled-components';

const GlobalStyle = createGlobalStyle`
    
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