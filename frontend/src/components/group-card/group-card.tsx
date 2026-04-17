import { JSX } from "react"
import "./group-card.scss"
import { FaEdit, } from "react-icons/fa"
import { FaClock, FaGraduationCap, FaPenRuler, FaTrash, FaUsers } from "react-icons/fa6"
import { Button, Tooltip } from "@mui/material"

interface props{
    title:string,
    subjectsCount:number,
    studentsCount:number,
    nextClass:string,
}

const GroupCard = ({title, subjectsCount, studentsCount, nextClass}:props):JSX.Element => {
    return(
        <div className="group-card">   
            <div className="group-card-header">
                <h1>{title}</h1>
            </div>
            <div className="group-card-body">
                <div className="group-info">
                    <div className="group-numbers">
                        <Tooltip title="Subjects">
                            <span><FaPenRuler /> {subjectsCount}</span>
                        </Tooltip>
                        <Tooltip title="Students">
                            <span><FaGraduationCap /> {studentsCount}</span>
                        </Tooltip>
                        
                    </div>
                    <div className="group-next-classes">
                        <Tooltip title="Next classes">
                            <p><FaClock />{nextClass}</p>
                        </Tooltip>
                    </div>
                    
                </div>
                <div className="group-card-footer">
                    <Button>details</Button>
                    <div className="group-card-actions">
                        <Tooltip title="Edit group">
                            <FaEdit className="edit-btn"/>
                        </Tooltip>
                        <Tooltip title="Remove group" >
                            <FaTrash className="remove-btn"/>
                        </Tooltip>
                        
                    </div>
                </div>
            </div>
        </div>
    )
}

export default GroupCard