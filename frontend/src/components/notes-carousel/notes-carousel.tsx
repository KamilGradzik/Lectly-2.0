import { Button } from "@mui/material"
import { FaAngleLeft, FaAngleRight } from "react-icons/fa6"
import MockData from "../../assets/mock-data"
import NoteCard from "../note-card/note-card";
import "./notes-carousel.scss";
import { useState } from "react";

const NotesCarousel = () => {
    const notes = MockData.MockNotes.slice(0, 5);
    const [index, setIndex] = useState<number>(0);
    const [direction, setDirection] = useState<string>("");

    const handleButtonClick = (direction:string) => {
        
        if(index > 0 && direction === "left"){
            setIndex(index - 1)
        }
        if(index < notes.length - 1 && direction === "right"){
            setIndex(index + 1)
        }
    }

    return(
        <div className="notes-carousel">
            <div className="carousel-panels-wrapper">
                <Button onClick={() => {handleButtonClick("left")}}><FaAngleLeft /></Button>
                <div className="carousel-slider">
                    <div className="carousel-panels" style ={{transform:`translateX(-${index * 585}px)`}}>
                    {
                        notes.map((note, i) => {
                            return(
                                <div className={`content-panel ${i !== index ? 'hidden' : ''}`}>
                                    <NoteCard key={i} title={note.title} content={note.content} createdAt={note.createdAt} />
                                </div>
                            )
                        })
                    }
                    </div>
                </div>
                <Button onClick={() => {handleButtonClick("right")}}><FaAngleRight /></Button>
            </div>
            <div className="carousel-panels-indicators">
                {
                    notes.map((_, i) => {
                        return(
                            <button key={i} className={`panel-indicator ${i === index ? 'active' : ''}`} />
                        )
                    })
                }
            </div>
        </div>
    )
}

export default NotesCarousel