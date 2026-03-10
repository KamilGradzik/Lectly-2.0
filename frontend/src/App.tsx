import React, { JSX } from 'react';
import { Outlet, redirect, RouterProvider } from 'react-router';
import Routing from './utils/routing';
const token = "";
const App = ():JSX.Element => {

  return (
    <div className="App">
      <Outlet />
    </div>
  );
}

export default App;
