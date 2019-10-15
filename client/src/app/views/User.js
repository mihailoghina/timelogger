import React from 'react';
import axios from 'axios';
import {API_BASE_URL} from '../constants';
import UserProjects from './UserProjects';
import UserDetails from '../components/UserDetails';

export default class User extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            user: "",
            dataReady: false
        };
	}

    componentDidMount() {		
        var userId = this.props.match.params.id;
        
        axios({
            method: "GET",
            url: `${API_BASE_URL}users/${userId}`
          })
            .then(res => {
                this.setState({ user: res.data, dataReady: true });
            })
            .catch(err => {
                alert(`Status code: ${err.response.status} \n Message: ${err.response.data}`);
            });
    }
    
    render() {
        const {user} = this.state;

        if(!this.state.dataReady) return null;
        return (
			<>
            <UserDetails data = {user}/>
            <br/><br/>
            <p>User projects:</p>
            <UserProjects userId = {this.props.match.params.id} />		
			</>
        )
    }
}