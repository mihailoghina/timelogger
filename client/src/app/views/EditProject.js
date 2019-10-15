import React from 'react';
import axios from 'axios';
import {API_BASE_URL} from '../constants';

export default class EditProject extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            project: "",
            dataReady: false,
            optionState: this.props.isCompleted
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.change = this.change.bind(this);
      }

      postDataToServer(name, deadline) {
        axios({
            method: "PUT",
            url: `${API_BASE_URL}projects/${this.props.match.params.id}`,
            headers: {
                'Content-Type' : 'application/json' 
            },
             data: {
                name: name,
                deadLineDate: deadline,
                createdBy: this.props.match.params.id,
                isCompleted: true   //TODO
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

    componentDidMount() {		
        var projectId = this.props.match.params.id;

		axios({
            method: "GET",
            url: `${API_BASE_URL}projects/${projectId}`
          })
            .then(res => {
                this.setState({ project: res.data, dataReady: true });
            })
            .catch(err => {
                alert(`Status code: ${err.response.status} \n Message: ${err.response.data}`);
            });
    }

    change(event) {
        this.setState({ optionState: event.target.value});
    }

    render() {
        debugger;
        const {project, dataReady} = this.state;

        if(!dataReady) return null;

        return (
            <>
            <form onSubmit={this.handleSubmit}>
               <label htmlFor="name">Name</label><br/>
                <input minLength="5" type="text" id="name" value={project.name} /><br/>

                <label htmlFor="isCompleted">Is project completed</label><br />
                <select id="isCompleted" onChange={this.change} value={project.isCompleted}>
                    <option value="true" selected={project.isCompleted == false}>true</option>
                    <option value="false" >false</option>
                </select>
                <br />

                <label htmlFor="Deadline">Deadline</label><br/>
                <input type="date" id="deadLine" value={project.deadlineDate} /><br/><br/>

                <input type="submit" value="Edit project" />
            </form>
            </>
        )
    }
}