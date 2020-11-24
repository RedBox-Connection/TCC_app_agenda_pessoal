import styled from 'styled-components';

export const Container = styled.div`
    display:flex;
    flex-direction:column;
    align-items:center;
`;

export const ListItem = styled.div`
    display:flex;
    flex-direction:row;
    align-items:center;
    justify-content:space-between; 

    height:35px;
    width:350px;  

    border-radius:5px;
    border:none;

    background:#ecf1f8;

    input{
        height:15px;
        width:15px;
        margin-left:5px;
    }                                                                          
`;