import { Button } from "@mui/material";
import { JSX, useState } from "react";
import { FaAngleUp, FaAngleDown } from "react-icons/fa6";
import ScheduleCard from "../schedule-card/schedule-card";
import MockData from "../../assets/mock-data";
import "./classes-carousel.scss";

const ClassesCarousel = ():JSX.Element => {
    const scheduleEntries = MockData.MockScheduleEntries.filter(x => x.Dzien === 2)
    const [index, setIndex] = useState<number>(0);
    const [carouselLock, setCarouselLock] = useState<boolean>(false)
    const [animate, setAnimate] = useState<boolean>(false)
    const [direction, setDirection] = useState<string>("")
    
    const handleCarouselWheelEvent = (e:React.WheelEvent) => {
        e.preventDefault();
        if(carouselLock) return
        
        if(e.deltaY > 0 &&  index < scheduleEntries.length - 1){
            //Scroll Down
            setIndex(index + 1)
            setAnimate(true);
            setDirection("down")
            setCarouselLock(true)
        }
        else if(e.deltaY < 0 && index > 0 ){
            //Scroll Up
            setIndex(index - 1)
            setAnimate(true);
            setDirection("up")
            setCarouselLock(true);
        }
        
        setTimeout(() => {
            setCarouselLock(false)
            setDirection("")
            setAnimate(false)
        }, 400)
    }

    const handleCarouselArrowClick = (direction:string) => {
        if(carouselLock) return

        if(direction === "upwards" && index > 0){
            setIndex(index - 1)
            setAnimate(true);
            setDirection("up")
            setCarouselLock(true);
        }
        else if(direction === "downwards" && index < scheduleEntries.length - 1){
            setIndex(index + 1)
            setAnimate(true);
            setDirection("down")
            setCarouselLock(true);
        }

        setTimeout(() => {
            setDirection("")
            setAnimate(false)
            setCarouselLock(false)
        }, 400)
    }

    const maxDots = 5;

    let start = Math.max(0, index - Math.floor(maxDots / 2));
    let end = start + maxDots;

    if (end > scheduleEntries.length) {
        end = scheduleEntries.length;
        start = Math.max(0, end - maxDots);
    }

    const visibleDots = scheduleEntries.slice(start, end);

    return(
        <>
        {
            scheduleEntries.length > 0
            ?
            <div className="class-schedule-carousel" onWheel={(e:React.WheelEvent) => {handleCarouselWheelEvent(e)}}>
                <div className="carousel-panels" style ={{transform:`translateY(-${index * 225}px)`}}>
                    {
                        scheduleEntries.map((entry) => {
                            return(
                                <ScheduleCard
                                    key={entry.Id}
                                    DayOfWeek={entry.Dzien}
                                    StartTime={entry.Poczatek}
                                    EndTime={entry.Koniec}
                                    Subject={entry.Nazwaprzedmiotu}
                                    Classroom={entry.Classroom}
                                    Group={entry.Grupa}
                                    Readonly
                                />
                            )
                        })
                    }
                </div>
                <div className="carousel-pagination">
                    <Button disabled={index === 0 ? true : false} className={`carousel-pagination-btn ${(animate && direction === "up") ? 'animate-up' : ''}`}
                        onClick={() => handleCarouselArrowClick("upwards")}><FaAngleUp /></Button>
                    <div className={`carousel-pagination-indicators`}>
                    {
                        visibleDots.map((_, i) => {
                            const actualIndex = start + i;
                            return(
                                <button 
                                    className={`dot-indicator ${actualIndex === index ? 'active' : ''}`}
                                    // style={{}}
                                />
                            )
                        })
                    }
                    </div>
                    <Button disabled={index === scheduleEntries.length - 1 ? true : false} className={`carousel-pagination-btn ${(animate && direction === "down") ? 'animate-down' : ''}`}
                        onClick={() => handleCarouselArrowClick("downwards")}><FaAngleDown /></Button>
                </div>
            </div>
            :
            <div className="empty-section-entries">
                <h3>No scheduled classes for today!</h3>
            </div>
        }
        </>
    )
}

export default ClassesCarousel