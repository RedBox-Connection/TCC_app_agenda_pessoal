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
        height:25px;
        width:25px;
    }
    
    .edit-icon{
        height:25px;
        width:25px;
    }
`;