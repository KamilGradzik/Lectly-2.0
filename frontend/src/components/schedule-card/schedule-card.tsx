import { JSX } from "react";
import "./schedule-card.scss";

interface props{
    DayOfWeek:number,
    StartTime:string,
    EndTime:string,
    Classroom:string,
    Subject:string,
    Group:string,
}

const ScheduleCard = ({DayOfWeek, StartTime, EndTime, Classroom, Subject, Group}:props):JSX.Element => {
    return(
        <div className="schedule-card">
        </div>
    )
}

export default ScheduleCard