import styled from 'styled-components';

export const Container = styled.div`
  display:flex;
  flex-direction:column;
  align-items:center;

  max-width:100vw;
`;

export const Content = styled.div`
  width:80vw;
  height:calc(100vh - 13vh);
  
  padding-top:20px;

  >h1{
      font-size:30px;
  }
`;

export const QuadrosContainer = styled.div`
  display:flex;
  align-items:center;

  overflow-x:scroll;
  overflow-y:hidden;
  -webkit-overflow-scrolling: touch;

  width:100%;
  height:fit-content;

`;

export const AddTeam = styled.div`
  display:flex;
  align-items:center;
  justify-content:center;

  position:absolute;
  bottom:5%;
  right:5%;

  height:50px;
  width:50px;

  background-color:var(--verde);
  border-radius:50%;
  font-size:50px;
`;