
import {Link} from "react-router-dom";
import React from 'react';

export default function ProjectActivitiesTable(props) {
    debugger;
    return (
        <table className="table table-striped">
            <thead>
                <tr>
                    <th scope="col">Activity Name</th>
                    <th scope="col">Description</th>
                    <th scope="col">Logged time (min)</th>
                    <th scope="col">Timestamp</th>
                    <th scope="col">Actions</th>
                </tr>
            </thead>
            <tbody>
                { props.data.map(
                    activity => 
                    <tr key={activity.id}>
                        <td>{activity.name}</td>
                        <td>{activity.description}</td>
                        <td>{activity.loggedMinutes}</td>
                        <td>{activity.creationDate}</td>
                        <td><Link to={`/activities/${activity.id}`}>View</Link></td>
                    </tr>
                )}
            </tbody>
        </table>
    ); 
}