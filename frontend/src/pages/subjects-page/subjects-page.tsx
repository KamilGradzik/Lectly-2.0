import { JSX } from "react"
import "./subjects-page.scss"
import MockData from "../../assets/mock-data"
import SubjectCard from "../../components/subject-card/subject-card"

const SubjectsPage = ():JSX.Element => {
    return(
        <>
        {MockData.MockSubjects.map(x => {
            return(
                <SubjectCard title={x.nazwa} desc={x.opis} groupsCount={x.liczba_grup} studensCount={x.liczba_studentow} closest={x.najblizsze_zajecia} />
            )
        })}
        </>
    )
}

export default SubjectsPage