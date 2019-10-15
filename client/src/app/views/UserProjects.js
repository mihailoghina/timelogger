import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import {API_BASE_URL} from '../constants';
import UserProjectsTable from '../components/UserProjectsTable'

class UserProjects extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            userProjects: [],
            dataReady: false
        };
    }

    componentDidMount() {        
        debugger;
        var a = this.props
        axios({
            method: "GET",
            url: `${API_BASE_URL}users/${this.props.userId}/projects?includeTime=true`
          })
            .then(res => {
                this.setState({ userProjects: res.data, dataReady: true });
            })
            .catch(err => {
                alert(`Status code: ${err.response.status} \n Message: ${err.response.data}`);
            });
    }
    
    render() {

        if(!this.state.dataReady) return null;

        return (
            <UserProjectsTable data = {this.state.userProjects} />
        )
    }
}

export default UserProjects;