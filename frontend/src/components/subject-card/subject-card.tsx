import { JSX } from "react"
import "./subject-card.scss"
import { FaEdit, } from "react-icons/fa"
import { FaClock, FaGraduationCap, FaTrash, FaUsers } from "react-icons/fa6"
import { Button, Tooltip } from "@mui/material"

interface props{
    title:string,
    groupsCount:number,
    studentsCount:number,
    nextClass:string
}

const SubjectCard = ({title, groupsCount, studentsCount, nextClass}:props):JSX.Element => {
    return(
        <div className="subject-card">   
            <div className="subject-card-header">
                <h1>{title}</h1>
            </div>
            <div className="subject-card-body">
                <div className="subject-info">
                    <div className="subject-numbers">
                        <span title="Class groups"><FaUsers /> {groupsCount}</span>
                        <span title="Students"><FaGraduationCap /> {studentsCount}</span>
                    </div>
                    <div className="subject-next-classes">
                        <p title="Next classes"><FaClock />{nextClass}</p>
                    </div>
                    
                </div>
                <div className="subject-card-footer">
                    <Button>details</Button>
                    <div className="subject-card-actions">
                        <Tooltip title="Edit subject">
                            <FaEdit className="edit-btn"/>
                        </Tooltip>
                        <Tooltip title="Remove subject" >
                            <FaTrash className="remove-btn"/>
                        </Tooltip>
                        
                    </div>
                </div>
            </div>
        </div>
    )
}

export default SubjectCard