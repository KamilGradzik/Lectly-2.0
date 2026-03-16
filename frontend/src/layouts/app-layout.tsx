import { Outlet } from "react-router"
import SideNavigation from "../components/side-navigation/side-navigation"
import { Divider } from "@mui/material"

const AppLayout = () => {
    return(
        <div className="app-main">
            <SideNavigation />
            <div className="app-content">
                <Outlet />
            </div>
        </div>
    )
}

export default AppLayout