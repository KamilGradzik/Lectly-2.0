import { JSX } from "react"
import "./groups-page.scss"
import MockData from "../../assets/mock-data"
import { FaPlus } from "react-icons/fa6"
import GroupCard from "../../components/group-card/group-card"

const GroupsPage = ():JSX.Element => {    
    return(
        <div className="groups-page">
            <div className="groups-page-content">
                {MockData.MockGroups.map(x => {
                    return(
                        <GroupCard title={x.nazwa} subjectsCount={x.liczba_przedmiotow} studentsCount={x.liczba_studentow} nextClass={x.najblizsze_zajecia} />
                    )
                })}
                <div className="group-add">
                    <FaPlus />
                </div>
            </div>
        </div>
    )
}

export default GroupsPage