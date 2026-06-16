import { JSX, useState } from "react";
import "./dashboard-page.scss";
import { compareDesc, format } from "date-fns";
import { Link, NavigateFunction, useNavigate } from "react-router";
import { Button } from "@mui/material";
import { FaAngleDown, FaAngleUp, FaArrowUp, FaGraduationCap, FaPenRuler, FaUsers } from "react-icons/fa6";
import MockData from "../../assets/mock-data";
import WeekDays from "../../utils/WeekDay";
import ScheduleCard from "../../components/schedule-card/schedule-card";

const DashboardPage = ():JSX.Element => {
    const navigate:NavigateFunction = useNavigate();
    const currentDate = new Date();
    const dayEntries = MockData.MockScheduleEntries.filter(x => x.Dzien === currentDate.getDay())
    const GreetingsByTime = ():string => {
        if(compareDesc(currentDate, new Date().setHours(5,0,0,0)) === -1 && compareDesc(currentDate, new Date().setHours(11,59,59,999)) === 1)
            return "Good Morning"
        else if(compareDesc(currentDate, new Date().setHours(16,59,59,999)) === 1)
            return "Good Afternoon"
        return "Good Evening"
    }   

    const [index, setIndex] = useState<number>(0);

    const handleCarouselWheelEvent = (e:WheelEvent) => {
        // e.preventDefault();
        if(e.deltaY > 0 && index < dayEntries.length - 1){
            setIndex(index + 1)
            console.log('scroll down')
        }
        else if(e.deltaY < 0 && index > 0){
            setIndex(index - 1)
            console.log('scroll up')
        }
    }

    return(
        <div className="dashboard-page">
            <div className="dashboard-header">
                <h1 className="welcome-text">{GreetingsByTime()}, <Link to="/profile">Jan Nowak</Link>!</h1>
                <span className="current-date">{format(new Date(), 'do MMM yyyy, EEEE')}</span>
            </div>
            <div className="dashboard-content">
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
                    {/* <Button className="statistic-item">
                        
                    </Button> */}
                </div>
                <div className="class-schedule">
                    <h2>Today's Classes</h2>
                    {
                        dayEntries.length > 0 
                        ?
                        <div className="class-schedule-carousel" onWheel={(e:any) => {handleCarouselWheelEvent(e)}}>
                            <div className="schedule-entries" style ={{transform:`translateY(-${index * 225}px)`}}>
                                {
                                    dayEntries.map((entry) => {
                                        return(
                                            <ScheduleCard
                                                key={entry.Id}
                                                DayOfWeek={entry.Dzien}
                                                StartTime={entry.Poczatek}
                                                EndTime={entry.Koniec}
                                                Subject={entry.Nazwaprzedmiotu}
                                                Classroom={entry.Classroom}
                                                Group={entry.Grupa}
                                                Readonly
                                            />
                                        )
                                    })
                                }
                            </div>
                            <div className="carousel-pagination">
                                <FaAngleUp />
                                <div className="carousel-pagination-indicators">
                                {
                                    dayEntries.map((_, i) => {
                                        return(
                                            <button 
                                                className={`dot-indicator ${i === index ? 'active' : ''}`}
                                            />
                                        )
                                    })
                                }
                                </div>
                                <FaAngleDown />
                            </div>
                        </div>
                        :
                        <h3 className="empty-day-entries">No scheduled classes for today!</h3>
                    }
                </div>
            </div>
        </div>
    )
}

export default DashboardPage