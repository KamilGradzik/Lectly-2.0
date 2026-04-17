import { JSX } from "react"
import "./note-card.scss"
import { FaTrash } from "react-icons/fa6"
import { FaEdit } from "react-icons/fa"
import moment from "moment"
import { Tooltip } from "@mui/material"

interface props{
    title:string,
    content:string,
    createdAt:string
}


const NoteCard = ({title,content,createdAt}:props):JSX.Element => {

    const formatedDate:string = moment(new Date(createdAt)).format("Do MMM YYYY");

    return(
        <div className="note-card">
            <div className="note-card-header">
                <h1>{title}</h1>
            </div>
            <div className="note-card-body">
                <div className="note-card-content">
                    {content}
                </div>
                <div className="note-card-footer">
                    <span className="note-card-date">
                        {formatedDate}
                    </span>
                    <span className="note-card-action-buttons">
                        <Tooltip title="Edit note">
                            <FaEdit className="edit-btn"/>
                        </Tooltip>
                        <Tooltip title="Remove note">
                            <FaTrash className="remove-btn"/>
                        </Tooltip>
                        
                    </span>
                </div>
            </div>
        </div>
    )
}

export default NoteCard