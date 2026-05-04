import { JSX, useEffect, useState } from "react";
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { addMonths, subDays, lastDayOfMonth, getISODay, format, subMonths } from "date-fns";
import "./calendar-page.scss";
import { FaCaretLeft, FaCaretRight } from "react-icons/fa6";
import { Badge, Button } from "@mui/material";

const CalendarPage = ():JSX.Element => {
    const weekDays = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
    const getMonthDays = (date:Date):number[] => {
        var days = [];
        var diff = getISODay(subDays(date, date.getDate() - 1))
        for(let i = 1 - diff; i<= lastDayOfMonth(date).getDate(); i++)
            i !== 0 && days.push(i);
        return days;
    }
    const clickPlus = () => {
        setCurrentDate(addMonths(currentDate, 1))
        setMonthDays(getMonthDays(addMonths(currentDate, 1)));
        setSelectedDay(addMonths(currentDate, 1).setHours(0,0,0,0) !== new Date().setHours(0, 0, 0, 0) ? 1 : new Date().getDate())
    }
    
    const clickMinus = () => {
        setCurrentDate(subMonths(currentDate, 1))
        setMonthDays(getMonthDays(subMonths(currentDate, 1)));
        setSelectedDay(subMonths(currentDate, 1).setHours(0,0,0,0) !== new Date().setHours(0, 0, 0, 0) ? 1 : new Date().getDate())
    }

    const changeDate = (newDate?:Date | null) => {
        if(newDate != null)
        {
            setCurrentDate(newDate);
            setMonthDays(getMonthDays(newDate))
            setSelectedDay(newDate.setHours(0,0,0,0) !== new Date().setHours(0, 0, 0, 0) ? 1 : new Date().getDate());
        }
    }

    const selectDay = (day:number) => {
        setSelectedDay(day)
        console.log(day);
    }

    const [currentDate, setCurrentDate] = useState<Date>(new Date());
    const [monthDays, setMonthDays] = useState<number[]>(getMonthDays(currentDate))
    const [selectedDay, setSelectedDay] = useState<number>(new Date().getDate());
    
    return(
        <div className="calendar-page">
            <div className="calendar-date-picker">
                <Button onClick={() => {clickMinus()}}><FaCaretLeft /></Button>
                <LocalizationProvider dateAdapter={AdapterDateFns}>
                <DatePicker value={currentDate} 
                    openTo="month"
                    views={['year', 'month']}
                    onChange={(oldVal) => {changeDate(oldVal)}}
                />
                </LocalizationProvider>
                <Button onClick={() => {clickPlus()}}><FaCaretRight /></Button>
            </div>
            <div className="calendar">
                {/* <div className="calendar-header"> */}
                    {
                        weekDays.map((x, i)=> {
                            return(
                                <div className="calendar-header-day" key={i}>{x}</div>
                            )
                        })
                    }
                {/* </div>
                <div className="calendar-days"> */}
                    {
                        monthDays.map((x,i) => {
                            if(x > 0)
                                return (
                                    <div className="calendar-day-wrapper" key={i}>
                                            <span className={`calendar-day 
                                                ${(currentDate.getDate() === x && currentDate.setHours(0, 0, 0, 0) === new Date().setHours(0, 0, 0, 0)) ? 'current-day' : ''}
                                                ${(selectedDay === x ? 'selected-day' : '')}`} onClick={() => selectDay(x)}>
                                                {x}
                                            </span>
                                    </div>
                                )
                            else
                                return <div key={i}></div>
                        })
                    }
                {/* </div> */}
            </div>  
        </div>
    )
}

export default CalendarPage;