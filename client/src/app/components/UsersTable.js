import React from 'react';
import {Link} from "react-router-dom";

export default function UsersTable(props) {
    return (
        <table className="table table-striped">
            <thead>
                <tr>
                    <th scope="col">Name</th>
                    <th scope="col">Email</th>
                    <th scope="col">Timestamp</th>
                    <th scope="col">Actions</th>
                </tr>
            </thead>
            <tbody>
                { props.data.map(
                    user => 
                    <tr key={user.id}>
                        <td>{user.name}</td>
                        <td>{user.email}</td>
                        <td>{user.creationDate}</td>
                        <td><Link to={`/users/${user.id}`}>View</Link></td>                           
                    </tr>
                )}
            </tbody>
        </table>
    );
}
