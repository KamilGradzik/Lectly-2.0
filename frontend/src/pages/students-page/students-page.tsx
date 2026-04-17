import { Button, InputAdornment, List, ListItemButton, ListItemText, Pagination, Popover, Select, TextField } from "@mui/material";
import { JSX, useState } from "react";
import { FaMagnifyingGlass, FaPlus, FaSort } from "react-icons/fa6";
import "./students-page.scss"
import MockData from "../../assets/mock-data";
import StudentCard from "../../components/student-card/student-card";
import { FaSortAlphaDown, FaSortAlphaUp, FaSortAmountDownAlt, FaSortAmountUpAlt } from "react-icons/fa";

const StudentsPage = ():JSX.Element => {
    const [anchorElement, setAnchorElement] = useState<HTMLButtonElement | null>(null);
    const isOpen = Boolean(anchorElement);
    
    const filtersClick = (event:React.MouseEvent<HTMLButtonElement>):void => {
        setAnchorElement(event.currentTarget);
    }
    
    const handlePopoverClose = () => {
        setAnchorElement(null);
    }

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
                <div className="students-page-actions">
                    <Select />
                    <Button variant="outlined" id="filters-btn" onClick={filtersClick}>Sort<FaSort /></Button>
                    <Button variant="contained" id="create-btn">Add<FaPlus /></Button>
                </div>
                <Popover id={"filters-list"} open={isOpen} onClose={handlePopoverClose} anchorEl={anchorElement} anchorOrigin={{vertical:"bottom", horizontal:"right"}} transformOrigin={{vertical:"top", horizontal:"right"}}>
                    <List>
                        <ListItemButton>
                            <ListItemText primary="Student's name" />&nbsp;<FaSortAlphaDown />
                        </ListItemButton>
                        <ListItemButton>
                            <ListItemText primary="Student's name" />&nbsp;<FaSortAlphaUp />
                        </ListItemButton>
                    </List>
                </Popover>
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