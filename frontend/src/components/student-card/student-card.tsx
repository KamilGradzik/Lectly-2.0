import { JSX } from "react";
import "./student-card.scss";

interface props{
    studentCode:string,
    firstName:string,
    lastName:string,
    additionalInfo:string,
}

const StudentCard = ({studentCode, firstName, lastName, additionalInfo}:props):JSX.Element => {


    return(
        <div className="student-card">
            <div className="student-avatar">
                <span>{firstName.substring(0,1)}{lastName.substring(0,1)}</span>
            </div>
            <div className="student-credentials">
                <p className="student-fullname">{firstName}&nbsp;{lastName}</p>
                <p className="student-code">{studentCode}</p>
            </div>
            <div className="student-info">
                <p>{additionalInfo}</p>
            </div>
        </div>
    )
}

export default StudentCard