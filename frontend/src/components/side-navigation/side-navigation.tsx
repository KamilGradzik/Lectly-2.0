import { JSX } from "react"
import "./side-navigation.scss"
import { Link, matchPath, Navigate, NavLink, redirect, replace, useLocation } from "react-router";
import { FaRightFromBracket, FaCalendar, FaNoteSticky, FaUsers, FaClock, FaGaugeHigh, FaGraduationCap, FaPenRuler, FaUser } from "react-icons/fa6";




const SideNavigation = ():JSX.Element => {
    const location = useLocation();

    return(
        <div className="side-nav-container">
            <div className="side-nav-header">
                <p>Lectly</p>
            </div>
            <div className="side-nav-body">
                <div className="nav-links">
                    <NavLink className={({isActive}) => (isActive ? "nav-link nav-link-active" : "nav-link")} to="/dashboard"><span><FaGaugeHigh />dashboard</span></NavLink>
                    <NavLink className={({isActive}) => (isActive ? "nav-link nav-link-active" : "nav-link")} to="/class-schedule"><span><FaClock />class schedule</span></NavLink>
                    <NavLink className={({isActive}) => (isActive ? "nav-link nav-link-active" : "nav-link")} to="/calendar"><span><FaCalendar  />calendar</span></NavLink>
                    <NavLink className={({isActive}) => (isActive ? "nav-link nav-link-active" : "nav-link")} to="/class-groups"><span><FaUsers />class groups</span></NavLink>
                    <NavLink className={({isActive}) => (isActive ? "nav-link nav-link-active" : "nav-link")} to="/students"><span><FaGraduationCap />students</span></NavLink>
                    <NavLink className={({isActive}) => (isActive ? "nav-link nav-link-active" : "nav-link")} to="/subjects"><span><FaPenRuler />subjects</span></NavLink>
                    <NavLink className={({isActive}) => (isActive ? "nav-link nav-link-active" : "nav-link")}to="/notes"><span><FaNoteSticky />notes</span></NavLink>
                </div>
                <div className="side-nav-footer">
                    <span>profile <FaUser /></span>
                    <span>sign out <FaRightFromBracket /></span>
                </div>
            </div>
        </div>
    )
}

export default SideNavigation;