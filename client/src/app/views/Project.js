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
	
			{project.isComplete == false &&
				<>
				<Link to={`/projects/${this.props.match.params.id}/addactivity`}>ADD NEW ACTIVITY</Link>
				<br/><br/>
				<Link to={`/projects/${this.props.match.params.id}/edit`}>EDIT PROJECT</Link>
				</>
			}
			<br/>
			<Link to={`/users/${this.props.match.params.id}/addproject`}>DELETE PROJECT (TODO)</Link>


			<ProjectActivities projectId = {project.id} />
			</>
        )
    }
}