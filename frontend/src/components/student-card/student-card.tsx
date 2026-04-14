import { JSX } from "react";
import "./student-card.scss";

interface props{
    studentCode:string,
    firstName:string,
    lastName:string,
    additionalInfo:string,
    studentGroups:Array<string>
}

const StudentCard = ({studentCode, firstName, lastName, additionalInfo, studentGroups}:props):JSX.Element => {


    return(
        <div className="student-card">
            <div className="student-info">
                <h1 className="student-fullname">{firstName}&nbsp;{lastName}</h1>
                <h2 className="student-code">{studentCode}</h2>
            </div>
            <div className="student-desc">
                <p>{additionalInfo}</p>
            </div>  
            <div className="student-groups">
                {studentGroups.map((x, i) => {
                    if(i < 3)
                        return(
                            <span className="group-badge">{x}</span>
                        )
                    else if(i == studentGroups.length - 1)
                        return(
                            <span>{studentGroups.length - 3} more...</span>
                    )
                })}
            </div>
            <div>

            </div>
        </div>
    )
}

export default StudentCard