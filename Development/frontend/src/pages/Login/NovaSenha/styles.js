import styled from 'styled-components';

export const Container = styled.div`
  height: 100vh;
  max-width:100vw;

  display:flex;
`;

export const Left = styled.div`
  height:100%;
  width: 35%;

  background-color:var(--bege);

  display:flex;
  align-items:center;
  justify-content:center;

  > img{
    width:80%;
  }

`;

export const Rigth = styled.div`
  height:100%;
  width:65%;

  display:flex;
  flex-direction:column;

  justify-content:center;

  padding:20px 40px;

  > button{
      width:fit-content;

      border:none;
      border-radius:3px;

      color:#fff;
      background-color:var(--verde);

      padding:10px 50px;
      margin:10px 0;

      font-size:18px;
  }
`;

export const InputBox = styled.div`
  display:flex;
  flex-direction:column;

  margin:60px 0;
`;

export const InputWrapper = styled.div`
  display:flex;
  flex-direction:column;

  width:400px;

  margin:5px 0;

  > input{
      height: 35px;
      padding: 0 15px;
  }
`;

export const Loader = styled.div`
  height: 50px;
  width: 50px;

  position: absolute;
  transform: translate(300%, 360%);

  display: flex;
  flex-direction: row;
  align-items:center;
  justify-content:center;
`;