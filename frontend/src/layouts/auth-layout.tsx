import { Outlet } from "react-router"

const AuthLayout = () => {
    return(
        <div className="auth-main">
            <Outlet />
        </div>
    )
}

export default AuthLayout;