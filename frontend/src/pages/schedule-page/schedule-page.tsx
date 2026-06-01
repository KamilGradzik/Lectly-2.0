import { JSX } from "react";
import WeekDays from "../../utils/WeekDay";
import MockData from "../../assets/mock-data";
import "./schedule-page.scss";
import ScheduleCard from "../../components/schedule-card/schedule-card";

const SchedulePage = ():JSX.Element => {
    
    return(
        <div className="schedule-page">
            <div className="schedule">
                {
                    WeekDays.map((x,i) => {
                        return(
                            <div key={i} className="schedule-day">
                                <div className="schedule-day-name">
                                    <h2>{x.DayName}</h2>
                                </div>
                                <div className="schedule-day-entries">
                                    {
                                        MockData.MockScheduleEntries.map((entry, index) => {
                                            if(entry.Dzien === x.DayNumber)
                                            return(
                                                <ScheduleCard 
                                                    key={index} 
                                                    DayOfWeek={entry.Dzien} 
                                                    StartTime={entry.Poczatek} 
                                                    EndTime={entry.Koniec}
                                                    Subject={entry.Nazwaprzedmiotu}
                                                    Classroom={entry.Classroom}
                                                    Group={entry.Grupa}
                                                />)
                                        })
                                    }
                                </div>
                            </div>
                        )
                    })
                }
            </div>
        </div>
    )
}   

export default SchedulePage