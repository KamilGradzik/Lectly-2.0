import { Outlet } from "react-router"
import SideNavigation from "../components/side-navigation/side-navigation"
import { Divider } from "@mui/material"

const AppLayout = () => {
    return(
        <div className="app-main">
            {/* <div className="app-header">
                <div className="app-title">
                    <p className="title">Lectly</p>
                    <p className="subtitle">Supports teachers work!</p>
                </div>
            </div> */}
            <div className="app-container">
                <SideNavigation />
                <div className="vertical-divider"></div>
                <div className="app-content">
                    <Outlet />
                </div>
            </div>
        </div>
    )
}

export default AppLayout