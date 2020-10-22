import styled from 'styled-components';

export const Container = styled.div`
  height:9vh;
  width:100%;

  display:flex;
  justify-content:space-between;
  align-items:center;

  padding:0 5em;

  /* background-color:#ffc677; */
  background-color:var(--bege);

  box-shadow: 0 5px 6px -6px black;

  z-index:10;
`;

export const Profile = styled.div`

  display:flex;
  align-items:center;

  > a{
      margin-right:15px
  }
`;