import { JSX, useState } from "react";
import "./dashboard-page.scss";
import { compareDesc, format } from "date-fns";
import { Link, NavigateFunction, useNavigate } from "react-router";
import { Button, Divider } from "@mui/material";
import { FaGraduationCap, FaPenRuler, FaUsers } from "react-icons/fa6";
import ClassesCarousel from "../../components/classes-carousel/classes-carousel";
import QuickActions from "../../components/quick-actions/quick-actions";
import EventsCarousel from "../../components/events-carousel/events-carousel";
import NotesCarousel from "../../components/notes-carousel/notes-carousel";

const DashboardPage = ():JSX.Element => {
    const navigate:NavigateFunction = useNavigate();
    const currentDate = new Date();
    
    const greetingsByTime = ():string => {
        if(compareDesc(currentDate, new Date().setHours(5,0,0,0)) === -1 && compareDesc(currentDate, new Date().setHours(11,59,59,999)) === 1)
            return "Good Morning"
        else if(compareDesc(currentDate, new Date().setHours(16,59,59,999)) === 1)
            return "Good Afternoon"
        return "Good Evening"
    }   

    return(
        <div className="dashboard-page">
            <div className="dashboard-header">
                <h1 className="welcome-text">{greetingsByTime()}, <Link to="/profile">Jan Nowak</Link>!</h1>
                <span className="current-date">{format(new Date(), 'do MMM yyyy, EEEE')}</span>
            </div>
            <div className="dashboard-content">
                <div className="general-statistics-wrapper">
                    <div className="general-statistics">
                        <Button className="statistic-item" onClick={() => {navigate("/class-groups")}}>
                            <h2 className="statistic-title"><FaUsers />Class Groups</h2>
                            <p className="statistic-content">8</p>
                        </Button>
                        <Button className="statistic-item" onClick={() => {navigate("/subjects")}}>
                            <h2 className="statistic-title"><FaPenRuler />Subjects</h2>
                            <p className="statistic-content">8</p>
                        </Button>
                        <Button className="statistic-item" onClick={() => {navigate("/students")}}>
                            <h2 className="statistic-title"><FaGraduationCap />Students</h2>
                            <p className="statistic-content">122</p>
                        </Button>
                    </div>
                    <Divider />
                    <QuickActions />
                </div>
                <div className="class-schedule">
                    <h2>Today's Classes</h2>
                    <ClassesCarousel />
                </div>
                <div className="event-notes-wrapper">
                    <EventsCarousel />
                    <NotesCarousel />
                </div>
            </div>
        </div>
    )
}

export default DashboardPage