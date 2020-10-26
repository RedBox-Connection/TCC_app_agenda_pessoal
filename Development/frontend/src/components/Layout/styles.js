import styled from 'styled-components';

export const Container = styled.div`
  display:flex;
  flex-direction:column;

  max-width:100vw;
  max-height:100vh;
`;

export const Main = styled.div`
    display:flex;
    align-items:center;

    max-width:100vw;
    height:calc(100vh - 8vh);
`;

export const Content = styled.div`
  width:100%;
  height:100%;
  display:flex;
  flex-direction:column;

`;