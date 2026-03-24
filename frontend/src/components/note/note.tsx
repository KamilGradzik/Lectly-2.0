import { JSX } from "react"
import "./note.scss"
import { FaTrash } from "react-icons/fa6"
import { FaEdit } from "react-icons/fa"
import moment from "moment"

interface props{
    title:string,
    content:string,
    createdAt:string
}


const Note = ({title,content,createdAt}:props):JSX.Element => {

    const formatedDate = moment(new Date(createdAt)).format("Do MMM YYYY");

    return(
        <div className="note-card">
            <div className="note-card-header">
                <p>{title}</p>
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
                        <button className="edit-btn"><FaEdit /></button>
                        <button className="remove-btn"><FaTrash /></button>
                    </span>
                </div>
            </div>
        </div>
    )
}

export default Note