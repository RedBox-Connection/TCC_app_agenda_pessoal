import React from 'react';
import ReactDOM from 'react-dom';
import Inicial from './pages/Inicial';

import GlobalStyle from './styles/global'

ReactDOM.render(
  <React.StrictMode>
    <Inicial />
    <GlobalStyle />
  </React.StrictMode>,
  document.getElementById('root')
);

