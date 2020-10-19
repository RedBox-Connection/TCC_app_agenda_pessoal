import styled from 'styled-components';

export const Container = styled.div`
  height: 100%;

  display:flex;
  flex-direction:column;

  padding:10px 20px;

  background-color:var(--azul-primario);
`;

export const ItemLink = styled.div`
  display:flex;
  align-items:center;

  margin:8px 0;
  
  > a{
      margin-left:10px;
      text-decoration:none;
      color:#000;
  }

  > a:hover{
    text-decoration:underline;
  }
`;
