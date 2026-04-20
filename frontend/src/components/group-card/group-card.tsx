import { JSX } from "react"
import "./group-card.scss"
import { FaEdit, } from "react-icons/fa"
import AddIcon from '@mui/icons-material/Add';
import { FaAngleRight, FaClock, FaGraduationCap, FaPenRuler, FaPlus, FaTrash, FaUsers } from "react-icons/fa6"
import { Accordion, AccordionDetails, AccordionSummary, Badge, Button, Chip, Divider, List, ListItem, ListItemButton, ListItemIcon, ListItemText, Tooltip } from "@mui/material"
import MockData from "../../assets/mock-data"

interface props{
    title:string,
    desc:string,
    subjectsCount:number,
    studentsCount:number,
    nextClass:string,
    
}

const GroupCard = ({title, desc, subjectsCount, studentsCount, nextClass}:props):JSX.Element => {
    return(
        <div className="group-card">   
            <div className="group-card-header">
                <h1>{title}</h1>
            </div>
            <div className="group-card-body">
                <div className="group-info">
                    <div className="group-desc">
                        <p>{desc}</p>                        
                    </div>
                    <div className="group-next-classes">
                        <p><FaClock />{nextClass}</p>
                    </div>
                </div>
                <div className="group-content">
                    <Accordion disableGutters>
                        <AccordionSummary expandIcon={<FaAngleRight />}>
                            <span>Students</span>
                        </AccordionSummary>
                        <AccordionDetails>
                            <List>
                                {MockData.MockStudents.map((x, i) => {
                                return(
                                    <ListItemButton>
                                        <ListItemText>{`${x.firstName} ${x.lastName}`}</ListItemText>
                                    </ListItemButton>
                                )
                                })}
                            </List>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion disableGutters>
                        <AccordionSummary expandIcon={<FaAngleRight />}>
                            <span>Subjects</span>
                        </AccordionSummary>
                        <AccordionDetails>
                            
                        </AccordionDetails>
                    </Accordion>
                </div>
                {/* <div className="group-card-footer">
                    <Button>details</Button>
                    <div className="group-card-actions">
                        <Tooltip title="Edit group">
                            <FaEdit className="edit-btn"/>
                        </Tooltip>
                        <Tooltip title="Remove group" >
                            <FaTrash className="remove-btn"/>
                        </Tooltip>
                        
                    </div>
                </div> */}
            </div>
        </div>
    )
}

export default GroupCard