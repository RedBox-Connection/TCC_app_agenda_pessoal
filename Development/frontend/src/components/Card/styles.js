import styled, { css } from 'styled-components';

export const CardContent = styled.div`
    #Card-Button{
        height:75px;
        width:225px;
        margin:10px;

        display:flex;
        flex-direction:row;
        align-items:center;

        border-radius:7px;
        border:none;
        box-shadow: 0 2px 5px 0 rgba(192, 208, 203, 0.8);
    }

    ${props => props.isDragging && css`
        height:75px;
        width:225px;
        margin:10px;

        border: 2px dashed rgba(0,0,0,0.2);
        border-radius:0;

        background:transparent;
        box-shadow:none;

        button{
            opacity:0;
        }
    `}
`;

export const Content = styled.div`
    display:flex;
    flex-direction:row;
    align-items:center;
    justify-content:center;

    padding:5px;
`;

