import React from 'react';
import axios from 'axios';
import {API_BASE_URL} from '../constants';
import ProjectDetails from '../components/ProjectDetails'
import ProjectActivities from './ProjectActivities';
import {Link} from "react-router-dom";

export default class Project extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
			project: "",
			dataReady: false
        };
        this.deleteProject = this.deleteProject.bind(this);
    }
    
    deleteProject() {

        var confirmation = window.confirm("Are you sure you want to delete this project and all its activities?");

        if(confirmation === true) {

            var projectId = this.props.match.params.id;

            axios({
                method: "DELETE",
                url: `${API_BASE_URL}projects/${projectId}`
            })
                .then(res => {
                    window.history.back();
                })
                .catch(err => {
                    alert(`Status code: ${err.response.status} \n Message: ${err.response.data}`);
                });
        }
    }

    historyBack() {
        window.history.back();
    }

    componentDidMount() {		
		var projectId = this.props.match.params.id;

		axios({
            method: "GET",
            url: `${API_BASE_URL}projects/${projectId}?includeTime=true`
          })
            .then(res => {
                this.setState({ project: res.data, dataReady: true });
            })
            .catch(err => {
                alert(`Status code: ${err.response.status} \n Message: ${err.response.data}`);
            });
    }

    render() {
		const {project, dataReady} = this.state;

		if(!dataReady) return null;  // if not checked will try to map undefined values

        return (
			<>
            <ProjectDetails data = {project} />
	
			{project.isComplete === false &&
				<>
				<Link to={`/projects/${this.props.match.params.id}/addactivity`}>ADD NEW ACTIVITY</Link>
				<br/><br/>
				<Link to={`/projects/${this.props.match.params.id}/edit`}>EDIT PROJECT</Link>
                <br/>
				</>
			}
			<br/>
            <button onClick={this.deleteProject}>DELETE PROJECT</button>
            <br /><br />

            <button onClick={this.historyBack}>Go to users list</button>
            <br />

            <ProjectActivities 
                projectId = {project.id} 
                isProjectComplete = {project.isComplete}
                />
			</>
        )
    }
}