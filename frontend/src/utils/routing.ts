import { createBrowserRouter, redirect } from "react-router";
import LoginPage from "../pages/login-page/login-page";
import RegisterPage from "../pages/register-page/register-page";
import App from "../App";
import AuthLayout from "../layouts/auth-layout";
import AppLayout from "../layouts/app-layout";



const Routing = createBrowserRouter([
    {
        path: "/",
        Component: App,
        children:[
            {Component: AuthLayout, children:[
                {path: "sign-in", Component: LoginPage},
                {path: "sign-up", Component: RegisterPage},
            ]},
            {Component:AppLayout, children:[
            ]}
        ]
    }
]);

export default Routing;