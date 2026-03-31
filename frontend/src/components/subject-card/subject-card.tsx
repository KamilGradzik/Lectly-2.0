import { JSX, MouseEventHandler } from "react"
import "./subject-card.scss"
import { FaEdit, FaInfoCircle } from "react-icons/fa"
import { FaBars, FaInfo, FaTrash } from "react-icons/fa6"
import { Button } from "@mui/material"

interface props{
    title:string,
    desc:string,
    groupsCount:number,
    studensCount:number,
    closest:string,
    onClick?:MouseEventHandler,
}

const SubjectCard = ({title, desc, groupsCount, studensCount, closest, onClick}:props):JSX.Element => {
    return(
        <div className="subject-card" onClick={onClick}>   
            <div className="subject-card-header">
                <h1>{title}</h1>
            </div>
            <div className="subject-card-body">
                <div className="subject-descirption">
                    <div>

                    </div>
                    <p>{closest}</p>
                </div>
                <div className="subject-card-footer">
                    <Button>details</Button>
                    <div className="subject-card-actions">
                        <FaEdit className="edit-btn"/>
                        <FaTrash className="remove-btn"/>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default SubjectCard