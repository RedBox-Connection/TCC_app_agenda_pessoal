import styled from 'styled-components';

export const Container = styled.div`
  height:100vh;
  width:100%;

  display:flex;
  align-items:center;

  background-color:var(--gelo);
`;

export const ImageContainer = styled.div`
    height:100%;
    width:30vw;

    display:flex;
    flex-direction:column;
    align-items:center;
    justify-content:center;

    background-color:var(--bege);

    > img{
        width:80%;
    }

    > h1{
        font-size:45px;
        margin-bottom:30px;
    }
`;

export const Content = styled.div`
    height:100%;
    width:calc(100vw - 30vw);

    display:flex;
    flex-direction:column;
    justify-content:center;
    align-items:center;    
`;

export const Header = styled.div`
    text-align:center;
    

    > span{
        font-size:28px;
    }
`;

export const Form = styled.div`
    display:flex;
    flex-direction:column;

    justify-content:center;
    align-items:center;

    > button{
        width:fit-content;
        border:none;
        border-radius:3px;

        background-color:var(--verde);
        color:#fff;
        font-size:17px;
        
        padding:8px 15px;
    }
`;

export const Cadastro = styled.div`
  position:absolute;
  bottom:5%;
  right:10%;

  display:flex;
  align-items:center;
  justify-content:center;

  > a{
        color:#000;
        text-decoration-color:var(--azul-primario);
        margin-left:15px;
    }
`;

export const Loader = styled.div`
  height: 50px;
  width: 50px;

  position: absolute;
  transform: translate(0%, 300%);

  display: flex;
  flex-direction: row;
  align-items:center;
  justify-content:center;
`;