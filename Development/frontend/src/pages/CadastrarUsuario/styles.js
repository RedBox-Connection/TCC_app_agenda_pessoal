import styled from 'styled-components';

export const Container = styled.div`
  height:100vh;
  max-width:100vw;

  display:flex;
  align-items:center;

`;

export const Left = styled.div`
    display:flex;
    flex-direction:column;
    align-items:center;
    justify-content:center;

    height:100%;
    width:35vw;

    background-color:var(--bege);

    > h1{
        font-size:50px;
    }

    > img{
        width:90%;
        margin-top:70px;
    }
`;

export const Rigth = styled.div`
    display:flex;
    flex-direction:column;

    height:100%;
    width:65vw;
`;

export const Login = styled.div`
    width:100%;
    height:5vh;

    display:flex;
    align-items:center;
    justify-content:flex-end;

    padding-right:50px;

    > a{
        color:#000;
        text-decoration-color:var(--azul-primario);
        margin-left:20px;
    }
`;

export const Content = styled.div`
    width:100%;
    flex-grow:1;

    display:flex;
    flex-direction:column;

    padding:70px 100px;

    > h2{
        font-size:45px;
        max-width:500px;
    }
`;

export const InputBox = styled.div`
    display:flex;
    flex-direction:column;

    margin:30px 0;

    > p{
        max-width:400px;
        text-align:center;
    }
`;

export const InputWrapper = styled.div`
    display:flex;
    flex-direction:column;
    margin:5px 0;

    > input{
        width:400px;
        height:35px;
        border:none;
        border: 1px solid #ccc !important; 

        padding:0 15px;
    }

    > p{
        font-size:11px;
    }
`;

export const ButtonBox = styled.div`
    display:flex;
    flex-direction:column;

    > button{
        border:none;
        width:fit-content;
        padding:10px 20px;
    }

    >:nth-child(1){
        background-color:var(--verde);
        color:#fff;
        border-radius:5px;
        margin-bottom:15px;
        font-size:17px;
    }

    >:nth-child(2){
        width:fit-content;

        background-color:var(--vermelho);
        color:#fff;
        text-decoration:none;

        border-radius:5px;  
        padding:8px 20px;
    }
`;

export const Loader = styled.div`
  height: 50px;
  width: 50px;

  position: absolute;
  top: 95.5%;
  left: 56%;

  display: flex;
  flex-direction: row;
  align-items:center;
  justify-content:center;
`;