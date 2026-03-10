import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import "./styles/index.scss"
import reportWebVitals from './utils/reportWebVitals';
import { RouterProvider } from 'react-router';
import Routing from './utils/routing';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <RouterProvider router={Routing} />
  </React.StrictMode>
);

reportWebVitals();
