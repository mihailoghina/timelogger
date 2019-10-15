import React from 'react';

export default function UserDetails(props) {
    const user = props.data;
    return (
            <>
            <img src={user.pathToAvatar} alt="bad luck, no picture here" style={{width: 400}}></img>
            <p>Name: {user.name}</p>
            <p>Email: {user.email}</p>
            <p>Timestamp: {user.creationDate}</p>	
            </>
    ); 
}