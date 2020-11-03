import styled from 'styled-components';

export const ContainerTodoForm = styled.div`
    margin-top:10px;

    display:flex;
    flex-direction:row;
    align-items:center;
    justify-content:center;
`;

export const TodoFormContent = styled.div`
    height:30px;
    width:350px;
    padding:10px;

    display:flex;
    flex-direction:row;
    align-items:center;
    justify-content:space-between;

    #todo-input{
        height:30px;
        width:225px;
        padding:10px;
        margin-bottom:25px;
        margin-top:25px;

        border:none;
    }

    #todo-button{
        height:30px;
        padding:10px;
        margin-bottom:25px;
        margin-top:25px;

        background:lightskyblue;

        border:none;
    }

`;

export const TodoFormContentEdit = styled.div`
    height:30px;
    width:300px;

    display:flex;
    flex-direction:row;
    align-items:center;
    justify-content:space-between;

    #todo-input-edit{
        height:30px;
        width:200px;
        padding:10px;

        border:none;
    }

    #todo-button-edit{
        height:30px;
        padding:10px;

        background:#ffff80;

        border:none;
    }
`;