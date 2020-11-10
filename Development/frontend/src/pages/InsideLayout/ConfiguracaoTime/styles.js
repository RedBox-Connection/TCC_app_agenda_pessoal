import styled from 'styled-components';

export const Container = styled.div`
  height:calc(100vh - 9vh) ;
  width:100%;

  display:flex;
  flex-direction:column;

  padding:20px 35px;
`;

export const Content = styled.div`
  display:flex;
  flex-direction:column;

  margin:20px 0;

  overflow:scroll;
  &::-webkit-scrollbar{
      display:none;
  }

  > #deletar{
    background-color:var(--vermelho);
  color:#fff;

  border:none;
  width:fit-content;

  padding:10px 20px;

  font-size:18px;

  margin:10px 0;
  }

  > #salvar {
    background-color:var(--verde);
    color:#fff;

    border:none;
    width:fit-content;

    padding:10px 20px;

    font-size:18px;

    margin:10px 0;
  }
`;

export const InputWrapper = styled.div`
  display:flex;

  margin:15px 0;

  > span{
      margin-right:30px;
  }

  > input{
      width:400px;
      height:35px ;
      padding:0 15px;
  }

  > textarea{
      min-width:400px;
      max-width:400px;
      height:150px;
      max-height: 500px;

      padding:10px 15px;
  }

  > div input{
      width:350px;
      height:35px ;
      padding:0 15px;
  }

  > div button{
      height: 35px;
      padding:0 10px;
      margin-left:15px;
  }
`;

export const IntegrantesBox = styled.div`
   width:350px;
   max-height:300px;
   overflow-y:auto;
   overflow-x:hidden;

   max-width:450px;
`;

export const Integrante = styled.div`
    display:flex;
    align-items:center;

    margin:5px 0;

   > img{
       height: 35px;
       width: 35px;
       border-radius:50%;

       margin-right:10px;
   }
`;
