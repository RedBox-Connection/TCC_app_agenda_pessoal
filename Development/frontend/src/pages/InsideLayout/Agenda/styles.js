import styled from 'styled-components';

export const Container = styled.div`
  height: calc(100vh - 9vh);
  width:100%;

  display:flex;
  flex-direction:column;

`;

export const CardContainer = styled.div`
    padding:15px;
    
    display:flex;
    flex-direction:row;
    
    background-color: white;

    #Add {
       width:42px;
       height:42px;
       border-radius:7px;
       border: 0;
       cursor:pointer; 
    }
`;