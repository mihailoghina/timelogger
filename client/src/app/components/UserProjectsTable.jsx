
import {Link} from "react-router-dom";
import React from 'react';

export default function UserProjectsTable(props) {
    debugger;
    return (
        <table className="table table-striped">
            <thead>
                <tr>
                    <th scope="col">Project Name</th>
                    <th scope="col">Deadline</th>
                    <th scope="col">Completed</th>
                    <th scope="col">Logged time (min)</th>
                    <th scope="col">Created at</th>
                    <th scope="col">Actions</th>
                </tr>
            </thead>
            <tbody>
                { props.data.map(
                    proj => 
                    <tr key={proj.id}>
                        <td>{proj.name}</td>
                        <td>{proj.deadLineDate}</td>
                        <td>{proj.completed ? "yes" : "no"}</td>
                        <td>{proj.loggedMinutes}</td>
                        <td>{proj.creationDate}</td>
                        <td><Link to={`/project/${proj.id}`}>View</Link></td>
                    </tr>
                )}
            </tbody>
        </table>
    ); 
}