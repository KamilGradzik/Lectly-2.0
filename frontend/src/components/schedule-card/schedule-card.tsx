import { JSX } from "react";
import "./schedule-card.scss";
import { IoIosArrowRoundForward } from "react-icons/io";
import { FaClock, FaDoorOpen, FaTrash, FaUserGroup } from "react-icons/fa6";
import { FaEdit } from "react-icons/fa";
import { Button, Tooltip } from "@mui/material";

interface props{
    DayOfWeek:number,
    StartTime:string,
    EndTime:string,
    Classroom:string,
    Subject:string,
    Group:string,
    Readonly:boolean
}

const ScheduleCard = ({DayOfWeek, StartTime, EndTime, Classroom, Subject, Group, Readonly}:props):JSX.Element => {
    const startTime:string = StartTime.substring(0, 5)
    const endTime:string = EndTime.substring(0, 5)
    return(
        <div className="schedule-entry-card">
            <div className="schedule-entry-header">
                <h2 className="schedule-entry-title">{Subject}</h2>
                {
                    !Readonly ? 
                        <div className="schedule-entry-actions">
                            <Tooltip title="Edit Classes"><Button className="edit-class-btn"><FaEdit /></Button></Tooltip>
                            <Tooltip title="Remove Classes"><Button className="remove-class-btn"><FaTrash /></Button></Tooltip>
                        </div>
                    :
                    <></>
                }
            </div>
            <div className="schedule-entry-details">
                <p className="schedule-entry-timespan"><FaClock />{startTime} <IoIosArrowRoundForward /> {endTime}</p>
                <p className="schedule-entry-classroom"><FaDoorOpen />{Classroom}</p>
                <p className="schedule-entry-group"><FaUserGroup />{Group}</p>
            </div>
            
        </div>
    )
}

export default ScheduleCard