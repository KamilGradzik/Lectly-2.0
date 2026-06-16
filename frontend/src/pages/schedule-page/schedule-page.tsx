import { JSX, useState } from "react";
import WeekDays from "../../utils/WeekDay";
import MockData from "../../assets/mock-data";
import "./schedule-page.scss";
import ScheduleCard from "../../components/schedule-card/schedule-card";
import { Button, FormControl, FormControlLabel, MenuItem, Select, SelectChangeEvent } from "@mui/material";
import { FaPlus } from "react-icons/fa6";

const SchedulePage = ():JSX.Element => {
    const [selectedDay, setSelectedDay] = useState<string>(new Date().getDay().toString())

    return(
        <div className="schedule-page">
            <div className="schedule-actions">
                <div className="action-wrapper">
                    <FormControl fullWidth>
                        <Select value={selectedDay} onChange={(event:SelectChangeEvent) => {setSelectedDay(event.target.value.toString())}} title="Day of week">
                            {WeekDays.map((x,i) => {
                                return(
                                    <MenuItem key={i} value={x.DayNumber}>{x.DayName}</MenuItem>
                                )
                            })}
                            <MenuItem value={7}>Entire Week</MenuItem>
                        </Select>
                    </FormControl>
                </div>
                <div className="action-wrapper">
                    <Button className="schedule-classes-btn">Schedule <FaPlus /></Button>
                </div>
            </div>
            <div className="schedule">
                {
                    selectedDay === "7"
                    ?
                    <>
                        {
                            WeekDays.map((day, index) => {
                                var dayEntries = MockData.MockScheduleEntries.filter(x => x.Dzien === day.DayNumber)
                                console.log(dayEntries.length);
                                return(
                                    <div key={index} className="schedule-day">
                                        <div className="schedule-day-name">
                                            <h1>{day.DayName}</h1>
                                        </div>
                                        <div className="schedule-day-entries">
                                            {   
                                                dayEntries.length > 0 
                                                ?
                                                dayEntries.map((entry, index) => {
                                                    return(
                                                        <ScheduleCard 
                                                            key={index} 
                                                            DayOfWeek={entry.Dzien} 
                                                            StartTime={entry.Poczatek} 
                                                            EndTime={entry.Koniec}
                                                            Subject={entry.Nazwaprzedmiotu}
                                                            Classroom={entry.Classroom}
                                                            Group={entry.Grupa}
                                                            Readonly={false}
                                                    />)
                                                })
                                                :
                                                <h3 className="empty-day-entries">No scheduled classes!</h3>
                                            }
                                        </div>
                                    </div>
                                )
                            }) 
                        }
                    </>
                    :
                    <div className="schedule-day">
                        <div className="schedule-day-name">
                            <h1>{WeekDays.filter(x => x.DayNumber === parseInt(selectedDay))[0].DayName}</h1>
                        </div>
                        <div className="schedule-day-entries">
                            {
                                (() => {
                                    const dayEntries = MockData.MockScheduleEntries.filter(x => x.Dzien === parseInt(selectedDay))
                                    
                                    return dayEntries.length > 0 
                                        ? dayEntries.map((entry) => (
                                            <ScheduleCard
                                                key={entry.Id}
                                                DayOfWeek={entry.Dzien}
                                                StartTime={entry.Poczatek}
                                                EndTime={entry.Koniec}
                                                Subject={entry.Nazwaprzedmiotu}
                                                Classroom={entry.Classroom}
                                                Group={entry.Grupa}
                                                Readonly={false}
                                            />
                                        )) 
                                        : <h3 className="empty-day-entries">No scheduled classes!</h3>
                                    })
                                ()
                            }                       
                        </div>
                    </div>
                }
            </div>
        </div>
    )
}   

export default SchedulePage