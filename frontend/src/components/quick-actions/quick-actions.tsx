import { Button } from "@mui/material"
import { JSX } from "react"
import { FaCalendar, FaClipboardCheck, FaClock, FaGraduationCap, FaNoteSticky, FaPenRuler, FaPlus, FaUsers } from "react-icons/fa6";
import "./quick-actions.scss";

const QuickActions = ():JSX.Element => {
    return(
        <div className="quick-actions">
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"><FaUsers /></div>
                    <div className="sub-icon">+</div>
                </div>
                <p className="quick-action-text">class group</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"><FaPenRuler /></div>
                    <div className="sub-icon">+</div>
                </div>
                <p className="quick-action-text">subject</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"><FaGraduationCap /></div>
                    <div className="sub-icon">+</div>
                </div>
                <p className="quick-action-text">student</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"><FaClipboardCheck /></div>
                    <div className="sub-icon">+</div>
                </div>
                <p className="quick-action-text">grade</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"><FaCalendar /></div>
                    <div className="sub-icon">+</div>
                </div>
                <p className="quick-action-text">event</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"><FaClock /></div>
                    <div className="sub-icon">+</div>
                </div>
                <p className="quick-action-text">class schedule</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"><FaNoteSticky /></div>
                    <div className="sub-icon">+</div>
                </div>
                <p className="quick-action-text">note</p>
            </Button>
        </div>
    )
}

export default QuickActions