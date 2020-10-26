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
    width:400px;
    margin-top:10vh;

    display:flex;
    flex-direction:column;
    align-items:center;

    border-radius:7px;
    border:none;

    >button{
        background-color:transparent;

        margin-top:10px;

        display:flex;
        align-items:center;
        justify-content:center;

        border:none;
    }
`;

export const Color = styled.div`
    background-color: lightgreen;
    
    height:10px;
    width:400px;

    border-radius:7px;
    border:none;
`;

export const InputTitle = styled.div`
    >input{
        height:30px;
        width:350px;
        margin:10px;
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
    }
`;

export const InputDescription = styled.div`
    margin:10px;
    width:350px;

    display:flex;
    flex-direction:column;
    
    >input{
        height:30px;
        margin-top:10px;
    }
`;

export const CheckBox = styled.div`
    background-color:lightgrey;
    
    width:350px;
    height:250px;
    margin-top:10px;

    display:flex;
    flex-direction:column;
    justify-content:center;
    align-items:center;

    border-radius:7px;
    border:none;

    >button{
        height:30px;
        width:150px;
        
        background-color:lightskyblue;

        border-radius:7px;
        border:none;
    }
`;

export const End = styled.div`
    width:350px;
    margin-top:45px;

    display:flex;
    flex-direction:row;
    justify-content:space-between;
    align-items:center;

    >button{
        background-color: transparent;
        border:none;
    }
`;