import React from 'react';

export default function ProjectDetails(props) {
    const project = props.data;
    debugger;
    return (
            <>
            <p>Project name: {project.name}</p>
            <p>Deadline: {project.deadLineDate}</p>
            <p>Logged time (min): {project.loggedMinutes}</p>
            <p>Completed: {project.isComplete ? "yes" : "no"}</p>
            <p>Created at: {project.creationDate}</p>
            </>
    ); 
}