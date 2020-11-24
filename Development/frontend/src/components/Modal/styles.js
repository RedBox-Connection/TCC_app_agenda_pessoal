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
    width:450px;
    margin-top:10vh;

    display:flex;
    flex-direction:column;
    align-items:center;
    justify-content:space-between;

    overflow:hidden;
    overflow:auto;

    border: 5px solid;

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
        width:400px;
        margin:10px;
        padding:10px;
    }
`;

export const InputWrapper = styled.div`
    margin:10px 0 10px 0;

    >input{
        height:30px;
        width:197px;
        margin-right:5px;
    }
    >button{
        height:30px;
        width:40px;
        
        border:none;
    }
`;

export const InputColor = styled.div`
    >h5{
        margin-left:10px;
    }

    >div{
        #colorInput{
            height:30px;
            width:315px;
            margin:0 5px 10px 10px;

            background:none;
        }

        #colorButton{
            height:30px;
            width:83px;
            margin:0 10px 10px 0px;
        }
    }
`;

export const InputDescription = styled.div`
    margin:10px;
    width:400px;

    display:flex;
    flex-direction:column;
    
    >textarea{
        height:225px;
        width:400px;
        margin-top:10px;
        padding:10px;
        resize:none;
    }
`;

export const TodoArea = styled.div`

`;

export const End = styled.div`
    width:350px;

    display:flex;
    flex-direction:row;
    justify-content:space-between;
    align-items:center;

    margin-top:25px;

    >button{
        background-color: transparent;
        border:none;
    }
`;