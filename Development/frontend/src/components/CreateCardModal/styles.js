import styled from 'styled-components';

export const ModalContent = styled.div`
    width: 100%;
    height: 100vh;

    position: absolute;
    top: 0;
    left: 0;

    background-color: rgba(0, 0, 0, 0.7);

    display:flex;
    justify-content:center;
`;

export const Container = styled.div`
    background-color: white;

    height:590px;
    width:410px;
    margin-top:10vh;

    display:flex;
    flex-direction:column;
    align-items:center;

    border:5px solid ${props => props.color};

    overflow:hidden;
    overflow:auto;

    >h3{
        margin:30px;
    }
`;

export const InputTitle = styled.div`
    >input{
        height:30px;
        width:350px;
        margin:10px;
        padding:10px;
    }
`;

export const InputWrapper = styled.div`
    margin:10px;

    >input{
        height:30px;
        width:175px;
        margin-right:5px;
    }
    >button{
        height:30px;
        width:40px;
        
        border:none;
    }
`;

export const InputDescription = styled.div`
    margin:10px;
    width:350px;

    display:flex;
    flex-direction:column;

    resize: none;
    
    >textarea{
        height:275px;
        width:350px;

        margin-top:10px;
        padding:10px;

        resize: none;
    }
`;

export const End = styled.div`
    width:350px;

    display:flex;
    flex-direction:column;
    justify-content:center;
    align-items:center;

    >button{
        height:30px;
        width:350px;

        border-radius:5px;
        border:none;

        margin: 5px 0 5px 0;
    }

    #AddTarefa{
        background:#1AFF66;
    }

    #Cancel{
        background:#FF3333;
    }
`;

export const Loader = styled.div`
  height: 50px;
  width: 50px;

  position: absolute;
  transform: translate(0%, 500%);

  display: flex;
  flex-direction: row;
  align-items:center;
  justify-content:center;
`;