import React from 'react';
import convertTime from '../convertTime'

export default class ProjectDetails extends React.Component {
    
    render() {
        const project = this.props.data;

        return (
                <>
                <p>Project name: {project.name}</p>
                <p>Deadline: {project.deadLineDate}</p>
                <p>Logged time: {convertTime(project.loggedMinutes)}</p>
                <p>Completed: {project.isComplete ? "yes" : "no"}</p>
                <p>Created at: {project.creationDate}</p>
                </>
        ); 
    }
}