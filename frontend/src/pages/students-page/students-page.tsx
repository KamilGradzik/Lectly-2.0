import { Button, InputAdornment, Pagination, TextField } from "@mui/material";
import { JSX } from "react";
import { FaMagnifyingGlass, FaPlus } from "react-icons/fa6";
import "./students-page.scss"
import MockData from "../../assets/mock-data";
import StudentCard from "../../components/student-card/student-card";

const StudentsPage = ():JSX.Element => {
    return(
        <div className="students-page">
            <div className="students-page-header">
                <TextField label="Search" variant="outlined" slotProps={{
                    input:{ endAdornment:(
                        <InputAdornment position="end">
                            <FaMagnifyingGlass />
                        </InputAdornment>
                    )}
                }}  />
                <span>
                    {/* <Button variant="outlined" id="filters-btn" onClick={filtersClick}>Sort<FaSort /></Button> */}
                    <Button variant="contained" id="create-btn">Add<FaPlus /></Button>
                </span>
                {/* <Popover id={"filters-list"} open={isOpen} onClose={handlePopoverClose} anchorEl={anchorElement} anchorOrigin={{vertical:"bottom", horizontal:"right"}} transformOrigin={{vertical:"top", horizontal:"right"}}>
                    <List>
                        <ListItemButton>
                            <ListItemText primary="Title" />&nbsp;<FaSortAlphaDown />
                        </ListItemButton>
                        <ListItemButton>
                            <ListItemText primary="Title" />&nbsp;<FaSortAlphaUp />
                        </ListItemButton>
                        <ListItemButton>
                            <ListItemText primary="Date" />&nbsp;<FaSortAmountDownAlt />
                        </ListItemButton>
                        <ListItemButton>
                            <ListItemText primary="Date" />&nbsp;<FaSortAmountUpAlt />
                        </ListItemButton>
                    </List>
                </Popover> */}
            </div>
            <div className="students-page-content">
                <div className="students-container">
                    {MockData.MockStudents.map((x) => {
                        return(
                            <StudentCard firstName={x.firstName} lastName={x.lastName} studentCode={x.studentCode} additionalInfo={x.additionalInfo} studentGroups={x.studentGroups}/>
                        )
                    })}
                </div>
                <div className="students-paggination">
                    <Pagination count={10}/>
                </div>
            </div>
        </div>
    )
}

export default StudentsPage