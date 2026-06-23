import { JSX, useEffect, useState } from "react";
import { DatePicker } from '@mui/x-date-pickers';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { addMonths, subDays, lastDayOfMonth, getISODay, subMonths, setDate } from "date-fns";
import "./calendar-page.scss";
import { FaAngleLeft, FaAngleRight, FaPlus } from "react-icons/fa6";
import { Button, FormControl, InputLabel, MenuItem, Select } from "@mui/material";
import MockData from "../../assets/mock-data";
import EventCard from "../../components/event-card/event-card";

const CalendarPage = ():JSX.Element => {
    const weekDays = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
    const dates = MockData.MockCalendarIndicators;
    const getMonthDays = (date:Date):number[] => {
        var days = [];
        var diff = getISODay(subDays(date, date.getDate() - 1))
        for(let i = 1 - diff; i<= lastDayOfMonth(date).getDate(); i++)
            i !== 0 && days.push(i);
        return days;
    }
    const clickNext = ():void => {
        setCurrentDate(addMonths(currentDate, 1))
        setMonthDays(getMonthDays(addMonths(currentDate, 1)));
        setSelectedDay(addMonths(currentDate, 1).setHours(0,0,0,0) !== new Date().setHours(0, 0, 0, 0) ? 1 : new Date().getDate())
    }
    
    const clickPrevious = ():void => {
        setCurrentDate(subMonths(currentDate, 1))
        setMonthDays(getMonthDays(subMonths(currentDate, 1)));
        setSelectedDay(subMonths(currentDate, 1).setHours(0,0,0,0) !== new Date().setHours(0, 0, 0, 0) ? 1 : new Date().getDate())
    }

    const changeDate = (newDate:Date | null):void => {
        if(newDate != null)
        {
            setCurrentDate(newDate);
            setMonthDays(getMonthDays(newDate))
            setSelectedDay(newDate.setHours(0,0,0,0) !== new Date().setHours(0, 0, 0, 0) ? 1 : new Date().getDate());
        }
    }

    const selectDay = (day:number):void => {
        setSelectedDay(day)
        console.log(containsEvents(day))
    }

    const containsEvents = (day:number):boolean => {
        var testDate = setDate(currentDate, day)
        var existingDate = dates.find(x =>
            new Date(x.data).setHours(0,0,0,0) === testDate.setHours(0,0,0,0))
        if (existingDate)
            return true;
        return false;
    }

    const [currentDate, setCurrentDate] = useState<Date>(new Date());
    const [monthDays, setMonthDays] = useState<number[]>(getMonthDays(currentDate))
    const [selectedDay, setSelectedDay] = useState<number>(new Date().getDate());
    const [pickerOpen, setPickerOpen] = useState<boolean>(false)
    
    return(
        <div className="calendar-page">
            <div className="calendar-date-picker">
                <Button onClick={() => {clickPrevious()}}><FaAngleLeft /></Button>
                    <LocalizationProvider dateAdapter={AdapterDateFns}>
                        <DatePicker value={currentDate}
                            openTo="month"
                            views={['year', 'month']}
                            onChange={(dateValue) => {changeDate(dateValue)}}
                            open={pickerOpen}
                            slots={{openPickerButton: () => null}}
                            slotProps={{
                                popper:{placement: "bottom", modifiers: [{name:"offset", options:{offset:[0,8]}}]},
                                textField:{onClick: () => {setPickerOpen(!pickerOpen)}}
                            }}
                            onOpen={() => {setPickerOpen(true)}}
                            onClose={() => {setPickerOpen(false)}}
                        />
                    </LocalizationProvider>
                <Button onClick={() => {clickNext()}}><FaAngleRight /></Button>
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
                                            <span className={`events-indicator ${containsEvents(x) ? '' : 'hidden'}`}></span>
                                    </div>
                                )
                            else
                                return <div key={i}></div>
                        })
                    }
                {/* </div> */}
            </div>
            <div className="calendar-actions">
                <div className="action-wrapper">
                    <FormControl fullWidth>
                        <InputLabel>Event Type</InputLabel>
                        <Select label="Event type">
                            <MenuItem value={0}>Exam</MenuItem>
                            <MenuItem value={1}>Meeting</MenuItem>
                            <MenuItem value={2}>Field Trip</MenuItem>
                            <MenuItem value={3}>Event</MenuItem>
                            <MenuItem value={4}>Deadline</MenuItem>
                        </Select>
                    </FormControl> 
                </div>
                <div className="action-wrapper">
                    <Button className="add-event-btn">Add <FaPlus/></Button>
                </div>
            </div>
            <div className="calendar-events">
                {
                    MockData.MockCalendarEvents.map((x,i) => {
                        return(
                            <EventCard key={i} name={x.nazwa} beginDate={new Date(x.data_poczatkowa)} endDate={new Date(x.data_koncowa)} type={x.typ} />
                        )
                    })
                }
                {/* <h3 className="no-events-msg">No events on this day!</h3> */}
            </div>  
        </div>
    )
}

export default CalendarPage;