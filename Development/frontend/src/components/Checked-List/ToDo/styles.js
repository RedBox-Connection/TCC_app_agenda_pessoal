import styled from 'styled-components';

export const Container = styled.div`
    height:50px;
    width:325px;
    margin:10px;
    padding:10px;

    border-radius:5px;
    border:none;

    display:flex;
    flex-direction:row;
    align-items:center;
    justify-content:space-between;

    background:#b3b3ff;

`;

export const TodoText = styled.div`

`;

export const Icons = styled.div`
    .delete-icon{
        height:30px;
        width:60px;
        background:#ff3333;
        border:none;
        margin:5px;
    }
    
    .edit-icon{
        height:30px;
        width:60px;
        background:#ffff80;
        border:none;
        margin:5px;
    }
`;