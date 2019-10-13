import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import {USER_ID, API_BASE_URL} from '../constants';
import UserProjectsTable from '../components/UserProjectsTable'

class UserProjects extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            userProjects: []
        };
    }

    componentDidMount() {
        axios.get(API_BASE_URL + "users/" + USER_ID + "/projects")
          .then(res => {
            this.setState({ userProjects: res.data });
        }).catch(error => {
            console.log(error.response);
        })
    }
    
    render() {
        return (
            <UserProjectsTable data = {this.state.userProjects} />
        )
    }
}

export default UserProjects;