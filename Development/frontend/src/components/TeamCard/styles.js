import styled from 'styled-components';

export const CardContent = styled.div`
    > button{
        height:75px;
        width:175px;
        margin:10px;

        display:flex;
        flex-direction:row;
        align-items:center;
        justify-content:space-between;

        border-radius:7px;
        border:none;
        box-shadow: 0 1px 4px 0 rgba(192, 208, 203, 0.8);

        cursor:grab;
    }
`;

export const Color = styled.div`
    background-color:lightskyblue;

    height:73px;
    width:10px;

    border-radius:7px;
    border:none;
`;

export const Content = styled.div`
    display:flex;
    flex-direction:row;
    align-items:center;
    justify-content:center;

    padding:5px;

    > h3{
        margin-right:15px;
    }
`;

