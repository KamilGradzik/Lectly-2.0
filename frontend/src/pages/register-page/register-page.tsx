import { Button, FormControl, TextField } from "@mui/material"
import { JSX } from "react"
import "./register-page.scss"
import { Link } from "react-router"

const RegisterPage = ():JSX.Element => {
    return(
        <div className="register-page">
            <div className="register-container">
                <div className="register-container-sub">
                    <div className="register-page-logo">
                        <p className="logo-title">Lectly</p>
                        <p className="logo-subtitle">Supports teachers work!</p>
                    </div>
                </div>
                <div className="register-container-sub">
                    <div className="register-page-form">
                        <FormControl className="register-page-form-field">
                            <TextField  variant="outlined" label="First Name" type="text" autoComplete="off" />
                        </FormControl>
                        <FormControl className="register-page-form-field">
                            <TextField  variant="outlined" label="Last Name" type="text" autoComplete="off" />
                        </FormControl>
                        <FormControl className="register-page-form-field">
                            <TextField  variant="outlined" label="E-mail" type="email" autoComplete="off" />
                        </FormControl>
                        <FormControl className="register-page-form-field">
                            <TextField variant="outlined"  label="Password" type="password" />
                        </FormControl>
                        <FormControl className="register-page-form-field">
                            <Button variant={"contained"} type={"submit"} >sign up</Button>
                        </FormControl>
                    </div>
                    <div className="register-page-utils">
                        <span>Already a user?&nbsp;<Link to="/sign-in">Sign in</Link></span>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default RegisterPage