import { JSX } from "react"
import "./side-navigation.scss"
import { Link } from "react-router";
import SpeedIcon from '@mui/icons-material/Speed';
import SchoolIcon from '@mui/icons-material/School';
import ScienceIcon from '@mui/icons-material/Science';
import GroupsIcon from '@mui/icons-material/Groups';
import ScheduleIcon from '@mui/icons-material/Schedule';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import StickyNote2Icon from '@mui/icons-material/StickyNote2';
import LogoutIcon from '@mui/icons-material/Logout';

const SideNavigation = ():JSX.Element => {
    return(
        <div className="side-nav-container">
            <div className="side-nav-header">
                <span>Hello&nbsp;<Link to="profile">USER_NAME</Link></span>
            </div>
            <div className="side-nav-body">
                <ul className="nav-links">
                    <li><Link to="/dashboard"><SpeedIcon /> dashboard</Link></li>
                    <li><Link to="/dashboard"><SchoolIcon /> class groups</Link></li>
                    <li><Link to="/dashboard"><ScienceIcon /> subjects</Link></li>
                    <li><Link to="/dashboard"><GroupsIcon /> students</Link></li>
                    <li><Link to="/dashboard"><ScheduleIcon /> class schedule</Link></li>
                    <li><Link to="/dashboard"><CalendarMonthIcon /> calendar</Link></li>
                    <li><Link to="/dashboard"><StickyNote2Icon /> notes</Link></li>
                </ul>
            </div>
            <div className="side-nav-footer">
                <span>logout <LogoutIcon /></span>
            </div>
        </div>
    )
}

export default SideNavigation;