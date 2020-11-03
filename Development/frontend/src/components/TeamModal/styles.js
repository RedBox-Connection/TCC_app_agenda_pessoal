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
    justify-content:space-between;

    border:5px solid ${props => props.color};

    overflow:hidden;
    overflow:auto;

    >button{
        background-color:transparent;

        margin-top:10px;

        display:flex;
        align-items:center;
        justify-content:center;

        border:none;
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
        width:150px;
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
    
    >textarea{
        height:250px;
        margin-top:10px;
        padding:10px;
    }
`;

export const End = styled.div`
    width:350px;

    display:flex;
    flex-direction:row;
    justify-content:space-between;
    align-items:center;

    >button{
        background-color: transparent;
        border:none;
    }
`;

export const Comment = styled.div`
    background-color:#f2f2f2;
    
    width:350px;
    height:200px;
    margin-top:10px;

    display:flex;
    flex-direction:row;

    border-radius:7px;
    border:none;

    >input {
        height:30px;
        margin:10px;
        width:225px;
        padding:10px;
    }

    >button {
        height:30px;
        width:100px;
        margin-top:10px;
        
        background-color:lightskyblue;

        border:none;
    }
`;
