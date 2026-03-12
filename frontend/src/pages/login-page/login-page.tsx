import { Button, FormControl, TextField } from "@mui/material"
import { JSX } from "react"
import "./login-page.scss"
import { Link } from "react-router"

const LoginPage = ():JSX.Element => {
    return(
        <>
            <div className="login-container">
                <div className="login-container-sub">
                    <div className="login-page-logo">
                        <p className="logo-title">Lectly</p>
                        <p className="logo-subtitle">Supports teachers work!</p>
                    </div>
                </div>
                <div className="login-container-sub">
                    <div className="login-page-form">
                        <FormControl className="login-page-form-field">
                            <TextField  variant="outlined" label="E-mail" type="email" autoComplete="off" />
                        </FormControl>
                        <FormControl className="login-page-form-field">
                            <TextField variant="outlined"  label="Password" type="password" />
                        </FormControl>
                        <FormControl className="login-page-form-field">
                            <Button variant={"contained"} type={"submit"} >sign in</Button>
                        </FormControl>
                    </div>
                    <div className="login-page-utils">
                        <Link to="/sign-up">Create Account</Link>
                        <a href="#">Forgot password</a>
                    </div>
                </div>
            </div>
        </>
    )
}

export default LoginPage