import styled from 'styled-components';

export const Container = styled.div`
  height: calc(100vh - 9vh);
  width:100%;

  display:flex;
  flex-direction:column;
  align-items:center;
  justify-content:center;

  > h1 {
      font-size:45px;
  }
`;

export const ButtonBox = styled.div`
  display:flex;
  flex-direction:column;
  align-items:center;

  margin:50px 0;

  max-width:400px;

  > a {
    font-size:18px;
  }

  > a:hover{
    text-decoration:underline;
  }
`;

export const Delete = styled.button`
  border:none;
  border-radius:5px;
  background-color:var(--vermelho);
  color:#fff;

  font-size:18px;

  width:fit-content;
  padding:10px 40px;

  margin:10px 0;
`;