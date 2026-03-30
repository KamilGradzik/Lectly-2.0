import { JSX } from "react"
import "./subject-card.scss"

interface props{
    title:string,
    desc:string,
    groupsCount:number,
    studensCount:number,
    closest:string,
}

const SubjectCard = ({title, desc, groupsCount, studensCount, closest}:props):JSX.Element => {
    return(
        <div className="subject-card">   
            <div className="subject-card-header">
                <h1>{title}</h1>
            </div>
            <div className="subject-card-body">
                <div className="subject-descirption">
                    <p>{desc}</p>
                </div>
                <div className="">

                </div>
            </div>
        </div>
    )
}

export default SubjectCard