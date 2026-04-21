import { JSX } from "react"
import "./group-card.scss"
import { FaEdit, FaTimes, } from "react-icons/fa"
import AddIcon from '@mui/icons-material/Add';
import { FaAngleRight, FaClock, FaGraduationCap, FaMinus, FaPenRuler, FaPlus, FaTrash, FaUsers } from "react-icons/fa6"
import { Accordion, AccordionDetails, AccordionSummary, Badge, Button, Chip, Divider, List, ListItem, ListItemAvatar, ListItemButton, ListItemIcon, ListItemText, Tooltip } from "@mui/material"
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
                <span className="group-actions">
                    <Tooltip title="Edit Group">
                        <FaEdit className="group-edit-btn"/>
                    </Tooltip>
                    <Tooltip title="Remove Group">
                        <FaTrash className="group-remove-btn"/>
                    </Tooltip>
                </span>
            </div>
            <div className="group-card-body">
                <div className="group-info">
                    <p className="group-desc">{desc}</p>                        
                    <p className="group-next-classes"><FaClock />{nextClass}</p>
                </div>
                <div className="group-content">
                    <Accordion disableGutters>
                        <AccordionSummary expandIcon={<FaAngleRight />}>
                            <span>Students {studentsCount > 0 ? <span className="group-numbers-chip">{studentsCount}</span> : <></>}</span>
                        </AccordionSummary>
                        <AccordionDetails>
                            <List>
                                {MockData.MockStudents.map((x, i) => {
                                return(
                                    <ListItem>
                                        <ListItemText>{`${x.firstName} ${x.lastName}`}</ListItemText>
                                        <ListItemIcon><Tooltip title="Detach Student"><Button><FaTimes/></Button></Tooltip></ListItemIcon>
                                    </ListItem>
                                )
                                })}
                            </List>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion disableGutters>
                        <AccordionSummary expandIcon={<FaAngleRight />}>
                            <span>Subjects {subjectsCount > 0 ? <span className="group-numbers-chip">{subjectsCount}</span> : <></>}</span>
                        </AccordionSummary>
                        <AccordionDetails>
                            <List>
                                {MockData.MockGroups.map((x, i) => {
                                return(
                                    <ListItem>
                                        <ListItemText>{x.nazwa}</ListItemText>
                                        <ListItemIcon><Tooltip title="Detach Subject"><Button><FaTimes/></Button></Tooltip></ListItemIcon>
                                    </ListItem>
                                )
                                })}
                            </List>
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