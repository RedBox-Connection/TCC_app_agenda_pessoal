import styled from 'styled-components';

export const Container = styled.div`
  height:100vh;
  width:100%;

  display:flex;
  flex-direction:column;
  align-items:center;
  justify-content:center;

  background-color:var(--gelo);

  > button{
      border:none;
      border-radius:5px;

      background-color:var(--verde);
      color:#fff;

      padding:15px 25px;

      font-size:16px;
  }
`;

export const InputWrapper = styled.div`
    display:flex;
    flex-direction:column;
    margin:5px 0;

    > input{
        width:400px;
        height:35px;

        padding:0 20px;

        border:none;
        border: 1px solid #ccc !important; 

        letter-spacing:25px;
        font-weight:600;
        font-size:20px;
        text-align:center;
    }   

    > input[type=number]::-webkit-inner-spin-button { 
        -webkit-appearance: none;
    }  
`;

export const Loader = styled.div`
  height: 50px;
  width: 50px;

  position: absolute;
  transform: translate(0%, -40%);

  display: flex;
  flex-direction: row;
  align-items:center;
  justify-content:center;
`;