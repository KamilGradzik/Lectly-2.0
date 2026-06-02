import { JSX, useState } from "react";
import WeekDays from "../../utils/WeekDay";
import MockData from "../../assets/mock-data";
import "./schedule-page.scss";
import ScheduleCard from "../../components/schedule-card/schedule-card";
import { Button, MenuItem, Select, SelectChangeEvent } from "@mui/material";
import { FaPlus } from "react-icons/fa6";
import { da } from "date-fns/locale";

const SchedulePage = ():JSX.Element => {
    const [selectedDay, setSelectedDay] = useState<string>(new Date().getDay().toString())

    const handleDayChange = (event:SelectChangeEvent) => {
        setSelectedDay(event.target.value.toString())
    }

    return(
        <div className="schedule-page">
            <div className="schedule-actions">
                <Select value={selectedDay} onChange={(event:SelectChangeEvent) => {setSelectedDay(event.target.value.toString())}}>
                    {WeekDays.map((x,i) => {
                        return(
                            <MenuItem value={x.DayNumber}>{x.DayName}</MenuItem>
                        )
                    })}
                    <MenuItem value={7}>Entire Week</MenuItem>
                </Select>
                <Button>Add <FaPlus /></Button>
            </div>
            <div className="schedule">
                {
                    selectedDay === "7"
                    ?
                    <>
                        {
                            WeekDays.map((day, index) => {
                                return(
                                    <div key={index} className="schedule-day">
                                        <div className="schedule-day-name">
                                            <h2>{day.DayName}</h2>
                                        </div>
                                        <div className="schedule-day-entries">
                                            {
                                                MockData.MockScheduleEntries.map((entry, index) => {
                                                    if(entry.Dzien === day.DayNumber)
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
                    </>
                    :
                    <>
                        {
                            MockData.MockScheduleEntries.filter((x) => x.Dzien === parseInt(selectedDay)).map((entry, index) => {
                                return(
                                    <ScheduleCard 
                                        key={index} 
                                        DayOfWeek={entry.Dzien} 
                                        StartTime={entry.Poczatek} 
                                        EndTime={entry.Koniec}
                                        Subject={entry.Nazwaprzedmiotu}
                                        Classroom={entry.Classroom}
                                        Group={entry.Grupa}
                                    />
                                )
                            })
                        }
                    </>
                }
                {/* {
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
                } */}
            </div>
        </div>
    )
}   

export default SchedulePage