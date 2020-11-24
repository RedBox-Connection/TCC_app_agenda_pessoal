import styled from 'styled-components';

export const Container = styled.div`
  height: calc(100vh - 9vh);
  width:100%;

  display:flex;
  flex-direction:column;

  h1{
      margin:20px;
    }

`;

export const CardContainer = styled.div`
    display:flex;
    flex-direction:row;
    flex-wrap:wrap;

    padding: 0 20px; 

    background-color: white;    
`;