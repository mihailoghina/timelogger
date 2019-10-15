import React from 'react';

export default function ProjectDetails(props) {
    const project = props.data;
    return (
            <>
            <ul>
                <li>Project name: {project.name}</li>
                <li>Deadline: {project.deadLineDate}</li>
                <li>Completed: {project.isComplete ? "yes" : "no"}</li>
                <li>Created at: {project.deadLineDate}</li>
            </ul>
            </>
    ); 
}