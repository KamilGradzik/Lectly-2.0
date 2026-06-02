import { JSX } from "react";
import "./schedule-card.scss";
import { IoIosArrowRoundForward } from "react-icons/io";
import { FaClock, FaUserGroup } from "react-icons/fa6";

interface props{
    DayOfWeek:number,
    StartTime:string,
    EndTime:string,
    Classroom:string,
    Subject:string,
    Group:string,
}

const ScheduleCard = ({DayOfWeek, StartTime, EndTime, Classroom, Subject, Group}:props):JSX.Element => {
    const startTime:string = StartTime.substring(0, 5)
    const endTime:string = EndTime.substring(0, 5)
    return(
        <div className="schedule-entry-card">
            <h1 className="schedule-entry-header">{Subject}</h1>
            <div className="schedule-entry-details">
                <p className="schedule-entry-timespan"><FaClock /> {startTime} <IoIosArrowRoundForward /> {endTime}</p>
                <p className="schedule-entry-classroom">{Classroom}</p>
                <p className="schedule-entry-group"><FaUserGroup /> {Group}</p>
            </div>
            
        </div>
    )
}

export default ScheduleCard