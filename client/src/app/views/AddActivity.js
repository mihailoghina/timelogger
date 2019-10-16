import React from 'react';
import axios from 'axios';
import {USER_ID,API_BASE_URL} from '../constants';

export default class AddActivity extends React.Component {

    constructor(props) {
        super(props)
        this.handleSubmit = this.handleSubmit.bind(this)
      }

      postDataToServer(name, loggedMinutes, description) {
        axios({
            method: "POST",
            url: `${API_BASE_URL}activities`,
            headers: {
                'Content-Type' : 'application/json' 
            },
             data: {
                projectId: this.props.match.params.id,
                name: name,
                loggedMinutes: loggedMinutes,
                description: description,
                createdBy: USER_ID // hardcoded guid corresponding to mihai loghina as only the owner of the project is allowed to log hours
             }
          })
            .then(res => {
                window.history.back();
            })
            .catch(err => {
                alert(err.response.data);
            });
        
      }

      handleSubmit(event) {
        event.preventDefault();
        var name = document.getElementById("name").value;
        var loggedMinutes = document.getElementById("loggedMinutes").value;
        var description = document.getElementById("description").value;

        this.postDataToServer(name, loggedMinutes, description);
    }

    render() {
        return (
            <>
            <form onSubmit={this.handleSubmit}>

               <label htmlFor="name">Name</label><br/>
                <input minLength="5" type="text" id="name"  /><br/>

                <label htmlFor="loggedMinutes">Log time (minutes)</label><br/>
                <input type="number" min="30" id="loggedMinutes"/><br/><br/>

                <label htmlFor="description">Description (optional)</label><br/>
                <input type="text" id="description"/><br/><br/>

                <input type="submit" value="Add activity" />
            </form>
            </>
        )
    }
}