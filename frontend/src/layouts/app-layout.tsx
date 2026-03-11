import { Outlet } from "react-router"
import SideNavigation from "../components/side-navigation/side-navigation"

const AppLayout = () => {
    return(
        <>
            <SideNavigation />
            <Outlet />
        </>
    )
}

export default AppLayout