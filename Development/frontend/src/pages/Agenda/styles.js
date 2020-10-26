import styled from 'styled-components';

export const Container = styled.div`
  height: 100%;

  display:flex;
  flex-direction:column;

  background-color:var(--azul-primario);
`;

export const Main = styled.div`
    display:flex;
    align-items:center;

    max-width:100vw;
    height:calc(100vh - 8vh);
`;

export const CardContainer = styled.div`
    display:flex;
    flex-direction:row;
    justify-content:center;
    
    width:100vw;
    height:calc(100vh - 8vh);

    background-color: white;
`;