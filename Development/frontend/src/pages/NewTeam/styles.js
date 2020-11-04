import styled from 'styled-components';

export const Container = styled.div`
  display:flex;
  flex-direction:column;
`;

export const Content = styled.div`
  max-width:100vw;
  height: calc(100vh - 13vh);

  display:flex;
  flex-direction:column;
  align-items:center;

  padding:30px 0;
`;

export const InputBox = styled.div`
  display:flex;
  flex-direction:column;
`;

export const InputWrapper = styled.div`
  display:flex;
  flex-direction:column;

  margin:5px 0;

  > input{
    width:400px;
    height:35px;

    padding:0 15px;
  }

  > textarea{
      max-width:400px;
      min-width:400px;

      height: 100px;
      max-height:250px;

      line-height:20px;

      padding:0 15px;

      border: 1px solid #ccc; 
  }
`;

// export const LinkWrapper = styled.div`
//   display:flex;
//   flex-direction:column;

//   width: 400px;

//   margin: 5px 0;

//   > div{
//       display:flex;
//       justify-content:space-between;
//   }

//   > div input{
//       height:35px;
//       width:320px;

//       padding:0 15px;
//   }

//   > div button{
//       padding:0 10px;
//   }
// `;

export const ButtonBox = styled.div`
  display:flex;
  flex-direction:column;

  align-items:center;
  justify-content:center;

  width:400px;
  height:100px;

  > button{
      border:none;
      background-color:var(--verde);
      color:#fff;
      border-radius:3px;
      padding:10px 20px;

      font-size:18px;

      margin-bottom:10px;
  }

  > a:hover{
      text-decoration:underline;
  }
`;
