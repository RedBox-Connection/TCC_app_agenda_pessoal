import styled from 'styled-components';

export const Container = styled.div`
    display:flex;
    flex-direction:column;
`;

export const Title = styled.div`
    margin:10px;
`;

export const Content = styled.div`
    display:flex;
    flex-direction:column;
    align-items:center;
    justify-content:center;

    margin-top:50px;

    height:350px;

    input{
        height:50px;
        width:450px;

        border-radius:5px;

        padding:5px;
        margin:10px;
    }

    button{
        margin:10px;

        height:45px;
        width:350px;

        border-radius:5px;
        border:none;
    }

    #Update{
        background:var(--verde);
        color:#fff;
    }

    #Delete{
        background:var(--vermelho);
        color:#fff;
    }
`;

export const Loader = styled.div`
  height: 50px;
  width: 50px;

  position: absolute;
  transform: translate(0%, 0%);

  display: flex;
  flex-direction: row;
  align-items:center;
  justify-content:center;
`;

export const Voltar = styled.div`
    position: absolute;
    bottom: 5%;
    left: 1%;

    > p {
        margin: 0%;
        font-size: 15pt;
    }

    > button {
      width: fit-content;
      height: 35px;
      background-color: transparent;
      border: none;
    }
`;