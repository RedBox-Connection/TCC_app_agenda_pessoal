import React from 'react';

import CabecalhoLayout from '../CabecalhoLayout';
import MenuLateral from '../MenuLateral';

import { Container, Main } from './styles';

function Layout() {
  return (
      <Container>
          <CabecalhoLayout />
          <Main>
              <MenuLateral />
              {/* content */}
          </Main>
      </Container>
  );
}

export default Layout;