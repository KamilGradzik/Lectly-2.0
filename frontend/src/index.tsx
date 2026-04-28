import React from 'react';
import ReactDOM from 'react-dom/client';
import "./styles/index.scss"
import reportWebVitals from './utils/reportWebVitals';
import { RouterProvider } from 'react-router';
import Routing from './pages/routing';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <RouterProvider router={Routing} />
  </React.StrictMode>
);

reportWebVitals();
