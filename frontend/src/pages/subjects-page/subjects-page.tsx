import { JSX } from "react"
import "./subjects-page.scss"
import MockData from "../../assets/mock-data"
import SubjectCard from "../../components/subject-card/subject-card"
import { FaPlus } from "react-icons/fa6"

const SubjectsPage = ():JSX.Element => {    
    return(
        <div className="subjects-page">
            <div className="subjects-page-content">
                {MockData.MockSubjects.map(x => {
                    return(
                        <SubjectCard title={x.nazwa} desc={x.opis} groupsCount={x.liczba_grup} studensCount={x.liczba_studentow} nextClass={x.najblizsze_zajecia} />
                    )
                })}
                <div className="subject-add">
                    <FaPlus />
                </div>
            </div>
        </div>
    )
}

export default SubjectsPage