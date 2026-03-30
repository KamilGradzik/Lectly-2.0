import { createBrowserRouter } from "react-router";
import LoginPage from "../pages/login-page/login-page";
import RegisterPage from "../pages/register-page/register-page";
import App from "../App";
import AuthLayout from "../layouts/auth-layout";
import AppLayout from "../layouts/app-layout";
import NotesPage from "../pages/notes-page/notes-page";
import SubjectsPage from "../pages/subjects-page/subjects-page";



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
                {path: "dashboard"},
                {path: "class-schedule"},
                {path: "calendar"},
                {path: "class-groups"},
                {path: "students"},
                {path: "subjects", Component: SubjectsPage},
                {path: "notes", Component: NotesPage},
                {path: "profile"}
            ]}
        ]
    }
]);

export default Routing;