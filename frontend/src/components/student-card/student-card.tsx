import { JSX } from "react";
import "./student-card.scss";
import { Tooltip } from "@mui/material";
import { FaCircleInfo, FaEllipsisVertical, FaInfo, FaTrash } from "react-icons/fa6";
import { FaEdit } from "react-icons/fa";

interface props{
    studentCode:string,
    firstName:string,
    lastName:string,
    additionalInfo:string,
    studentGroups:Array<string>
}

const StudentCard = ({studentCode, firstName, lastName, additionalInfo, studentGroups}:props):JSX.Element => {
    
    return(
        <div className="student-card">
            <div className="student-data">
                <div className="student-info">
                    <h1 className="student-fullname">{firstName}&nbsp;{lastName}</h1>
                    <h2 className="student-code">{studentCode}</h2>
                </div>
                <div className="student-desc">
                    <p>{additionalInfo}</p>
                </div>
            </div>  
            <div className="student-groups">
                {studentGroups.map((x, i) => {
                    return(
                        <span key={i} className="group-badge">{x}</span>
                    )
                })}
            </div>
            <div className="student-actions">
                <Tooltip title="Student Details">
                    <FaCircleInfo className="details-btn"/>
                </Tooltip>
                <Tooltip title="Edit Student">
                    <FaEdit className="edit-btn"/>
                </Tooltip> 
                <Tooltip title="Remove Student">
                    <FaTrash className="remove-btn"/>
                </Tooltip>
            </div>
        </div>
    )
}

export default StudentCard