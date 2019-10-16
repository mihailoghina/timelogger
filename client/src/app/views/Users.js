import React from 'react';
import axios from 'axios';
import {API_BASE_URL} from '../constants';
import UsersTable from '../components/UsersTable'

class Users extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
			users: [],
			dataReady: false
        };
	}

    componentDidMount() {		
        axios({
            method: "GET",
            url: `${API_BASE_URL}users`
          })
            .then(res => {
                this.setState({ users: res.data, dataReady: true });
            })
            .catch(err => {
                alert(`Status code: ${err.response.status} \n Message: ${err.response.data}`);
            });
    }
    
    render() {
		const {users, dataReady} = this.state;

		if(!dataReady) return null;  // if not checked will try to map undefined values

        return (
			<UsersTable data = {users} />
        )
    }
}

export default Users;