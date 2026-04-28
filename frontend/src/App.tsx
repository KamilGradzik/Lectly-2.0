import React, { JSX } from 'react';
import { Outlet, redirect, RouterProvider } from 'react-router';
import Routing from './pages/routing';
const token = "";
const App = ():JSX.Element => {

  return (
    <>
      <Outlet />
    </>
  );
}

export default App;
