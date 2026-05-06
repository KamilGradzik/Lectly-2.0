import { JSX } from "react"
import "./subject-card.scss"
import { FaEdit, FaInfoCircle, } from "react-icons/fa"
import { FaClock, FaGraduationCap, FaInfo, FaTrash, FaUsers } from "react-icons/fa6"
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
                        <Tooltip title="Class Groups">
                            <span><FaUsers /> {groupsCount}</span>
                        </Tooltip>
                        <Tooltip title="Students">
                            <span><FaGraduationCap /> {studentsCount}</span>
                        </Tooltip>
                    </div>
                    <div className="subject-next-classes">
                        <p><FaClock />{nextClass}</p>
                    </div>
                    
                </div>
                <div className="subject-card-actions">
                    <Tooltip title="Subject Details">
                        <Button className="info-btn">
                            <FaInfoCircle />
                        </Button>
                    </Tooltip>
                    <Tooltip title="Edit Subject">
                        <Button className="edit-btn">
                            <FaEdit/>
                        </Button>
                        
                    </Tooltip>
                    <Tooltip title="Remove Subject" >
                        <Button className="remove-btn">
                            <FaTrash />
                        </Button>
                    </Tooltip>
                </div>
            </div>
        </div>
    )
}

export default SubjectCard