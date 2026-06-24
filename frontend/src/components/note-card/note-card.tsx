import { JSX } from "react"
import "./note-card.scss"
import { format } from "date-fns";
import { FaTrash } from "react-icons/fa6"
import { FaEdit } from "react-icons/fa"
import { Button, Tooltip } from "@mui/material"

interface props{
    title:string,
    content:string,
    createdAt:string,
    Readonly?:boolean,
}


const NoteCard = ({title,content,createdAt, Readonly = false}:props):JSX.Element => {

    const formatedDate:string = format(new Date(createdAt), 'do MMM yyyy')

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
                    {
                        !Readonly 
                        ?
                        <span className="note-card-action-buttons">
                            <Tooltip title="Edit Note">
                                <Button className="note-edit-btn">
                                    <FaEdit />
                                </Button>
                            </Tooltip>
                            <Tooltip title="Remove Note">
                                <Button className="note-remove-btn">
                                    <FaTrash />
                                </Button>
                            </Tooltip>
                        </span>
                        :
                        <></>
                    }
                </div>
            </div>
        </div>
    )
}

export default NoteCard