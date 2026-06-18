import { Button } from "@mui/material"
import { JSX } from "react"

const QuickActions = ():JSX.Element => {
    return(
        <div className="quick-actions">
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"></div>
                    <div className="sub-icon"></div>
                </div>
                <p className="quick-action-text">class group</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"> </div>
                    <div className="sub-icon"></div>
                </div>
                <p className="quick-action-text">subject</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"> </div>
                    <div className="sub-icon"></div>
                </div>
                <p className="quick-action-text">student</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"> </div>
                    <div className="sub-icon"></div>
                </div>
                <p className="quick-action-text">grade</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"> </div>
                    <div className="sub-icon"></div>
                </div>
                <p className="quick-action-text">event</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"> </div>
                    <div className="sub-icon"></div>
                </div>
                <p className="quick-action-text">class schedule</p>
            </Button>
            <Button className="quick-action-btn">
                <div className="quick-action-glyph">
                    <div className="icon"> </div>
                    <div className="sub-icon"></div>
                </div>
                <p className="quick-action-text">note</p>
            </Button>
        </div>
    )
}

export default QuickActions