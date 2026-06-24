import { Button } from "@mui/material"
import { FaAngleLeft, FaAngleRight } from "react-icons/fa6"
import MockData from "../../assets/mock-data"
import NoteCard from "../note-card/note-card";
import "./dashboard-carousel.scss";
import { useState } from "react";

interface props{
    title: string,
    type:number,
}

const DashboardCarousel = ({title, type}:props) => {
    const notes = MockData.MockNotes.slice(0, 5);
    const events = MockData.MockCalendarEvents.slice(0,5);
    const [index, setIndex] = useState<number>(0);
    const [direction, setDirection] = useState<string>("");
    const [animate, setAnimate] = useState<boolean>(false);


    const handleButtonClick = (dir:string) => {
        
        if(index > 0 && dir === "left" && !animate){
            setIndex(index - 1)
            setDirection(dir)
            setAnimate(true)
        }
        if(index < notes.length - 1 && dir === "right" && !animate){
            setIndex(index + 1)
            setDirection(dir)
            setAnimate(true)
        }

        setTimeout(() => {
            setAnimate(false)
            setDirection("")
        }, 350)
    }

    return(
        <div className="dashboard-carousel">
            <div className="carousel-panels-wrapper">
                <h2 className="carousel-title">{title}</h2>
                <div className="carousel-panels" style ={{transform:`translateX(-${index * 600}px)`}}>
                {
                    type === 1 
                    ?
                    notes.map((note, i) => {
                        return(
                            <div className={`content-panel ${i !== index ? 'hidden' : ''}`}>
                                <NoteCard key={i} title={note.title} content={note.content} createdAt={note.createdAt} Readonly/>
                            </div>
                        )
                    })
                    :
                    events.map((event,i) => {
                        return(
                            <div className={`content-panel ${i !== index ? 'hidden' : ''}`}>
                                {/* ToDo Calendar event card */}
                            </div>
                        )
                    })
                }
                </div>
            </div>
            <div className="carousel-panels-indicators">
                <Button onClick={() => {handleButtonClick("left")}} disabled = {index === 0 ? true : false} 
                    className={`carousel-pagination-btn ${(animate && direction === "left") ? 'animate-left' : ''}`}><FaAngleLeft /></Button>
                {
                    notes.map((_, i) => {
                        return(
                            <button key={i} className={`panel-indicator ${i === index ? 'active' : ''}`} />
                        )
                    })
                }
                <Button onClick={() => {handleButtonClick("right")}} disabled = {index === 4 ? true : false}
                    className={`carousel-pagination-btn ${(animate && direction === "right") ? 'animate-right' : ''}`}><FaAngleRight /></Button>
            </div>
        </div>
    )
}

export default DashboardCarousel