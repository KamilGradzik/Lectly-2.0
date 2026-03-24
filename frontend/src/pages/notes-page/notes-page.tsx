import { Button, InputAdornment, List, ListItem, ListItemAvatar, ListItemButton, ListItemIcon, ListItemText, MenuItem, Popover, Select, TextField } from "@mui/material";
import { JSX, useState } from "react";
import { FaFilter, FaMagnifyingGlass, FaPlus } from "react-icons/fa6";
import "./notes-page.scss"
import MockNotes from "../../assets/mock-data";
import Note from "../../components/note/note";
import { FaSortAlphaDown, FaSortAlphaDownAlt, FaSortAlphaUp, FaSortAlphaUpAlt } from "react-icons/fa";

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
                    <Button variant="outlined" id="filters-btn" onClick={filtersClick}>filter<FaFilter /></Button>
                    <Button variant="contained" id="create-btn">Add<FaPlus /></Button>
                </span>
                {/* <Popover id={"filters-list"} open={isOpen} onClose={handlePopoverClose} anchorEl={anchorElement} anchorOrigin={{vertical:"bottom", horizontal:"right"}} transformOrigin={{vertical:"top", horizontal:"right"}}>
                    <List>
                        <ListItemButton>
                            <ListItemText primary="Title" />
                            <ListItemIcon><FaSortAlphaDown /></ListItemIcon>
                        </ListItemButton>
                        <ListItemButton>
                            <ListItemText primary="Title" />
                            <ListItemIcon><FaSortAlphaUp /></ListItemIcon>
                        </ListItemButton>
                    </List>
                </Popover> */}
            </div>
            <div className="notes-page-content">
                {MockNotes.map((x) => {
                    return(
                        <Note title={x.title} content={x.content} createdAt={x.createdAt} />
                    )
                })}
            </div>
        </div>
    )
}

export default NotesPage