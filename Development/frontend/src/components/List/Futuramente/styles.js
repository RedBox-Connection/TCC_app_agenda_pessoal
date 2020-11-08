import styled from 'styled-components';

export const Container = styled.div`
    padding:0 15px;
    height:100%;
    width:275px;
    & + div {
        border-left: 1px solid rgba(0, 0, 0, 0.1);
    }

    header {
        display:flex;
        align-items: center;
        justify-content:space-between;

        height:42px
    }

    h3 {
        padding:0 10px;
    }

    ul {
        margin-top:15px;
    }
`;