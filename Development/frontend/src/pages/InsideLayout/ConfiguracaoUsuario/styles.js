import styled from 'styled-components';

export const Container = styled.div`
  display:flex;
  flex-direction:column;
  justify-content:space-between;

  height:100%;
  width:100%;

  padding:20px;
`;

export const Title = styled.div`
  width:100%;

  display:flex;
  align-items:center;
`;

export const Content = styled.div`
  display:flex;
  flex-direction:column;
  justify-content:center;
  align-items:center;
  
  width:100%;
`;

export const UserProfile = styled.div`
`;

export const UserPhoto = styled.div`
  height:fit-content;
  width:fit-content;

  > img{
    height:150px;
    width:150px;

    border-radius:50%;
  }

  > label{
    font-size: 20px;

    border: none;

    cursor: pointer;
  }

  > input{
    display: none
  }
`;


export const UserInfo = styled.div`
  width:30%;
  
  display:flex;
  flex-direction:column;

  margin:30px 0;
`;

export const InputWrapper = styled.div`
  width:100%;

  display:flex;
  align-items:center;
  justify-content:space-between;

  margin:5px 0;

  > input:not(.exc){
    width:65%;
    height:30px;

    padding:0 10px;
  }

`;

export const ButtonBox = styled.div`
  width:100%;
  
  display:flex;
  flex-direction: column;
  align-items:center;
  justify-content:center;

  > :nth-child(1){
    border:none;
    border-radius:3px;

    background-color:var(--verde);
    color:#fff;

    padding:8px 15px;
    font-size:20px;

    margin: 2px;
  }

  > :nth-child(2){
    border:none;
    border-radius:3px;

    background-color:var(--vermelho);
    color:#fff;

    padding:8px 15px;
    font-size:15px;

    margin: 2px;
  }
`;

export const Logout = styled.div`
  width:100%;
`;

export const LogoutBox = styled.div`
  display:flex;
  align-items:center;

  > Link{
    margin-left:5px;
  }
`;

export const Loader = styled.div`
  height: 50px;
  width: 50px;

  position: absolute;
  transform: translate(0%, 300%);

  display: flex;
  flex-direction: row;
  align-items:center;
  justify-content:center;
`;