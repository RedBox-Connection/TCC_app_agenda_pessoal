import styled from 'styled-components';

export const Container = styled.div`
  display:flex;
  flex-direction:column;
  align-items:center;
  justify-content:center;

  max-width:100vw;
`;

export const Content = styled.div`
  width:85vw;
  height:calc(100vh - 13vh);

  padding:50px 0;

  >h1{
      font-size:30px;
  }
`;

export const QuadrosContainer = styled.div`
  display:flex;
  align-items:center;

  flex-wrap:wrap;

  width:100%;
  height:fit-content;

`;

export const AddTeam = styled.div`
  display:flex;
  align-items:center;
  justify-content:center;

  
  height:80px;
  width:200px;

  padding:5px 8px;
  margin:10px 5px;

  background-color:var(--verde);
  border-radius:5px;
  font-size:20px;
`;

export const AddBoard = styled.div`
  display:flex;
  align-items:center;
  justify-content:center;

  
  height:80px;
  width:200px;

  padding:5px 8px;
  margin:10px 5px;

  background-color:var(--verde);
  border-radius:5px;
  font-size:20px;
`;