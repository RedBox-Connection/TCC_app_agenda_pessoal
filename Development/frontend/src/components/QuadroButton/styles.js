import styled from 'styled-components';

export const Container = styled.div`
  display:flex;
  flex-shrink:0;

  height:80px;
  width:200px;

  padding:5px 8px;
  margin:10px 5px;

  border-radius:5px;
  border:none;

  background-color:#d4d4d4;

  font-size:18px;

  overflow:hidden;

  > p {
    height: 100%;
    width: 100%;
  }
`;
