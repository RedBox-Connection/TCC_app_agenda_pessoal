import styled from 'styled-components';

export const Container = styled.div`
  height:100%;
  width:100%;

  display:flex;
  align-items:center;
  justify-content:center;
`;

export const Main = styled.div`
  max-height: 400px;

  display:flex;
  align-items:center;
  justify-content:center;

  > img{
      width:300px;
  }
`;

export const Content  = styled.div`
  height:100%;
  padding-left:5%;

  > h1{
      font-size:40px;
  }

  > p{
      margin-bottom:15px;
  }

  > a {
      background-color:#000;
      color:#fff;

      padding:5px 13px;
  }
`;
