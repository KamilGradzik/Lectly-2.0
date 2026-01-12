import { Button, Divider, FormControl, Link, TextField } from "@mui/material"
import { JSX } from "react"
import "./login-page.scss"

const LoginPage = ():JSX.Element => {
    return(
        <div className="login-page">
            <div className="login-container">
                <div className="login-container-sub">
                    <div className="login-page-logo">
                        <p className="logo-title">Lectly</p>
                        <p className="logo-subtitle">Supports teachers work!</p>
                    </div>
                </div>
                <Divider />
                <div className="login-container-sub">
                    <div className="login-page-form">
                        <FormControl className="login-page-form-field">
                            <TextField  variant="outlined" label="E-mail" type="email" autoComplete="off" />
                        </FormControl>
                        <FormControl className="login-page-form-field">
                            <TextField variant="outlined"  label="Password" type="password" />
                        </FormControl>
                        <Link href="#">Forgot password</Link>
                        <FormControl className="login-page-form-field">
                            <Button variant={"contained"} type={"submit"} >LOG IN</Button>
                        </FormControl>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default LoginPage