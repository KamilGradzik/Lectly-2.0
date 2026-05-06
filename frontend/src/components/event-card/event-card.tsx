import { JSX } from "react";
import "./event-card.scss";
import EvenType from "../../utils/EventType";
import { format } from "date-fns";
import { FaRegCalendar, FaRegClock, FaTrash } from "react-icons/fa6";
import { IoIosArrowRoundForward } from "react-icons/io"
import { Button, Tooltip } from "@mui/material";
import { FaEdit, FaLongArrowAltRight } from "react-icons/fa";

interface props{
    name:string,
    beginDate:Date,
    endDate:Date,
    type:EvenType
}

const parseEventType = (type:EvenType):string => {
    if(EvenType[type] === "FieldTrip")
        return "Field Trip"
    return EvenType[type];
}

const EventCard = ({name, beginDate, endDate, type}:props):JSX.Element => {
    return(
        <div className={`calendar-event-card ${EvenType[type].toLocaleLowerCase()}`}>
            <p className={`event-type ${EvenType[type].toLocaleLowerCase()}`}>
                {parseEventType(type)} 
                <span className="event-actions">
                    <Tooltip title="Edit Event">
                        <Button className="edit-event-btn"><FaEdit /></Button>
                    </Tooltip>
                    <Tooltip title="Remove Event">
                        <Button className="remove-event-btn"><FaTrash /></Button>
                    </Tooltip>
                    
                </span>
            </p>
            <h1 className="event-title">{name}</h1>
            <div className="event-dates">
                {
                    new Date(beginDate).setHours(0,0,0,0) !== new Date(endDate).setHours(0,0,0,0) 
                    ? 
                        <div className="event-date-range">
                            <FaRegCalendar />
                            <span className="event-date">{format(beginDate, 'dd/MM/yyyy  HH:mm')}</span>
                            <IoIosArrowRoundForward  />
                            <span className="event-date">{format(endDate, 'dd/MM/yyyy  HH:mm')}</span> 
                        </div>
                    : 
                    <>
                        <div className="event-date-range">
                            <FaRegCalendar />
                            <span className="event-date">{format(beginDate, 'dd/MM/yyyy')}</span>
                        </div>
                        <div className="event-date-range">
                            <FaRegClock />
                            <span className="event-date">{format(beginDate, 'HH:mm')}</span>
                            <IoIosArrowRoundForward  />
                            <span className="event-date">{format(endDate, 'HH:mm')}</span>
                        </div>
                        
                    </>
                }
            </div>
        </div>
    )
}

export default EventCard