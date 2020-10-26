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