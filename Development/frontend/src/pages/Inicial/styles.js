import styled from 'styled-components';

export const Container = styled.div`
  height:fit-content;
  width:100vw;

  display:flex;
  flex-direction:column;
`;

export const Header = styled.div`
    height:10vh;
    width:100vw;

    display:flex;
    align-items:center;
    justify-content:space-between;

    padding:0 50px;

    background-color:#EDE7E3;
`;

export const ButtonBox = styled.div`
    display:flex;
    align-items:center;
    justify-content:space-between;
    color:#000;
    width:200px;

    > :nth-child(1){
        text-decoration:none;
    }

    > :nth-child(1):hover{
        text-decoration:underline;
    }

    > :nth-child(2){
        text-decoration:none;
        background-color:#5dd39e;
        color:#fff;
        padding:7px 13px;
        border-radius:3px;
    }

    > :nth-child(2):hover{
        text-decoration:underline;
    }
`;

export const FaixaUm  = styled.div`
    width:100vw;
    height:60vh;

    display:flex;
    align-items:center;
    justify-content:space-evenly;

    background-color:#489FB5;

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
        background-color:#5dd39e;
        color:#fff;
        
        padding:7px 13px;
        margin:10px 0;

        border-radius:3px;
    }
`;

export const FaixaDois = styled.div`
    width:100vw;
    height:50vh;

    display:flex;
    flex-direction:row-reverse;
    align-items:center;
    justify-content:space-evenly;

    background-color:#cae9ff;

    > img{
        height:70%;
    }
`;

