import styled from 'styled-components';

export const Container = styled.div`
  height:100vh;
  width:100%;

  display:flex;
  flex-direction:column;
  align-items:center;
  justify-content:center;

  background-color:var(--gelo);
`;

export const ButtonBox = styled.div`
  display:flex;
  flex-direction:column;
  align-items:center;
  justify-content:center;

  > :nth-child(1){
      border:none;
      border-radius:3px;
      background-color:var(--verde);
      color:#fff;
      padding:10px 18px;
      font-size:16px;
      margin:5px 0;
  }

  > :nth-child(2){
      border:none;
      border-radius:3px;
      background-color:var(--vermelho);
      color:#fff;
      padding:10px 18px;
  }
`;