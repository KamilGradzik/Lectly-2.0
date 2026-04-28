import { JSX, useEffect, useState } from "react";
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { addMonths, subDays, lastDayOfMonth, getISODay, format, subMonths } from "date-fns";
import "./calendar-page.scss";
import { FaCaretLeft, FaCaretRight } from "react-icons/fa6";

const CalendarPage = ():JSX.Element => {
    const weekDays = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
    const getMonthDays = (date:Date):number[] => {
        var days = [];
        var diff = getISODay(subDays(date, date.getDate() - 1))
        console.log(diff);
        for(let i = 1 - diff; i<= lastDayOfMonth(date).getDate(); i++)
            i !== 0 && days.push(i);
        return days;
    }
    const clickPlus = () => {
        setCurrentDate(addMonths(currentDate, 1))
        setMonthDays(getMonthDays(addMonths(currentDate, 1)));
    }
    
    const clickMinus = () => {
        setCurrentDate(subMonths(currentDate, 1))
        setMonthDays(getMonthDays(subMonths(currentDate, 1)));
    }

    const changeDate = (newDate?:Date | null) => {
        if(newDate != null)
        {
            setCurrentDate(newDate);
            setMonthDays(getMonthDays(newDate));
        }
    }

    const [currentDate, setCurrentDate] = useState<Date>(new Date());
    const [monthDays, setMonthDays] = useState<number[]>(getMonthDays(currentDate))
    
    return(
        <div className="calendar-page">
            <button onClick={() => {clickMinus()}}><FaCaretLeft /></button>
            <LocalizationProvider dateAdapter={AdapterDateFns}>
                <DatePicker value={currentDate} 
                    openTo="month"
                    views={['year', 'month']}
                    onChange={(oldVal) => {changeDate(oldVal)}}
                />
            </LocalizationProvider>
            <button onClick={() => {clickPlus()}}><FaCaretRight /></button>
            <div className="calendar">
                {/* <div className="calendar-header"> */}
                    {
                        weekDays.map((x, i)=> {
                            return(
                                <div key={i}>{x}</div>
                            )
                        })
                    }
                {/* </div>
                <div className="calendar-days"> */}
                    {
                        monthDays.map((x,i) => {
                            if(x > 0)
                                return <div key={i}>{x}</div>
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