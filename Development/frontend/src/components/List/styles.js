import styled from 'styled-components';

export const Container = styled.div`
    padding:0 15px;
    height:100%;

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

    #Add {
       width:42px;
       height:42px;
       border-radius:10px;
       background:var(--azul-primario);
       border: 0;
       cursor:pointer; 
    }

    ul {
        margin-top:30px;
    }
`;