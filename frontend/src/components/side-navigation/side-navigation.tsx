import { JSX } from "react"
import "./side-navigation.scss"
import { Link, Navigate, redirect, replace } from "react-router";
import { FaRightFromBracket, FaCalendar, FaNoteSticky, FaUsers, FaClock, FaGaugeHigh, FaGraduationCap, FaPenRuler } from "react-icons/fa6";

const SideNavigation = ():JSX.Element => {
    const singOutClick = ():Response => {
        console.log("cuo");
        return replace("/sign-in");
    }

    return(
        <div className="side-nav-container">
            <div className="side-nav-header">
                <span>Hello&nbsp;<Link to="profile">USER_PLACEHOLDER</Link></span>
            </div>
            <div className="side-nav-body">
                <ul className="nav-links">
                    <li><Link to="/dashboard"><FaGaugeHigh />dashboard</Link></li>
                    <li><Link to="/dashboard"><FaClock />class schedule</Link></li>
                    <li><Link to="/dashboard"><FaCalendar  />calendar</Link></li>
                    <li><Link to="/dashboard"><FaUsers />class groups</Link></li>
                    <li><Link to="/dashboard"><FaGraduationCap />students</Link></li>
                    <li><Link to="/dashboard"><FaPenRuler />subjects</Link></li>
                    <li><Link to="/dashboard"><FaNoteSticky />notes</Link></li>
                </ul>
                <div className="side-nav-footer">
                    <span onClick={() => singOutClick()}>sign out <FaRightFromBracket /></span>
                </div>
            </div>
        </div>
    )
}

export default SideNavigation;