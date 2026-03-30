import { Button, InputAdornment, List, ListItemButton, ListItemText, Pagination, Popover, TextField } from "@mui/material";
import { JSX, useState } from "react";
import { FaFilter, FaMagnifyingGlass, FaPlus, FaSort } from "react-icons/fa6";
import "./notes-page.scss"
import Note from "../../components/note-card/note-card";
import { FaSortAlphaDown, FaSortAlphaUp,  FaSortAmountDownAlt, FaSortAmountUpAlt } from "react-icons/fa";
import MockData from "../../assets/mock-data";
import NoteCard from "../../components/note-card/note-card";

const NotesPage = ():JSX.Element => {

    const [anchorElement, setAnchorElement] = useState<HTMLButtonElement | null>(null);
    const isOpen = Boolean(anchorElement);

    const filtersClick = (event:React.MouseEvent<HTMLButtonElement>):void => {
        setAnchorElement(event.currentTarget);
    }

    const handlePopoverClose = () => {
        setAnchorElement(null);
    }

    return(
        <div className="notes-page">
            <div className="notes-page-header">
                <TextField label="Search" variant="outlined" slotProps={{
                    input:{ endAdornment:(
                        <InputAdornment position="end">
                            <FaMagnifyingGlass />
                        </InputAdornment>
                    )}
                }}  />
                <span>
                    <Button variant="outlined" id="filters-btn" onClick={filtersClick}>Sort<FaSort /></Button>
                    <Button variant="contained" id="create-btn">Add<FaPlus /></Button>
                </span>
                <Popover id={"filters-list"} open={isOpen} onClose={handlePopoverClose} anchorEl={anchorElement} anchorOrigin={{vertical:"bottom", horizontal:"right"}} transformOrigin={{vertical:"top", horizontal:"right"}}>
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
                </Popover>
            </div>
            <div className="notes-page-content">
                <div className="notes-container">
                    {MockData.MockNotes.map((x) => {
                    return(
                        <NoteCard title={x.title} content={x.content} createdAt={x.createdAt} />
                    )
                    })}
                </div>
                <div className="notes-paggination">
                    <Pagination count={10}/>
                </div>
            </div>
        </div>
    )
}

export default NotesPage