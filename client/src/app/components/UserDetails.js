import React from 'react';

export default function UserDetails(props) {
    const user = props.data;
    return (
            <>
            <img src={user.pathToAvatar} alt="bad luck, no pic" style={{width: 400}} />
            <p>Name: {user.name}</p>
            <p>Email: {user.email}</p>
            <p>Timestamp: {user.creationDate}</p>	
            </>
    ); 
}