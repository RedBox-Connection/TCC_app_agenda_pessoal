import styled from 'styled-components';

export const Container = styled.div`
  height:100%;
  width:100%;

  display:flex;
  align-items:center;
  justify-content:center;
`;

export const Main = styled.div`
  width:50%;

  > h1{
      font-size:40px;
  }

  > h1::after{
      content:'';
      width:80%;
      height:5px;
      background-color:#d4d4d4;
      margin-bottom:20px;
      display:block;
  }

  > p a{
      text-decoration:underline;
  }
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