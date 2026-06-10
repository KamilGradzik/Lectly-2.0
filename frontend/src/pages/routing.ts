import { createBrowserRouter } from "react-router";
import LoginPage from "../pages/login-page/login-page";
import RegisterPage from "../pages/register-page/register-page";
import App from "../App";
import AuthLayout from "../layouts/auth-layout";
import AppLayout from "../layouts/app-layout";
import NotesPage from "../pages/notes-page/notes-page";
import SubjectsPage from "../pages/subjects-page/subjects-page";
import StudentsPage from "../pages/students-page/students-page";
import GroupsPage from "../pages/groups-page/groups-page";
import CalendarPage from "./calendar-page/calendar-page";
import SchedulePage from "./schedule-page/schedule-page";
import DashboardPage from "./dashboard-page/dashboard-page";



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
                {path: "dashboard", Component: DashboardPage},
                {path: "class-schedule", Component: SchedulePage},
                {path: "calendar", Component: CalendarPage},
                {path: "class-groups", Component: GroupsPage},
                {path: "students", Component: StudentsPage},
                {path: "subjects", Component: SubjectsPage},
                {path: "notes", Component: NotesPage},
                {path: "profile"}
            ]}
        ]
    }
]);

export default Routing;