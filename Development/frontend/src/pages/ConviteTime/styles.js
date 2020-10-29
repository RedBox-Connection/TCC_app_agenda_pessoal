import styled from 'styled-components';

export const Container = styled.div`
  height:100vh;
  max-width:100vw;

  display:flex;
  align-items:center;
  justify-content:space-between;
`;

export const Left = styled.div`
  height:100vh;
  width:60%;
 
  padding:70px 30px;  

  display:flex;
  flex-direction:column;
  justify-content:center;

  > h1{
      max-width:600px;

      font-size:50px;
      line-height:100%;
      letter-spacing:0.7px;
  }

  > p{
      font-size:20px;

      margin:20px 0;
  }
`;

export const ButtonBox = styled.div`
    display:flex;

    padding:5px 0;

    > button:nth-child(1){
        width:250px;
        height: 40px;

        font-size:18px;

        border:none;
        border-radius:5px;

        background-color:#55ba8c;
        color:#fff;

        opacity: .9;
        transition: .3s;
    }

    > button:nth-child(1):hover{
        opacity:1;
    }

    > button:nth-child(2){
        width:200px;
        height:40px;
        
        margin-left:25px;

        font-size:18px;

        border:none;
        border-radius:5px;

        background-color:var(--vermelho);
        color:#fff;

        opacity: .7;

        transition: .3s;
    }

    > button:nth-child(2):hover{
        opacity:1;
    }
`;

export const Rigth = styled.div`
  height:100vh;
  width:40%;

  display:flex;
  align-items:center;
  justify-content:center;

  background-color:var(--bege);

  > img{
      width:80%;
  }
`;
