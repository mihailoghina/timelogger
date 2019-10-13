import React, { Component } from 'react';
import {Link} from "react-router-dom";

class UserProjectsTable extends Component
{
    render() {
        return (
            <table className="table">
                <thead className="thead-dark">
                    <tr>
                        <th scope="col">Project Name</th>
                        <th scope="col">Deadline</th>
                        <th scope="col">Completed</th>
                        <th scope="col">Created at</th>
                        <th scope="col">View</th>
                    </tr>
                </thead>
                <tbody>
                    { this.props.data.map(
                        proj => 
                        <tr key={proj.id}>
                            <td>{proj.name}</td>
                            <td>{proj.deadLineDate}</td>
                            <td>{proj.completed ? "yes" : "no"}</td>
                            <td>{proj.creationDate}</td>
                            <td><Link to={`/project/${proj.id}`}>Go to project</Link></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}

export default UserProjectsTable