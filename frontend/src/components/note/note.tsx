import { JSX } from "react"
import "./note.scss"
import { Button } from "@mui/material"
import { FaStar, FaTrash } from "react-icons/fa6"
import { FaEdit } from "react-icons/fa"

interface props{
    title:string,
    content:string,
    createdAt:string
}

const Note = ({title,content,createdAt}:props):JSX.Element => {
    return(
        <div className="note-card">
            <div className="note-card-header">
                <p className="note-card-title">{title}</p>
                <p className="note-card-subtitle">{createdAt}</p>
            </div>
            <div className="note-card-content">{content}</div>
            <div className="note-card-footer">
                <Button><FaStar /></Button>
                <Button><FaEdit /></Button>
                <Button><FaTrash /></Button>
            </div>
        </div>
    )
}

export default Note