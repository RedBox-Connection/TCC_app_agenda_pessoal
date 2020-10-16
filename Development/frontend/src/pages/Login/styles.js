import styled from 'styled-components';

export const Container = styled.div`
  height:100vh;
  width:100%;

  display:flex;
  align-items:center;

  background-color:var(--gelo);
`;

export const ImageContainer = styled.div`
    height:100%;
    width:30vw;

    display:flex;
    flex-direction:column;
    align-items:center;
    justify-content:center;

    background-color:var(--bege);

    > img{
        width:80%;
    }

    > h1{
        font-size:45px;
        margin-bottom:30px;
    }
`;

export const Content = styled.div`
    height:100%;
    width:calc(100vw - 30vw);

    display:flex;
    flex-direction:column;
    justify-content:center;
    align-items:center;    
`;

