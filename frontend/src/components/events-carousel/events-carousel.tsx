import { JSX } from "react"
import MockData from "../../assets/mock-data"
import EventCard from "../event-card/event-card"

const EventsCarousel = ():JSX.Element => {
    const events = MockData.MockCalendarEvents.slice(0,5)
    
    return(
        <div className="events-carousel">
            <div className="carousel-panels">
                {
                    events.map((event, i) => {
                        return(
                            <EventCard name={event.nazwa} beginDate={new Date(event.data_poczatkowa)} endDate={new Date(event.data_koncowa)} type={event.typ} />
                        )
                    })
                }
            </div>
            <div className="carousel-pagination">
                
            </div>
        </div>
    )
}

export default EventsCarousel