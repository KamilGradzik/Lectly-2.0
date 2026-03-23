import { Button, InputAdornment, TextField } from "@mui/material";
import { JSX } from "react";
import { FaFilter, FaMagnifyingGlass, FaPlus } from "react-icons/fa6";
import "./notes-page.scss"
import MockNotes from "../../assets/mock-data";
import Note from "../../components/note/note";

const NotesPage = ():JSX.Element => {
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
                    <Button variant="outlined" id="filters-btn" onClick={() => {console.log("CLICK")}}>filter<FaFilter /></Button>
                    <Button variant="contained" id="create-btn">Add<FaPlus /></Button>
                </span>
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