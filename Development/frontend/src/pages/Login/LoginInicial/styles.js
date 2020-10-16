import styled from 'styled-components';

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