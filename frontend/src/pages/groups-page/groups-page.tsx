import { JSX } from "react"
import "./groups-page.scss"
import MockData from "../../assets/mock-data"
import { FaMagnifyingGlass, FaPlus } from "react-icons/fa6"
import GroupCard from "../../components/group-card/group-card"
import { TextField, InputAdornment, Button } from "@mui/material"

const GroupsPage = ():JSX.Element => {    
    return(
        <div className="groups-page">
            <div className="groups-page-actions">
                <div className="action-wrapper search-group">
                    <TextField placeholder="Search..." variant="outlined" slotProps={{
                        input:{ endAdornment:(
                                <InputAdornment position="end">
                                    <FaMagnifyingGlass />
                                </InputAdornment>
                            )}
                        }}
                    />
                </div>
                <div className="action-wrapper add-group">
                    <Button className="add-group-btn">Add group<FaPlus /></Button>
                </div>
            </div>
            <div className="groups-page-content">
                {MockData.MockGroups.map(x => {
                    return(
                        <GroupCard title={x.nazwa} desc={x.opis} subjectsCount={x.liczba_przedmiotow} studentsCount={x.liczba_studentow} nextClass={x.najblizsze_zajecia} />
                    )
                })}
            </div>
        </div>
    )
}

export default GroupsPage