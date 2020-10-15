import styled from 'styled-components';

export const Container = styled.div`
    display:flex;
    flex-direction:column;

    max-width:100vw;
`;

export const Header = styled.div`
    height:10vh;
    max-width:100vw;

    display:flex;
    align-items:center;
    justify-content:space-between;

    padding:0 50px;

    background-color:var(--bege);
`;

export const ButtonBox = styled.div`
    display:flex;
    align-items:center;
    justify-content:space-between;
    
    width:200px;

    > *{
        color:#000;
    }

    > :nth-child(1){
        text-decoration:none;
    }

    > :nth-child(1):hover{
        text-decoration:underline;
    }

    > :nth-child(2){
        text-decoration:none;
        background-color:var(--verde);
        color:#fff;
        padding:7px 13px;
        border-radius:3px;
    }

    > :nth-child(2):hover{
        text-decoration:underline;
    }
`;

export const FaixaUm  = styled.div`
    max-width:100vw;
    height:60vh;

    display:flex;
    align-items:center;
    justify-content:space-evenly;

    background-color:var(--azul-primario);

    > img{
        height:70%;
    }
`;

export const Apresentation  = styled.div`
    display:flex;
    flex-direction:column;

    > h1{
        font-size:50px;
    }

    > p{
        font-size:25px;
        max-width:400px;
    }

    > a{
        width:fit-content;

        text-decoration:none;
        background-color:var(--verde);
        color:#fff;
        
        padding:7px 13px;
        margin:10px 0;

        border-radius:3px;
    }
`;

export const FaixaDois = styled.div`
    max-width:100vw;
    height:50vh;

    display:flex;
    flex-direction:row-reverse;
    align-items:center;
    justify-content:space-evenly;

    background-color:var(--azul-claro);

    > img{
        height:70%;
    }
`;

export const Footer = styled.div`
    display:flex;
    align-items:center;
    justify-content:space-between;

    max-width:100vw;
    height:7vh;

    padding:0 50px;

    background-color:var(--cinza);

    > *{
        color:#fff;
    }
`;

export const Location = styled.div`
    display:flex;
    align-items:center;

    height:fit-content;
    width:fit-content;

    > span{
        margin-left:8px;
    }
`;