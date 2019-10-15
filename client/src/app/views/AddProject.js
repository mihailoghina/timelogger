import React from 'react';
import axios from 'axios';
import {API_BASE_URL} from '../constants';

export default class AddProject extends React.Component {

    constructor(props) {
        super(props)
        this.handleSubmit = this.handleSubmit.bind(this)
      }

      postDataToServer(name, deadline) {
        axios({
            method: "POST",
            url: `${API_BASE_URL}projects`,
            headers: {
                'Content-Type' : 'application/json' 
            },
             data: {
                name: name,
                deadLineDate: deadline,
                createdBy: this.props.match.params.id
             }
          })
            .then(res => {
                window.history.back();
            })
            .catch(err => {
                alert(err.response.data);
            });
        
      }

      checkValidDate(date) {
          return (new Date() < date);
      }

      handleSubmit(event) {
        event.preventDefault();
        var name = document.getElementById("name").value;
        var date = new Date(document.getElementById("deadLine").value);

        if(this.checkValidDate(date)) {
            this.postDataToServer(name, date);
        } else {
            alert("you can not choose a date in the past");
        } 
    }

    render() {
        return (
            <>
            <form onSubmit={this.handleSubmit}>
               <label htmlFor="name">Name</label><br/>
                <input minLength="5" type="text" id="name"  /><br/>
                <label htmlFor="Deadline">Deadline</label><br/>
                <input type="date" id="deadLine"/><br/><br/>
                <input type="submit" value="Add project" />
            </form>
            </>
        )
    }
}