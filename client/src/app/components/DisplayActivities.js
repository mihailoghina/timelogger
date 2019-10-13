import React, { Component } from 'react';

class DisplayActivities extends Component
{
    render() {
        return (
            <>
                {this.props.data.map(function(acitivity) {
                    <ul>
                        <li>{acitivity.name}</li>
                        <li>{acitivity.description}</li>
                        <li>{acitivity.creationDate}</li>
                    </ul>
                })
                }
            </>            
        );
    }
}

export default DisplayActivities