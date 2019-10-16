import React from 'react';
import axios from 'axios';
import {API_BASE_URL} from '../constants';

export default class EditProject extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            project: "",
            dataReady: false,
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.nameChange = this.nameChange.bind(this);
        this.completionChange = this.completionChange.bind(this);
        this.deadLineChange = this.deadLineChange.bind(this);
      }

      postDataToServer(name, deadline, isComplete) {
     
        axios({
            method: "PUT",
            url: `${API_BASE_URL}projects/${this.props.match.params.id}`,
            headers: {
                'Content-Type' : 'application/json' 
            },
             data: {
                name: name,
                deadLineDate: deadline,
                isComplete: isComplete
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
          return (new Date() < new Date(date));
      }

      handleSubmit(event) {
        event.preventDefault();
        var {project} = this.state;
        if(this.checkValidDate(project.deadLineDate)) {
            this.postDataToServer(project.name, new Date(project.deadLineDate), project.isComplete);
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

    completionChange(event) {
        this.setState({ project:  Object.assign({}, this.state.project, {isComplete: event.target.value}) });
    }

    nameChange(event) {
        this.setState({ project:  Object.assign({}, this.state.project, {name: event.target.value}) });
    }

    deadLineChange(event) {
        this.setState({ project:  Object.assign({}, this.state.project, {deadLineDate: event.target.value}) });
    }

    transformDate(date) {
        var d = new Date(date);
        var mm = d.getMonth() + 1;
        var dd = d.getDate();
        var yy = d.getFullYear();
        return `${yy}-${mm}-${dd}`
    }

    render() {
        const {project, dataReady} = this.state;

        if(!dataReady) return null;

        return (
            <>
            <form onSubmit={this.handleSubmit}>

               <label htmlFor="name">Name</label><br/>
                <input minLength="5" type="text" id="name" value={project.name} onChange={this.nameChange}/><br/>

                <label htmlFor="isCompleted">Is project completed</label><br />
                <select id="isCompleted" value={project.isComplete} onChange={this.completionChange}>
                    <option value="true">true</option>
                    <option value="false">false</option>
                </select>
                <br />

                <label htmlFor="Deadline">Deadline</label><br/>
                <input type="date" id="deadLine" value={this.transformDate(project.deadLineDate)} onChange = {this.deadLineChange}/><br/><br/>

                <input type="submit" value="Save changes" />
            </form>
            </>
        )
    }
}