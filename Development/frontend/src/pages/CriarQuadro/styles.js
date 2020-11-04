import styled from 'styled-components';

export const Container = styled.div`
  display:flex;
  flex-direction:column;
  align-items:center;

  max-width:100vw;
`;

export const Content = styled.div`
  display:flex;
  flex-direction:column;
  align-items:center;

  padding:100px 0;

  > h1{
      margin-bottom:30px;
  }
`;

export const Main = styled.div`
  display:flex;
  flex-direction:column;

  align-items:center;

  > button{
      border:none;

      background-color:var(--verde);
      color:#fff;

      width:fit-content;

      padding:8px 20px;
      font-size:18px;
  }
`;

export const InputWrapper  = styled.div`
  display:flex;
  flex-direction:column;

  margin-bottom:20px;

  > input{
      height:35px;
      width:400px;

      padding:0 15px;
  }
`;
